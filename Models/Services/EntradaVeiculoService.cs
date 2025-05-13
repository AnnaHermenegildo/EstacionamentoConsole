namespace EstacionamentoConsole.Models.Services
{
    public class EntradaVeiculoService
    {
        private readonly Estacionamento _estacionamento;

        public EntradaVeiculoService(Estacionamento estacionamento)
        {
            _estacionamento = estacionamento;
        }

        public void RegistrarEntradaVeiculo(Veiculo veiculo)
        {
            // Chama o serviço de estacionamento para registrar a entrada
            var resultado = _estacionamento.RegistrarEntrada(veiculo);

            // Verifica o resultado
            if (resultado.Sucesso)
                Console.WriteLine($"Sucesso: {resultado.Mensagem}");
            else
                Console.WriteLine($"Erro: {resultado.Mensagem}");   
        }
    }
}
