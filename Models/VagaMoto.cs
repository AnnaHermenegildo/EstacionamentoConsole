namespace EstacionamentoConsole.Models
{
    // Princípio aplicado: OCP (Open/Closed Principle)
    // Nome: Princípio Aberto/Fechado
    // Objetivo: A classe VagaMoto estende Vaga e implementa o método Aceita para aceitar apenas veículos do tipo Moto.
    // Explicação: Segue o princípio de extensão sem modificação da classe base.

    // Padrão GRASP: Expert
    // Objetivo: VagaMoto é especialista em aceitar somente veículos do tipo Moto,
    // garantindo coesão e responsabilidade clara.

    internal class VagaMoto : Vaga
    {
        // Implementa o critério para aceitar somente veículos do tipo Moto
        protected override bool Aceita(Veiculo veiculo)
            => veiculo is Moto;
    }
}
