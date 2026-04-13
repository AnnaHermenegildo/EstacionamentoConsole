using EstacionamentoConsole.Models.DTOs;
using EstacionamentoConsole.Models.Factory;
using EstacionamentoConsole.Models.Services;

namespace EstacionamentoConsole.ApplicationLayer
{


    public class SaidaVeiculo
    {
        private readonly EstacionamentoService _estacionamentoService;

        public SaidaVeiculo(EstacionamentoService estacionamentoService)
        {
            _estacionamentoService = estacionamentoService;
        }

        public void RegistrarSaida(SaidaVeiculoDTO saidaVeiculoDTO)
        {

            if (string.IsNullOrEmpty(saidaVeiculoDTO.Placa))
                throw new ArgumentException("A placa é obrigatória e não pode ser vazia.");
            

            _estacionamentoService.RegistrarSaidaVeiculo(saidaVeiculoDTO.Placa);
        }
    }
}
