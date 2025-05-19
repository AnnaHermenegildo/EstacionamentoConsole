using EstacionamentoConsole.Models.Response;
using EstacionamentoConsole.Models;

namespace EstacionamentoConsole.Interfaces
{
    //  Princípio aplicado: ISP (Interface Segregation Principle)
    //  Nome: Princípio da Segregação de Interface
    //  Objetivo: Interfaces devem ser específicas e não forçar a implementação de métodos desnecessários.
    //
    //  Explicação:
    //  A interface IEstacionamento define apenas os contratos relevantes à gestão do estacionamento,
    //  evitando incluir responsabilidades que não fazem parte da lógica de domínio da agregação de vagas.

    //  Conceito aplicado: DDD - Abstração do Agregado Raiz
    //  Objetivo: Expõe apenas os comportamentos necessários do agregado raiz (Estacionamento).
    //
    //  Explicação:
    //  A interface representa as ações que podem ser realizadas no agregado Estacionamento, sem expor seus detalhes internos.
    public interface IEstacionamento
    {
        // Princípio aplicado: SRP (Single Responsibility Principle)
        // Explicação:
        // Cada método tem uma responsabilidade única e clara, voltada a ações do domínio.

        // Método responsável por registrar a entrada de um veículo em uma vaga específica.
        public void RegistrarEntrada(Veiculo veiculo, Vaga vaga);

        // Método responsável por registrar a saída de um veículo com base na placa.
        public void RegistrarSaida(Veiculo placa, Vaga vaga);

        // Método que retorna uma vaga disponível com base no tipo de veículo (Carro ou Moto).
        public Vaga? ObterVagaDisponivel(Veiculo veiculo);

        public Vaga? RetornaVagaPorPlaca(Veiculo placa);

        // método que retorna os veiculos estacionados
        IEnumerable<(string Tipo, Veiculo Veiculo)> ListarVeiculosEstacionados();


        // Retorna o número de vagas disponíveis para carros.
        public int VagasDisponiveisParaCarro();

        // Retorna o número de vagas disponíveis para motos.
        public int VagasDisponiveisParaMoto();
    }
}
