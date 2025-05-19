using EstacionamentoConsole.Interfaces;
using EstacionamentoConsole.Models.Response;
using System.Collections.Generic;

namespace EstacionamentoConsole.Models.Services
{
    // Princípio aplicado: SRP (Single Responsibility Principle)
    // Nome: Princípio da Responsabilidade Única
    // Objetivo: Esta classe tem a única responsabilidade de orquestrar a lógica de entrada e saída de veículos,
    // separando a lógica de aplicação da lógica de domínio (que está no agregado Estacionamento).

    // Princípio aplicado: DIP (Dependency Inversion Principle)
    // Nome: Princípio da Inversão de Dependência
    // Objetivo: Depender de abstrações (IEstacionamento) em vez de implementações concretas.
    // Explicação: A classe depende da interface IEstacionamento, não diretamente da classe Estacionamento.

    // Conceito aplicado: GRASP - Controller
    // Nome: Controlador (Controller)
    // Objetivo: Atribuir a responsabilidade de lidar com a orquestração de ações a um objeto que representa uma sessão lógica.
    // Explicação: O EstacionamentoService é o controlador da aplicação que coordena a entrada e saída de veículos.

    // Conceito aplicado: DDD - Application Layer
    // Objetivo: Esta classe representa uma camada de aplicação que intermedia a comunicação entre a interface do usuário
    // e a camada de domínio (Estacionamento).

    public class EstacionamentoService
    {
        private readonly IEstacionamento _estacionamento;

        public EstacionamentoService(IEstacionamento estacionamento)
        {
            // Aqui ocorre a injeção da dependência via construtor
            _estacionamento = estacionamento;
        }

        // Método responsável por obter vaga disponível para o veículo
        public Vaga? ObterVagaDisponivel(Veiculo veiculo)
        {
            return _estacionamento.ObterVagaDisponivel(veiculo);
        }

        // Método para listar os veículos estacionados
        public IEnumerable<(string Tipo, Veiculo Veiculo)> ListarVeiculosEstacionados()
        {
            return _estacionamento.ListarVeiculosEstacionados();
        }



        // Método responsável por registrar a entrada de um veículo em uma vaga específica
        public void RegistrarEntradaVeiculo(Veiculo veiculo)
        {
            var vagaDisponivel = ObterVagaDisponivel(veiculo);

            if (vagaDisponivel != null)
            {
                // Passa o DTO e a vaga para a camada de aplicação EntradaVeiculo
                _estacionamento.RegistrarEntrada(veiculo, vagaDisponivel);
                Console.WriteLine("Entrada registrada com sucesso.");
            }
            else
            {
                Console.WriteLine("Não há vagas disponíveis.");
            }
        }

        // Método responsável por registrar a saída de um veículo, usando a placa
        public void RegistrarSaidaVeiculo(string placa)
        {
            var veiculoEstacionado = ListarVeiculosEstacionados().Where(x => x.Veiculo.Placa == placa).FirstOrDefault();

            var vaga = _estacionamento.RetornaVagaPorPlaca(veiculoEstacionado.Veiculo);

            if (veiculoEstacionado.Veiculo is not null && vaga is not null)
            {
                _estacionamento.RegistrarSaida(veiculoEstacionado.Veiculo, vaga);

                Console.WriteLine("Saída registrada com sucesso.");
            }
            else
            {
                Console.WriteLine("Veículo não se encontra estacionado.");
            }

        }

      
    }
}
