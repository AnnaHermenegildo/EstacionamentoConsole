using EstacionamentoConsole.Models.Response;
using EstacionamentoConsole.Models;

namespace EstacionamentoConsole.Interfaces
{
    public interface IEstacionamento
    {

        public void RegistrarEntrada(Veiculo veiculo, Vaga vaga);

        public void RegistrarSaida(Veiculo placa, Vaga vaga);

        public Vaga? ObterVagaDisponivel(Veiculo veiculo);

        public Vaga? RetornaVagaPorPlaca(Veiculo placa);

        IEnumerable<(string Tipo, Veiculo Veiculo)> ListarVeiculosEstacionados();


        public int VagasDisponiveisParaCarro();

        public int VagasDisponiveisParaMoto();
    }
}
