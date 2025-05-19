using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoConsole.Models.Response
{
    // Princípio aplicado: SRP (Single Responsibility Principle)
    // Nome: Princípio da Responsabilidade Única
    // Objetivo: Esta classe tem a única responsabilidade de encapsular o resultado de uma operação de entrada,
    // contendo se foi bem-sucedida ou não, e uma mensagem descritiva.
    // Explicação: Ela não executa lógica, apenas transporta o resultado do processo para quem chamou.

    // Conceito aplicado: DDD - Value Object (Objeto de Valor)
    // Objetivo: Representar um resultado imutável ou que encapsula informações que agregam significado à operação,
    // facilitando a comunicação entre camadas sem expor detalhes internos.

    public class Resultado
    {
        // Indica se a operação foi concluída com sucesso
        public bool Sucesso { get; set; }

        // Mensagem descritiva que pode conter erros ou confirmação
        public string Mensagem { get; set; }
    }
}
