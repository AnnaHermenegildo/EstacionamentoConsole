using EstacionamentoConsole.Interfaces;
using EstacionamentoConsole.Models.Response;
using System.Collections.Generic;

namespace EstacionamentoConsole.Models.Services
{

    public class EstacionamentoService
    {
        private readonly IEstacionamento _estacionamento;

        public EstacionamentoService(IEstacionamento estacionamento)
        {
            _estacionamento = estacionamento;
        }

        public Vaga? ObterVagaDisponivel(Veiculo veiculo)
        {
            return _estacionamento.ObterVagaDisponivel(veiculo);
        }

        public IEnumerable<(string Tipo, Veiculo Veiculo)> ListarVeiculosEstacionados()
        {
            return _estacionamento.ListarVeiculosEstacionados();
        }



        public void RegistrarEntradaVeiculo(Veiculo veiculo)
        {
            var vagaDisponivel = ObterVagaDisponivel(veiculo);

            if (vagaDisponivel != null)
            {
                _estacionamento.RegistrarEntrada(veiculo, vagaDisponivel);
                Console.WriteLine("Entrada registrada com sucesso.");
            }
            else
            {
                Console.WriteLine("Não há vagas disponíveis.");
            }
        }

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
