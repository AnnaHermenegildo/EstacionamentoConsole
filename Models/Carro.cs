namespace EstacionamentoConsole.Models
{
    //  **Princípio aplicado: OCP (Open/Closed Principle)**
    //  *Nome*: Princípio Aberto/Fechado
    //  *Objetivo*: Classes devem estar abertas para extensão, mas fechadas para modificação.

    //  *Explicação*:
    // A classe `Carro` **estende** `Veiculo` para adicionar comportamento específico, sem alterar `Veiculo`.
    // Isso permite que novos tipos de veículos (como `Moto`, `Caminhao`, etc.) sejam adicionados no futuro
    // **sem modificar a classe base**.

    //  **Padrão aplicado: Low Coupling**
    //  *Nome*: Baixo Acoplamento
    //  *Objetivo*: Reduzir dependências diretas entre as classes.

    // *Explicação*:
    // `Carro` depende apenas da abstração `Veiculo`, o que reduz o acoplamento com o restante do sistema.
    public class Carro : Veiculo
    {

            public Carro(string placa, string marca, string modelo, string cor)
                : base(placa, marca, modelo, cor)
            {
            }

    }
}
