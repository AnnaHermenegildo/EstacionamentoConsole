using EstacionamentoConsole.Interfaces;
using EstacionamentoConsole.Models.Factory;

namespace EstacionamentoConsole.Models
{
    //  **Princípio aplicado: SRP (Single Responsibility Principle)**
    //  *Nome*: Princípio da Responsabilidade Única
    //  *Objetivo*: Cada classe deve ter uma única razão para mudar.
    //
    //  *Explicação*:
    //  A classe Estacionamento encapsula toda a lógica relacionada à gestão de vagas e controle de entrada/saída de veículos.
    //  Não trata da criação de veículos, detalhes da vaga ou persistência, mantendo o foco único em regras do domínio.

    //  **Padrão aplicado: GRASP - Controller**
    //  *Nome*: Controlador
    //  *Objetivo*: Delegar a responsabilidade de coordenar ações para uma classe especializada no domínio.
    //
    //  *Explicação*:
    //  A classe Estacionamento coordena a entrada e saída de veículos, atua como uma controladora das operações do domínio.

    //  **Conceito aplicado: DDD - Agregado Raiz**
    //  *Nome*: Aggregateroot
    //  *Objetivo*: Ser a entrada principal para modificar o estado de um conjunto coeso de entidades.
    //
    //  *Explicação*:
    //  O Estacionamento é o ponto central de acesso ao conjunto de Vagas, garantindo regras de integridade.
    public class Estacionamento : IEstacionamento
    {
        private readonly List<Vaga> _vagas;

        public Estacionamento(int totalCarros, int totalMotos)
        {
            //  **Princípio aplicado: DIP (Dependency Inversion Principle)**
            //  *Nome*: Princípio da Inversão de Dependência
            //  *Objetivo*: Depender de abstrações e não de implementações concretas.
            //
            //  *Explicação*:
            //  A criação de vagas é delegada à VagaFactory, evitando que a classe Estacionamento dependa de implementações concretas.
            _vagas = VagaFactory.CriarVagas(totalCarros, totalMotos);
        }

        public void RegistrarEntrada(Veiculo veiculo, Vaga vaga)
        {
            //  **Princípio aplicado: SRP e Delegation (GRASP)**
            //  *Objetivo*: Delegar responsabilidade específica para classes que conhecem o contexto.
            //
            //  *Explicação*:
            //  A lógica de ocupar uma vaga é delegada à própria classe Vaga, mantendo o Estacionamento focado na orquestração.
            vaga.Ocupar(veiculo);
        }

        public void RegistrarSaida(Veiculo veiculo, Vaga vaga)
        {
            //  **Padrão aplicado: GRASP - Information Expert**
            //  *Nome*: Especialista da Informação
            //  *Objetivo*: Atribuir responsabilidades à classe que possui a informação necessária.
            //
            //  *Explicação*:
            //  O Estacionamento conhece todas as vagas e pode, portanto, buscar uma vaga ocupada por determinada placa.
            vaga.Liberar(veiculo);
        }

        //  **Padrão aplicado: High Cohesion**
        //  *Objetivo*: Manter funcionalidades relacionadas no mesmo lugar.
        //
        //  *Explicação*:
        //  O TotalVagas está diretamente ligado à responsabilidade de controle de vagas do estacionamento.
        public int TotalVagas => _vagas.Count;

        public int VagasDisponiveisParaCarro()
            => _vagas.OfType<VagaCarro>().Count(v => !v.Ocupada);

        public int VagasDisponiveisParaMoto()
            => _vagas.OfType<VagaMoto>().Count(v => !v.Ocupada);

        public Vaga? ObterVagaDisponivel(Veiculo veiculo)
        {
            //  **Princípio aplicado: OCP (Open/Closed Principle)**
            //  *Nome*: Aberto para extensão, fechado para modificação
            //  *Objetivo*: Permitir que comportamentos sejam estendidos sem modificar código existente.
            //
            //  *Explicação*:
            //  O uso de pattern matching com tipos permite tratar novos tipos de veículo no futuro,
            //  apenas estendendo o switch, sem alterar o comportamento das demais partes.
            return veiculo switch
            {
                Carro => _vagas.OfType<VagaCarro>().FirstOrDefault(v => !v.Ocupada),
                Moto => _vagas.OfType<VagaMoto>().FirstOrDefault(v => !v.Ocupada),
                _ => throw new InvalidOperationException("Tipo de veículo desconhecido.")
            };
        }

        public IEnumerable<(string Tipo, Veiculo Veiculo)> ListarVeiculosEstacionados()
        {
            return _vagas
                .Where(v => v.Ocupada && v.VeiculoEstacionado != null)
                .Select(v =>
                {
                    var tipo = v switch
                    {
                        VagaCarro => "Carro",
                        VagaMoto => "Moto",
                        _ => "Desconhecido"
                    };

                    return (tipo, v.VeiculoEstacionado!);
                });
        }


        public Vaga? RetornaVagaPorPlaca(Veiculo veiculo)
        {
            return _vagas.Where(x => x.VeiculoEstacionado == veiculo).FirstOrDefault();
        }
    }
}
