namespace EstacionamentoConsole.Models
{
    public abstract class Vaga
    {
        public bool Ocupada { get; private set; } = false;
        public Veiculo? VeiculoEstacionado { get; private set; }

        public void Ocupar(Veiculo veiculo)
        {
            if (Ocupada)
                throw new InvalidOperationException("Vaga já está ocupada.");

            if (!Aceita(veiculo))
                throw new ArgumentException("Veículo incompatível com o tipo da vaga.");

            VeiculoEstacionado = veiculo;
            Ocupada = true;
        }

        public void Liberar()
        {
            VeiculoEstacionado = null;
            Ocupada = false;
        }

        protected abstract bool Aceita(Veiculo veiculo);
    }

}
