namespace EstacionamentoConsole.Models.Factory
{
    //  **Princípio aplicado: SRP (Single Responsibility Principle)**
    //  *Nome*: Princípio da Responsabilidade Única
    //  *Objetivo*: Uma classe deve ter uma única razão para mudar.

    //  *Explicação*:
    // A classe `VeiculoFactory` tem apenas uma responsabilidade: criar instâncias de veículos.
    // Toda a lógica de criação está encapsulada aqui, e se mudar, será apenas para alterar o processo de construção.

    //  **Padrão GRASP: Creator**
    //  *Nome*: Creator
    //  *Objetivo*: Atribui a responsabilidade de criação de um objeto à classe que possui as informações necessárias para isso.

    // *Explicação*:
    // `VeiculoFactory` recebe os dados necessários (tipo, placa, marca, modelo, cor) e com base neles **cria o objeto certo**.

    public static class VeiculoFactory
    {
        //  **Princípio aplicado: OCP (Open/Closed Principle)**
        //  *Nome*: Aberto para extensão, fechado para modificação
        //  *Objetivo*: Adicionar novos tipos de veículos sem modificar o restante do código de consumo.

        //  *Explicação*:
        // Para adicionar um novo tipo de veículo (ex: Caminhao), basta estender o `switch`, sem alterar quem usa a factory.
        // O código consumidor não muda — a lógica de decisão está isolada aqui.

        public static Veiculo CriarVeiculo(string tipo, string placa, string marca, string modelo, string cor)
        {
            //  **Princípio aplicado: DIP (Dependency Inversion Principle)**
            //  *Nome*: Princípio da Inversão de Dependência
            //  *Objetivo*: Depender de abstrações, não de implementações concretas.

            //  *Explicação*:
            // Este método retorna um `Veiculo`, que é uma abstração. Quem consome o resultado não precisa saber se é `Carro` ou `Moto`.

            return tipo.ToLower() switch
            {
                "carro" => new Carro(placa, marca, modelo, cor),
                "moto" => new Moto(placa, marca, modelo, cor),
                _ => throw new ArgumentException("Tipo de veículo inválido.") // Validação coesa dentro da fábrica
            };
        }
    }
}
