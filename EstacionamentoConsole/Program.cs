using System;
using EstacionamentoConsole.ApplicationLayer;
using EstacionamentoConsole.Models;
using EstacionamentoConsole.Models.DTOs;
using EstacionamentoConsole.Models.Services;

class Program
{
    static void Main()
    {
        var estacionamento = new EstacionamentoConsole.Models.Estacionamento(totalCarros: 3, totalMotos: 2);

        var estacionamentoService = new EstacionamentoService(estacionamento);

        var entradaVeiculo = new EntradaVeiculo(estacionamentoService);

        var saidaVeiculo = new SaidaVeiculo(estacionamentoService);

        while (true)
        {
            Console.Clear();

            Console.WriteLine($"Vagas disponíveis - Carros: {estacionamento.VagasDisponiveisParaCarro()}");
            Console.WriteLine($"Vagas disponíveis - Motos: {estacionamento.VagasDisponiveisParaMoto()}");
            Console.WriteLine();

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
                Console.Write("Digite a placa do veículo para saída: ");
                var placa = Console.ReadLine()?.Trim();

                try
                {
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
