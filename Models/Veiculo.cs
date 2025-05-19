using System.Drawing;
using System.Text.RegularExpressions;

namespace EstacionamentoConsole.Models
{
    //  **Princípio aplicado: SRP (Single Responsibility Principle)**
    //  *Nome*: Princípio da Responsabilidade Única
    //  *Objetivo*: Cada classe deve ter uma única razão para mudar.

    //  *Explicação*:
    // A classe `Veiculo` possui apenas a responsabilidade de representar os dados básicos de um veículo. 
    // Ela não lida com lógica de estacionamento, regras de negócio ou persistência.

    //  **Padrão aplicado: High Cohesion**
    //  *Nome*: Alta Coesão
    //  *Objetivo*: Manter os comportamentos fortemente relacionados juntos dentro da mesma classe.

    //  *Explicação*:
    // Todos os atributos aqui (Placa, Marca, Modelo, Cor) estão relacionados ao conceito de um veículo.
    // A classe é **coesa**, pois concentra apenas propriedades essenciais de um veículo.

    // A classe veiculo foi feita como abstract para servir como modelo para as subclasses carro e moto
    public abstract class Veiculo
    {
        private static readonly Regex _regex = new Regex(
            @"^(?:[A-Z]{3}[0-9]{4}|[A-Z]{3}[0-9][A-Z0-9][0-9]{2})$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );

        public Guid Id { get; set; } = Guid.NewGuid(); // Geração de identificador único para o veículo

        public string Placa { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Cor { get; set; }

        protected Veiculo(string placa, string marca, string modelo, string cor)
        {
            if (string.IsNullOrWhiteSpace(placa))
                throw new ArgumentException("A placa não pode ser vazia.");


            if (string.IsNullOrWhiteSpace(placa) || placa.Length > 7)
                throw new ArgumentException("Placa inválida.");

            if (!_regex.IsMatch(placa))
                throw new ArgumentException("Placa em formato inválido.");

            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
        }
    }
}
