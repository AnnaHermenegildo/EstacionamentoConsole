using NUnit.Framework;
using EstacionamentoConsole.Models;

namespace Estacionamento.Tests
{
    [TestFixture]
    public class EstacionamentoServiceTests
    {
        [Test]
        public void Deve_Registrar_Entrada_De_Veiculo()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(5, 5);
            var veiculo = new Carro("ABC1234", "Toyota", "Corolla", "Prata");
            var vaga = estacionamento.ObterVagaDisponivel(veiculo);

            Assert.That(vaga, Is.Not.Null);

            estacionamento.RegistrarEntrada(veiculo, vaga!);

            Assert.That(vaga!.Ocupada, Is.True);
        }

        [Test]
        public void Deve_Liberar_Vaga_Ao_Registrar_Saida()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(5, 5);
            var veiculo = new Carro("ABC1234", "Toyota", "Corolla", "Prata");
            var vaga = estacionamento.ObterVagaDisponivel(veiculo);

            Assert.That(vaga, Is.Not.Null);
            estacionamento.RegistrarEntrada(veiculo, vaga!);

            estacionamento.RegistrarSaida(veiculo, vaga!);

            Assert.That(vaga!.Ocupada, Is.False);
        }

        [Test]
        public void Deve_Retornar_Vagas_Disponiveis_Para_Carro()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(2, 0);

            var vagas = estacionamento.VagasDisponiveisParaCarro();

            Assert.That(vagas, Is.EqualTo(2));
        }

        [Test]
        public void Deve_Obter_Vaga_Disponivel()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(1, 0);
            var veiculo = new Carro("ABC1234", "Toyota", "Corolla", "Prata");

            var vaga = estacionamento.ObterVagaDisponivel(veiculo);

            Assert.That(vaga, Is.Not.Null);
        }

        [Test]
        public void Deve_Diminuir_Quantidade_De_Vagas_De_Carro_Apos_Entrada()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(2, 0);
            var veiculo = new Carro("ABC1234", "Toyota", "Corolla", "Prata");
            var vaga = estacionamento.ObterVagaDisponivel(veiculo);

            Assert.That(vaga, Is.Not.Null);

            estacionamento.RegistrarEntrada(veiculo, vaga!);

            Assert.That(estacionamento.VagasDisponiveisParaCarro(), Is.EqualTo(1));
        }

        [Test]
        public void Deve_Retornar_Null_Quando_Nao_Houver_Vaga_Para_Carro()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(1, 0);

            var carro1 = new Carro("ABC1234", "Toyota", "Corolla", "Prata");
            var carro2 = new Carro("DEF5678", "Honda", "Civic", "Preto");

            var vaga1 = estacionamento.ObterVagaDisponivel(carro1);

            Assert.That(vaga1, Is.Not.Null);
            estacionamento.RegistrarEntrada(carro1, vaga1!);

            var vaga2 = estacionamento.ObterVagaDisponivel(carro2);

            Assert.That(vaga2, Is.Null);
        }
    }
}