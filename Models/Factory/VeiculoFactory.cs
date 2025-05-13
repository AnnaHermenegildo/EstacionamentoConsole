namespace EstacionamentoConsole.Models.Factory
{
    public static class VeiculoFactory
    {
        public static Veiculo CriarVeiculo(string tipo, string placa, string marca, string modelo, string cor)
        {
            return tipo.ToLower() switch
            {
                "carro" => new Carro(placa, marca, modelo, cor),
                "moto" => new Moto(placa, marca, modelo, cor),
                _ => throw new ArgumentException("Tipo de veículo inválido.")
            };
        }
    }

}
