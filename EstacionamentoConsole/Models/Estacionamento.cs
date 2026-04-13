using EstacionamentoConsole.Interfaces;
using EstacionamentoConsole.Models.Factory;

namespace EstacionamentoConsole.Models
{
    public class Estacionamento : IEstacionamento
    {
        private readonly List<Vaga> _vagas;

        public Estacionamento(int totalCarros, int totalMotos)
        {
            _vagas = VagaFactory.CriarVagas(totalCarros, totalMotos);
        }

        public void RegistrarEntrada(Veiculo veiculo, Vaga vaga)
        {
            vaga.Ocupar(veiculo);
        }

        public void RegistrarSaida(Veiculo veiculo, Vaga vaga)
        {
            vaga.Liberar(veiculo);
        }

        public int TotalVagas => _vagas.Count;

        public int VagasDisponiveisParaCarro()
            => _vagas.OfType<VagaCarro>().Count(v => !v.Ocupada);

        public int VagasDisponiveisParaMoto()
            => _vagas.OfType<VagaMoto>().Count(v => !v.Ocupada);

        public Vaga? ObterVagaDisponivel(Veiculo veiculo)
        {

            return veiculo switch
            {
                Carro => _vagas.OfType<VagaCarro>().FirstOrDefault(v => !v.Ocupada),
                Moto => _vagas.OfType<VagaMoto>().FirstOrDefault(v => !v.Ocupada),
                _ => throw new InvalidOperationException("Tipo de veículo desconhecido.")
            };
        }

        public IEnumerable<(string Tipo, Veiculo Veiculo)> ListarVeiculosEstacionados()
        {
            return _vagas
                .Where(v => v.Ocupada && v.VeiculoEstacionado != null)
                .Select(v =>
                {
                    var tipo = v switch
                    {
                        VagaCarro => "Carro",
                        VagaMoto => "Moto",
                        _ => "Desconhecido"
                    };

                    return (tipo, v.VeiculoEstacionado!);
                });
        }


        public Vaga? RetornaVagaPorPlaca(Veiculo veiculo)
        {

            return _vagas.Where(x => x.VeiculoEstacionado == veiculo).FirstOrDefault();
        }
    }
}
