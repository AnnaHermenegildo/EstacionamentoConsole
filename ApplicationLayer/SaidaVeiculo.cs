using EstacionamentoConsole.Models.DTOs;
using EstacionamentoConsole.Models.Factory;
using EstacionamentoConsole.Models.Services;

namespace EstacionamentoConsole.ApplicationLayer
{
    // Princípio aplicado: SRP (Single Responsibility Principle)
    // Nome: Princípio da Responsabilidade Única
    // Objetivo: A classe é responsável apenas por coordenar a saída de um veículo na aplicação.
    // Explicação: Ela não contém lógica de domínio, apenas prepara os dados e delega responsabilidades.

    // Padrão aplicado: DDD - Application Layer
    // Objetivo: Esta classe representa a camada de aplicação que orquestra o uso do serviço de domínio,
    // sem conter lógica de negócio, apenas conectando DTOs com a lógica de serviço.

    // Padrão aplicado: GRASP - Controller
    // Objetivo: Atribuir a responsabilidade de controlar o fluxo de saída de dados da aplicação.
    // Explicação: Essa classe atua como um coordenador de ações da aplicação, recebendo um DTO e acionando os serviços apropriados.

    public class SaidaVeiculo
    {
        private readonly EstacionamentoService _estacionamentoService;

        // Injeção de dependência do serviço de estacionamento (DIP)
        public SaidaVeiculo(EstacionamentoService estacionamentoService)
        {
            _estacionamentoService = estacionamentoService;
        }

        // Método responsável por orquestrar a saída do veículo
        public void RegistrarSaida(SaidaVeiculoDTO saidaVeiculoDTO)
        {

            // Delegação da responsabilidade de registrar a saída ao serviço de domínio
            _estacionamentoService.RegistrarSaidaVeiculo(saidaVeiculoDTO.Placa);
        }
    }
}
