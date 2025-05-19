namespace EstacionamentoConsole.Models
{
    // Princípio aplicado: OCP (Open/Closed Principle)
    // Nome: Princípio Aberto/Fechado
    // Objetivo: A classe VagaCarro estende Vaga e implementa o método Aceita para aceitar apenas veículos do tipo Carro.
    // Explicação: A classe pode ser estendida sem modificar a base, respeitando a extensão por especialização.

    // Padrão GRASP: Expert
    // Objetivo: VagaCarro é especialista em aceitar somente veículos do tipo Carro,
    // mantendo alta coesão e baixa dependência de outras classes.

    public class VagaCarro : Vaga
    {
        // Implementa o critério para aceitar somente veículos do tipo Carro
        protected override bool Aceita(Veiculo veiculo)
            => veiculo is Carro;
    }
}
