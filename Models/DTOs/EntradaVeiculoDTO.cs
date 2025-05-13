namespace EstacionamentoConsole.Models.DTOs
{
    public class EntradaVeiculoDTO
    {
        public EntradaVeiculoDTO(string tipo, string placa, string marca, string modelo, string cor)
        {
            Tipo = tipo;
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
        }

        public string Tipo { get; set; } // "carro" ou "moto"
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
    }

}
