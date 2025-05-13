using EstacionamentoConsole.Models.Response;

namespace EstacionamentoConsole.Models
{
    public class Estacionamento
    {
        private readonly List<Vaga> _vagas;

        public Estacionamento(List<Vaga> vagas)
        {
            _vagas = vagas ?? new List<Vaga>();
            // Teste
            _vagas.Add(new VagaCarro());
            _vagas.Add(new VagaMoto());
        }

        public ResultadoEntrada RegistrarEntrada(Veiculo veiculo)
        {
            var vagaDisponivel = ObterVagaDisponivel(veiculo);

            if (vagaDisponivel == null)
                return new ResultadoEntrada()
                {
                    Sucesso = false,
                    Mensagem = "Não há vaga disponível para este tipo de veículo."
                }; 

            vagaDisponivel.Ocupar(veiculo);

            return new ResultadoEntrada()
            {
                Sucesso = true,
                Mensagem = "Veículo adicionado à vaga com sucesso."
            };
        }

        public void RegistrarSaida(string placa)
        {
            var vaga = _vagas.FirstOrDefault(v => v.Ocupada && v.VeiculoEstacionado?.Placa == placa);
            if (vaga == null)
                throw new InvalidOperationException("Veículo não encontrado.");

            vaga.Liberar();
        }

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
    }

}
