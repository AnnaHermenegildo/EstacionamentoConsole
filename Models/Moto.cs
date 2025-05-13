namespace EstacionamentoConsole.Models
{
    public class Moto : Veiculo
    {
        public Moto(string placa, string marca, string modelo, string cor)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
        }
    }
}
