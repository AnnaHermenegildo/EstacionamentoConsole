namespace EstacionamentoConsole.Models
{

    public abstract class Vaga
    {
        public bool Ocupada { get; private set; } = false;

        public Veiculo? VeiculoEstacionado { get; private set; }

        public void Ocupar(Veiculo veiculo)
        {
            VeiculoEstacionado = veiculo;
            Ocupada = true;
        }

        public void Liberar(Veiculo veiculo)
        {
            VeiculoEstacionado = null;
            Ocupada = false;
        }

        protected abstract bool Aceita(Veiculo veiculo);
    }
}
