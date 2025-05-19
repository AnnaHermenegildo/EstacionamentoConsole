# EstacionamentoConsole

Projeto Estacionamento Console — Modelagem de Domínio 

Introdução
A cidade de Praia Grande enfrenta um problema recorrente de falta de organização nos estacionamentos de pequenos centros comerciais. Em especial, o estacionamento da galeria “Pátio Praia” — com capacidade reduzida — não possui controle automatizado sobre vagas disponíveis, veículos estacionados e seu histórico de entrada e saída. Com o objetivo de resolver esse problema, foi projetado um sistema simples, baseado em Console, para realizar o controle de entrada e saída de veículos, utilizando os princípios da modelagem orientada ao domínio (Domain-Driven Design - DDD).

Cenário do Domínio
O estacionamento possui 5 vagas no total: 3 destinadas a carros e 2 a motos. Os veículos que entram devem informar placa, marca, modelo, cor e tipo (carro ou moto). Ao entrar, o sistema registra o veiculo e ocupa uma vaga. Quando o veículo sai, o sistema libera a vaga e registra a saída.

O domínio foi cuidadosamente modelado para refletir a realidade do negócio, usando Linguagem Ubíqua (Ubiquitous Language) com os termos: Veículo, Vaga, Estacionamento, Entrada, Saída, Placa, Tipo, entre outros.

Escopo e Problema a Ser Resolvido
Controlar a ocupação de vagas por tipo de veículo.

Garantir que não sejam registradas entradas para veículos com placas inválidas (seguindo padrões Mercosul e antigo).

Impedir que veículos entrem se não houver vaga disponível para seu tipo.

Manter o sistema desacoplado, seguindo boas práticas de DDD, SOLID e GRASP.

Modelagem de Domínio com DDD
1. Entidades
Veículo: Entidade principal, identificada unicamente pela placa. É especializada em subtipos como Carro e Moto.

Vaga: Entidade que representa uma posição no estacionamento. Associada a um tipo (Carro ou Moto) e pode ou não estar ocupada.

Estacionamento: Agregado raiz que contém as vagas e é responsável por orquestrar entradas e saídas de veículos.

2. Value Objects
Placa: Implementada como string validada, mas poderia evoluir para um Value Object com regras encapsuladas de validação.

3. Repositórios
IVeiculoRepository (fictício): Em versões futuras, permitirá persistência e consulta dos veículos estacionados. Neste projeto Console, é substituído por uma estrutura em memória.

4. Aggregates
Estacionamento: É o Agregado Raiz que coordena o ciclo de vida das Vagas e mantém consistência de negócio. Toda manipulação de veículos e vagas passa por ele.

5. Bounded Contexts
Neste projeto, todo o domínio está contido em um único Bounded Context chamado Estacionamento.

Futuramente, o sistema pode se integrar a um contexto externo, como Faturamento ou Controle de Multas, usando Anti-Corruption Layer (ACL) para traduzir dados e proteger o modelo.

6. Domain Services
EntradaService e SaidaService: Serviços de domínio que encapsulam regras de negócio que não pertencem a uma entidade específica, como encontrar uma vaga disponível para o tipo do veículo.

7. Factories
VeiculoFactory: Responsável por instanciar corretamente os objetos Carro ou Moto com base nos dados fornecidos, aplicando o padrão GRASP Creator.
VagaFactory: Responsável por instanciar corretamente os objetos Carro ou Moto com base nas delimitações do espaço fisico, aplicando o padrão GRASP Creator.


8. Padrões de Integração entre Contextos
Anti-Corruption Layer: Ainda não implementado, mas previsto para proteger o domínio em futuras integrações com sistemas externos.

Context Map: Previsto para documentação futura das interações entre o contexto Estacionamento e demais contextos.

Conclusão
Este projeto demonstra como uma aplicação simples pode ser modelada com os conceitos e boas práticas de Domain-Driven Design. O domínio do estacionamento, apesar de pequeno, foi cuidadosamente isolado, respeitando entidades, serviços, regras e limites bem definidos. Essa abordagem torna o sistema flexível, testável e aberto para evolução com segurança.