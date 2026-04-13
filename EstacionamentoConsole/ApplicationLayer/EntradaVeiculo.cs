using EstacionamentoConsole.Models;
using EstacionamentoConsole.Models.DTOs;
using EstacionamentoConsole.Models.Factory;
using EstacionamentoConsole.Models.Services;
using System.Text.RegularExpressions;

namespace EstacionamentoConsole.ApplicationLayer
{


    public class EntradaVeiculo
    {
        private readonly EstacionamentoService _entradaService;

        public EntradaVeiculo(EstacionamentoService entradaService)
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
