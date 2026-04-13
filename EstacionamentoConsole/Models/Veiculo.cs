using System.Drawing;
using System.Text.RegularExpressions;

namespace EstacionamentoConsole.Models
{ 
    public abstract class Veiculo
    {
        private static readonly Regex _regex = new Regex(
            @"^(?:[A-Z]{3}[0-9]{4}|[A-Z]{3}[0-9][A-Z0-9][0-9]{2})$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase
        );

        public Guid Id { get; set; } = Guid.NewGuid(); 

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
