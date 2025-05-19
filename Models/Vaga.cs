namespace EstacionamentoConsole.Models
{
    // Princípio aplicado: SRP (Single Responsibility Principle)
    // Nome: Princípio da Responsabilidade Única
    // Objetivo: A classe Vaga tem a única responsabilidade de gerenciar o estado da vaga,
    // controlando se está ocupada, qual veículo está nela, e se aceita determinado veículo.
    // Explicação: Ela não lida com regras externas, apenas o comportamento próprio da vaga.

    // Princípio aplicado: OCP (Open/Closed Principle)
    // Nome: Princípio Aberto/Fechado
    // Objetivo: O método abstrato Aceita() obriga subclasses a definirem critérios para aceitar veículos,
    // permitindo a extensão sem modificar a classe base.

    // Padrão GRASP: Expert
    // Objetivo: A classe Vaga é expert na informação sobre sua ocupação e aceitação de veículos,
    // por isso é a responsável pelas operações relacionadas a isso.

    public abstract class Vaga
    {
        // Indica se a vaga está ocupada, encapsulado com setter privado para evitar alterações externas indevidas
        public bool Ocupada { get; private set; } = false;

        // Referência para o veículo atualmente estacionado na vaga, se houver
        public Veiculo? VeiculoEstacionado { get; private set; }

        // Marca a vaga como ocupada por um veículo específico
        public void Ocupar(Veiculo veiculo)
        {
            VeiculoEstacionado = veiculo;
            Ocupada = true;
        }

        // Libera a vaga, removendo o veículo e marcando como desocupada
        public void Liberar(Veiculo veiculo)
        {
            VeiculoEstacionado = null;
            Ocupada = false;
        }

        // Método abstrato para subclasses definirem critérios específicos de aceitação do veículo
        protected abstract bool Aceita(Veiculo veiculo);
    }
}
