using EstacionamentoConsole.Models.DTOs;
using EstacionamentoConsole.Models.Factory;
using EstacionamentoConsole.Models.Services;

namespace EstacionamentoConsole.ApplicationLayer
{
    public class EntradaVeiculo
    {
        private readonly EntradaVeiculoService _entradaService;

        public EntradaVeiculo(EntradaVeiculoService entradaService)
        {
            _entradaService = entradaService;
        }

        public void Entrada(EntradaVeiculoDTO entradaVeiculoDTO)
        {
            var veiculo = VeiculoFactory.CriarVeiculo(
                entradaVeiculoDTO.Tipo,
                entradaVeiculoDTO.Placa,
                entradaVeiculoDTO.Marca,
                entradaVeiculoDTO.Modelo,
                entradaVeiculoDTO.Cor);

            _entradaService.RegistrarEntradaVeiculo(veiculo);
        }
    }
}
