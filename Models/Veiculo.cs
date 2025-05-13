namespace EstacionamentoConsole.Models
{
    // a classe veiculo foi feita como abstract para servir como modelo para as subclasses carro e moto
    public abstract class Veiculo
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Placa { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Cor { get; set; }
    }
}
