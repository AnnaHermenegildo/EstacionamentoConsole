# EstacionamentoConsole

Projeto Estacionamento Console � Modelagem de Dom�nio 

Introdu��o
A cidade de Praia Grande enfrenta um problema recorrente de falta de organiza��o nos estacionamentos de pequenos centros comerciais. Em especial, o estacionamento da galeria �P�tio Praia� � com capacidade reduzida � n�o possui controle automatizado sobre vagas dispon�veis, ve�culos estacionados e seu hist�rico de entrada e sa�da. Com o objetivo de resolver esse problema, foi projetado um sistema simples, baseado em Console, para realizar o controle de entrada e sa�da de ve�culos, utilizando os princ�pios da modelagem orientada ao dom�nio (Domain-Driven Design - DDD).

Cen�rio do Dom�nio
O estacionamento possui 5 vagas no total: 3 destinadas a carros e 2 a motos. Os ve�culos que entram devem informar placa, marca, modelo, cor e tipo (carro ou moto). Ao entrar, o sistema registra o veiculo e ocupa uma vaga. Quando o ve�culo sai, o sistema libera a vaga e registra a sa�da.

O dom�nio foi cuidadosamente modelado para refletir a realidade do neg�cio, usando Linguagem Ub�qua (Ubiquitous Language) com os termos: Ve�culo, Vaga, Estacionamento, Entrada, Sa�da, Placa, Tipo, entre outros.

Escopo e Problema a Ser Resolvido
Controlar a ocupa��o de vagas por tipo de ve�culo.

Garantir que n�o sejam registradas entradas para ve�culos com placas inv�lidas (seguindo padr�es Mercosul e antigo).

Impedir que ve�culos entrem se n�o houver vaga dispon�vel para seu tipo.

Manter o sistema desacoplado, seguindo boas pr�ticas de DDD, SOLID e GRASP.

Modelagem de Dom�nio com DDD
1. Entidades
Ve�culo: Entidade principal, identificada unicamente pela placa. � especializada em subtipos como Carro e Moto.

Vaga: Entidade que representa uma posi��o no estacionamento. Associada a um tipo (Carro ou Moto) e pode ou n�o estar ocupada.

Estacionamento: Agregado raiz que cont�m as vagas e � respons�vel por orquestrar entradas e sa�das de ve�culos.

2. Value Objects
Placa: Implementada como string validada, mas poderia evoluir para um Value Object com regras encapsuladas de valida��o.

3. Reposit�rios
IVeiculoRepository (fict�cio): Em vers�es futuras, permitir� persist�ncia e consulta dos ve�culos estacionados. Neste projeto Console, � substitu�do por uma estrutura em mem�ria.

4. Aggregates
Estacionamento: � o Agregado Raiz que coordena o ciclo de vida das Vagas e mant�m consist�ncia de neg�cio. Toda manipula��o de ve�culos e vagas passa por ele.

5. Bounded Contexts
Neste projeto, todo o dom�nio est� contido em um �nico Bounded Context chamado Estacionamento.

Futuramente, o sistema pode se integrar a um contexto externo, como Faturamento ou Controle de Multas, usando Anti-Corruption Layer (ACL) para traduzir dados e proteger o modelo.

6. Domain Services
EntradaService e SaidaService: Servi�os de dom�nio que encapsulam regras de neg�cio que n�o pertencem a uma entidade espec�fica, como encontrar uma vaga dispon�vel para o tipo do ve�culo.

7. Factories
VeiculoFactory: Respons�vel por instanciar corretamente os objetos Carro ou Moto com base nos dados fornecidos, aplicando o padr�o GRASP Creator.
VagaFactory: Respons�vel por instanciar corretamente os objetos Carro ou Moto com base nas delimita��es do espa�o fisico, aplicando o padr�o GRASP Creator.


8. Padr�es de Integra��o entre Contextos
Anti-Corruption Layer: Ainda n�o implementado, mas previsto para proteger o dom�nio em futuras integra��es com sistemas externos.

Context Map: Previsto para documenta��o futura das intera��es entre o contexto Estacionamento e demais contextos.

Conclus�o
Este projeto demonstra como uma aplica��o simples pode ser modelada com os conceitos e boas pr�ticas de Domain-Driven Design. O dom�nio do estacionamento, apesar de pequeno, foi cuidadosamente isolado, respeitando entidades, servi�os, regras e limites bem definidos. Essa abordagem torna o sistema flex�vel, test�vel e aberto para evolu��o com seguran�a.