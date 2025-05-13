namespace EstacionamentoConsole.Models
{
    public class VagaCarro : Vaga
    {
        protected override bool Aceita(Veiculo veiculo)
            => veiculo is Carro;
    }
}
