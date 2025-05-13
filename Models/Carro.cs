namespace EstacionamentoConsole.Models
{
    public class Carro : Veiculo
    {
        public Carro(string placa, string marca, string modelo, string cor)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
        }
    }
}
