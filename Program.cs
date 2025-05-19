using System;
using EstacionamentoConsole.ApplicationLayer;
using EstacionamentoConsole.Models;
using EstacionamentoConsole.Models.DTOs;
using EstacionamentoConsole.Models.Services;

class Program
{
    // Ponto de entrada da aplicação Console
    // Princípio aplicado: SRP (Single Responsibility Principle)
    // A classe Program tem a responsabilidade única de coordenar o fluxo da aplicação,
    // interagindo com o usuário e delegando ações para as camadas de aplicação e domínio.

    // Conceito aplicado: GRASP - Controller
    // Program atua como controlador da interação com o usuário, direcionando o fluxo de entrada e saída.

    // Conceito aplicado: DDD - Application Layer
    // Program interage com a camada de aplicação, que por sua vez orquestra a comunicação com o domínio.
    static void Main()
    {
        // Instancia o agregado raiz Estacionamento,
        // que representa o núcleo da lógica de domínio para gerenciar vagas.
        // Princípio aplicado: DIP (Dependency Inversion Principle)
        // Dependemos da abstração (interface IEstacionamento) no serviço, mas aqui instanciamos o agregado concreto.
        var estacionamento = new Estacionamento(totalCarros: 3, totalMotos: 2);

        // Criação do serviço da camada de aplicação,
        // responsável por orquestrar operações de entrada e saída,
        // mantendo separação entre domínio e interface de usuário.
        var estacionamentoService = new EstacionamentoService(estacionamento);

        // Camada de aplicação específica para entrada de veículo
        var entradaVeiculo = new EntradaVeiculo(estacionamentoService);

        // Camada de aplicação específica para saída de veículo
        var saidaVeiculo = new SaidaVeiculo(estacionamentoService);

        while (true)
        {
            Console.Clear();

            // Exibe o estado atual do domínio (vagas disponíveis)
            // Princípio aplicado: Demeter - só acessa métodos necessários da entidade estacionamento
            Console.WriteLine($"Vagas disponíveis - Carros: {estacionamento.VagasDisponiveisParaCarro()}");
            Console.WriteLine($"Vagas disponíveis - Motos: {estacionamento.VagasDisponiveisParaMoto()}");
            Console.WriteLine();

            // Controlador da interação com o usuário,
            // delegando responsabilidades específicas para outras classes (GRASP - Controller)
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1 - Registrar Entrada");
            Console.WriteLine("2 - Registrar Saída");
            Console.WriteLine("3 - Listar Veiculos");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");
            var opcao = Console.ReadLine();

            if (opcao == "0")
                break;

            if (opcao == "1")
            {
                // Coleta dados para entrada do veículo
                // Princípio aplicado: ISP (Interface Segregation Principle)
                // Aqui só pede dados essenciais para criar o DTO de entrada.

                Console.Write("Tipo do veículo (carro/moto): ");
                var tipo = Console.ReadLine()?.Trim().ToLower();

                if (tipo != "carro" && tipo != "moto")
                {
                    Console.WriteLine("Tipo inválido. Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Placa: ");
                var placa = Console.ReadLine()?.Trim();

                Console.Write("Marca: ");
                var marca = Console.ReadLine()?.Trim();

                Console.Write("Modelo: ");
                var modelo = Console.ReadLine()?.Trim();

                Console.Write("Cor: ");
                var cor = Console.ReadLine()?.Trim();

                // Princípio aplicado: OCP (Open/Closed Principle)
                // DTO está aberto para extensão (novos tipos ou campos) sem necessidade de mudar esta camada.
                var dto = new EntradaVeiculoDTO(tipo, placa, marca, modelo, cor);

                try
                {
                    entradaVeiculo.Entrada(dto);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao registrar entrada: {ex.Message}");
                }
            }
            else if (opcao == "2")
            {
                // Solicita placa para saída do veículo
                Console.Write("Digite a placa do veículo para saída: ");
                var placa = Console.ReadLine()?.Trim();

                try
                {
                    // Cria DTO para saída (se aplicável)
                    // Orquestra a saída do veículo pela camada de aplicação
                    saidaVeiculo.RegistrarSaida(new EstacionamentoConsole.Models.DTOs.SaidaVeiculoDTO { Placa = placa});
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao registrar saída: {ex.Message}");
                }
            }
            else if (opcao == "3")
            {
                var veiculos = estacionamentoService.ListarVeiculosEstacionados();
                Console.WriteLine("Veículos Estacionados:");
                foreach (var (tipo, veiculo) in veiculos)
                {
                    Console.WriteLine($"{tipo}: {veiculo.Placa} - {veiculo.Marca} {veiculo.Modelo} - {veiculo.Cor}");
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
