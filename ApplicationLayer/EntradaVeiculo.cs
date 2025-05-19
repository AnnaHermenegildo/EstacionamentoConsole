using EstacionamentoConsole.Models;
using EstacionamentoConsole.Models.DTOs;
using EstacionamentoConsole.Models.Factory;
using EstacionamentoConsole.Models.Services;
using System.Text.RegularExpressions;

namespace EstacionamentoConsole.ApplicationLayer
{
    // Princípio aplicado: SRP (Single Responsibility Principle)
    // Nome: Princípio da Responsabilidade Única
    // Objetivo: A classe é responsável apenas por coordenar a entrada de um veículo na aplicação.
    // Explicação: Ela não contém lógica de domínio, apenas prepara os dados e delega responsabilidades.

    // Padrão aplicado: DDD - Application Layer
    // Objetivo: Esta classe representa a camada de aplicação que orquestra o uso do serviço de domínio,
    // sem conter lógica de negócio, apenas conectando DTOs com a lógica de serviço.

    // Padrão aplicado: GRASP - Controller
    // Objetivo: Atribuir a responsabilidade de controlar o fluxo de entrada de dados da aplicação.
    // Explicação: Essa classe atua como um coordenador de ações da aplicação, recebendo um DTO e acionando os serviços apropriados.

    public class EntradaVeiculo
    {
        private readonly EstacionamentoService _entradaService;

        // Injeção de dependência do serviço de estacionamento (DIP)
        public EntradaVeiculo(EstacionamentoService entradaService)
        {
            _entradaService = entradaService;
        }
     
        // Método responsável por orquestrar a entrada do veículo
        public void Entrada(EntradaVeiculoDTO entradaVeiculoDTO)
        {


            // Fábrica usada para criar o veículo a partir do DTO
            // Princípio aplicado: OCP (Open/Closed Principle)
            // Objetivo: A classe VeiculoFactory está fechada para modificação e aberta para extensão.
            var veiculo = VeiculoFactory.CriarVeiculo(
                entradaVeiculoDTO.Tipo,
                entradaVeiculoDTO.Placa,
                entradaVeiculoDTO.Marca,
                entradaVeiculoDTO.Modelo,
                entradaVeiculoDTO.Cor);

            // Delegação da responsabilidade de registrar a entrada ao serviço de domínio
            _entradaService.RegistrarEntradaVeiculo(veiculo);
        }
    }
}
