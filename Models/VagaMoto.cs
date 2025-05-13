namespace EstacionamentoConsole.Models
{
    internal class VagaMoto : Vaga
    {
        protected override bool Aceita(Veiculo veiculo)
            => veiculo is Moto;
    }
}
