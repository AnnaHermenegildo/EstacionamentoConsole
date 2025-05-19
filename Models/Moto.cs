namespace EstacionamentoConsole.Models
{
    // Mesmos principios de `Carro` também se aplica aqui: SRP, OCP, Low Coupling e High Cohesion.
    // A classe `Moto` estende `Veiculo`, mantendo alta coesão e responsabilidade única.

    public class Moto : Veiculo
    {
        public Moto(string placa, string marca, string modelo, string cor)
       : base(placa, marca, modelo, cor)
        {
        }
    }
}
