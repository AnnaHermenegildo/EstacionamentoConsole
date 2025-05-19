namespace EstacionamentoConsole.Models.DTOs
{
    // Princípio aplicado: SRP (Single Responsibility Principle)
    // Nome: Princípio da Responsabilidade Única
    // Objetivo: Esta classe tem a única responsabilidade de transportar dados referentes à entrada do veículo.
    // Explicação: O DTO serve apenas para transportar dados entre camadas, sem conter lógica de negócio.

    // Conceito aplicado: DDD - Data Transfer Object (DTO)
    // Objetivo: Facilitar a comunicação entre camadas da aplicação, isolando a estrutura dos dados do domínio.

    public class EntradaVeiculoDTO
    {
        // Construtor que inicializa as propriedades do DTO
        public EntradaVeiculoDTO(string tipo, string placa, string marca, string modelo, string cor)
        {
            Tipo = tipo;
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
        }

        // Tipo do veículo: esperado "carro" ou "moto"
        public string Tipo { get; set; }

        // Propriedades básicas do veículo necessárias para a entrada no estacionamento
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
    }
}
