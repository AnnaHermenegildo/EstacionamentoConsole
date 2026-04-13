using EstacionamentoConsole.ApplicationLayer;
using EstacionamentoConsole.Interfaces;
using EstacionamentoConsole.Models;
using EstacionamentoConsole.Models.DTOs;
using EstacionamentoConsole.Models.Factory;
using EstacionamentoConsole.Models.Response;
using EstacionamentoConsole.Models.Services;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.IO;
using System.Reflection;

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

        [Test]
        public void Deve_Registrar_Entrada_De_Moto()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(0, 2);
            var moto = new Moto("MOT1234", "Honda", "CG", "Preta");
            var vaga = estacionamento.ObterVagaDisponivel(moto);

            Assert.That(vaga, Is.Not.Null);

            estacionamento.RegistrarEntrada(moto, vaga!);

            Assert.That(vaga!.Ocupada, Is.True);
            Assert.That(estacionamento.VagasDisponiveisParaMoto(), Is.EqualTo(1));
        }

        [Test]
        public void Deve_Retornar_Null_Quando_Nao_Houver_Vaga_Para_Moto()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(0, 1);

            var moto1 = new Moto("MOT1234", "Honda", "CG", "Preta");
            var moto2 = new Moto("MOT5678", "Yamaha", "Factor", "Azul");

            var vaga1 = estacionamento.ObterVagaDisponivel(moto1);

            Assert.That(vaga1, Is.Not.Null);

            estacionamento.RegistrarEntrada(moto1, vaga1!);

            var vaga2 = estacionamento.ObterVagaDisponivel(moto2);

            Assert.That(vaga2, Is.Null);
        }

        [Test]
        public void Deve_Retornar_Vagas_Disponiveis_Para_Moto()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(0, 2);

            var vagas = estacionamento.VagasDisponiveisParaMoto();

            Assert.That(vagas, Is.EqualTo(2));
        }

        [Test]
        public void Deve_Retornar_Total_De_Vagas_Corretamente()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(3, 2);

            Assert.That(estacionamento.TotalVagas, Is.EqualTo(5));
        }

        [Test]
        public void Deve_Retornar_Vaga_Por_Placa_Apos_Entrada()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(1, 0);
            var carro = new Carro("ABC1234", "Toyota", "Corolla", "Prata");
            var vaga = estacionamento.ObterVagaDisponivel(carro);

            Assert.That(vaga, Is.Not.Null);

            estacionamento.RegistrarEntrada(carro, vaga!);

            var vagaEncontrada = estacionamento.RetornaVagaPorPlaca(carro);

            Assert.That(vagaEncontrada, Is.Not.Null);
            Assert.That(vagaEncontrada, Is.EqualTo(vaga));
        }

        [Test]
        public void Deve_Listar_Veiculos_Estacionados()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(1, 1);

            var carro = new Carro("ABC1234", "Toyota", "Corolla", "Prata");
            var moto = new Moto("MOT1234", "Honda", "CG", "Preta");

            var vagaCarro = estacionamento.ObterVagaDisponivel(carro);
            var vagaMoto = estacionamento.ObterVagaDisponivel(moto);

            Assert.That(vagaCarro, Is.Not.Null);
            Assert.That(vagaMoto, Is.Not.Null);

            estacionamento.RegistrarEntrada(carro, vagaCarro!);
            estacionamento.RegistrarEntrada(moto, vagaMoto!);

            var veiculos = estacionamento.ListarVeiculosEstacionados().ToList();

            Assert.That(veiculos.Count, Is.EqualTo(2));
            Assert.That(veiculos.Any(v => v.Tipo == "Carro"), Is.True);
            Assert.That(veiculos.Any(v => v.Tipo == "Moto"), Is.True);
        }

        [Test]
        public void Deve_Diminuir_Quantidade_De_Vagas_De_Moto_Apos_Entrada()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(0, 2);
            var moto = new Moto("MOT1234", "Honda", "CG", "Preta");

            var vaga = estacionamento.ObterVagaDisponivel(moto);

            Assert.That(vaga, Is.Not.Null);

            estacionamento.RegistrarEntrada(moto, vaga!);

            Assert.That(estacionamento.VagasDisponiveisParaMoto(), Is.EqualTo(1));
        }

        [Test]
        public void Deve_Aumentar_Quantidade_De_Vagas_De_Carro_Apos_Saida()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(1, 0);
            var carro = new Carro("ABC1234", "Toyota", "Corolla", "Prata");

            var vaga = estacionamento.ObterVagaDisponivel(carro);

            Assert.That(vaga, Is.Not.Null);

            estacionamento.RegistrarEntrada(carro, vaga!);
            estacionamento.RegistrarSaida(carro, vaga!);

            Assert.That(estacionamento.VagasDisponiveisParaCarro(), Is.EqualTo(1));
        }

        [Test]
        public void Deve_Aumentar_Quantidade_De_Vagas_De_Moto_Apos_Saida()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(0, 1);
            var moto = new Moto("MOT1234", "Honda", "CG", "Preta");

            var vaga = estacionamento.ObterVagaDisponivel(moto);

            Assert.That(vaga, Is.Not.Null);

            estacionamento.RegistrarEntrada(moto, vaga!);
            estacionamento.RegistrarSaida(moto, vaga!);

            Assert.That(estacionamento.VagasDisponiveisParaMoto(), Is.EqualTo(1));
        }

        [Test]
        public void Deve_Retornar_Lista_Vazia_Quando_Nao_Houver_Veiculos_Estacionados()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(1, 1);

            var veiculos = estacionamento.ListarVeiculosEstacionados().ToList();

            Assert.That(veiculos, Is.Empty);
        }

        [Test]
        public void VagaFactory_Deve_Criar_Quantidade_Correta_De_Vagas()
        {
            var vagas = VagaFactory.CriarVagas(3, 2);

            Assert.That(vagas.Count, Is.EqualTo(5));
        }

        private sealed class ConsoleOutputScope : IDisposable
        {
            private readonly TextWriter _originalOut;
            public StringWriter Writer { get; } = new StringWriter();

            public ConsoleOutputScope()
            {
                _originalOut = Console.Out;
                Console.SetOut(Writer);
            }

            public string Output => Writer.ToString();

            public void Dispose()
            {
                Console.SetOut(_originalOut);
                Writer.Dispose();
            }
        }

        [Test]
        public void VeiculoFactory_Deve_Criar_Carro()
        {
            var veiculo = VeiculoFactory.CriarVeiculo("carro", "ABC1234", "Toyota", "Corolla", "Prata");

            Assert.That(veiculo, Is.TypeOf<Carro>());
            Assert.That(veiculo.Placa, Is.EqualTo("ABC1234"));
            Assert.That(veiculo.Marca, Is.EqualTo("Toyota"));
        }

        [Test]
        public void VeiculoFactory_Deve_Criar_Moto()
        {
            var veiculo = VeiculoFactory.CriarVeiculo("moto", "BRA2E19", "Honda", "CG", "Preta");

            Assert.That(veiculo, Is.TypeOf<Moto>());
            Assert.That(veiculo.Placa, Is.EqualTo("BRA2E19"));
            Assert.That(veiculo.Modelo, Is.EqualTo("CG"));
        }

        [Test]
        public void VeiculoFactory_Deve_Aceitar_Tipo_Em_Maiusculas()
        {
            var veiculo = VeiculoFactory.CriarVeiculo("CARRO", "DEF5678", "Honda", "Civic", "Preto");

            Assert.That(veiculo, Is.TypeOf<Carro>());
        }

        [Test]
        public void VeiculoFactory_Deve_Lancar_Excecao_Quando_Tipo_For_Invalido()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                VeiculoFactory.CriarVeiculo("caminhao", "ABC1234", "Volvo", "FH", "Branco"));

            Assert.That(ex!.Message, Does.Contain("Tipo de veículo inválido"));
        }

        [Test]
        public void Veiculo_Deve_Aceitar_Placa_Formato_Antigo()
        {
            var veiculo = new Carro("ABC1234", "Toyota", "Corolla", "Prata");

            Assert.That(veiculo.Placa, Is.EqualTo("ABC1234"));
        }

        [Test]
        public void Veiculo_Deve_Aceitar_Placa_Mercosul()
        {
            var veiculo = new Moto("BRA2E19", "Honda", "CG", "Preta");

            Assert.That(veiculo.Placa, Is.EqualTo("BRA2E19"));
        }

        [Test]
        public void Veiculo_Deve_Lancar_Excecao_Quando_Placa_For_Vazia()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Carro("", "Toyota", "Corolla", "Prata"));

            Assert.That(ex!.Message, Does.Contain("não pode ser vazia").IgnoreCase);
        }

        [Test]
        public void Veiculo_Deve_Lancar_Excecao_Quando_Placa_Tiver_Tamanho_Invalido()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Carro("ABCDEFGH", "Toyota", "Corolla", "Prata"));

            Assert.That(ex!.Message, Does.Contain("Placa inválida"));
        }

        [Test]
        public void Veiculo_Deve_Lancar_Excecao_Quando_Formato_For_Invalido()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
                new Carro("12A3456", "Toyota", "Corolla", "Prata"));

            Assert.That(ex!.Message, Does.Contain("formato inválido").IgnoreCase);
        }

        [Test]
        public void EntradaVeiculoDTO_Deve_Preencher_Propriedades()
        {
            var dto = new EntradaVeiculoDTO("carro", "ABC1234", "Toyota", "Corolla", "Prata");

            Assert.Multiple(() =>
            {
                Assert.That(dto.Tipo, Is.EqualTo("carro"));
                Assert.That(dto.Placa, Is.EqualTo("ABC1234"));
                Assert.That(dto.Marca, Is.EqualTo("Toyota"));
                Assert.That(dto.Modelo, Is.EqualTo("Corolla"));
                Assert.That(dto.Cor, Is.EqualTo("Prata"));
            });
        }

        [Test]
        public void SaidaVeiculoDTO_Deve_Permitir_Atribuir_Placa()
        {
            var dto = new SaidaVeiculoDTO
            {
                Placa = "ABC1234"
            };

            Assert.That(dto.Placa, Is.EqualTo("ABC1234"));
        }

        [Test]
        public void Resultado_Deve_Permitir_Atribuir_Valores()
        {
            var resultado = new Resultado
            {
                Sucesso = true,
                Mensagem = "Operação realizada"
            };

            Assert.Multiple(() =>
            {
                Assert.That(resultado.Sucesso, Is.True);
                Assert.That(resultado.Mensagem, Is.EqualTo("Operação realizada"));
            });
        }

        [Test]
        public void EstacionamentoService_Deve_Registrar_Entrada_Quando_Houver_Vaga()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(1, 0);
            var service = new EstacionamentoService(estacionamento);
            var carro = new Carro("ABC1234", "Toyota", "Corolla", "Prata");

            using var output = new ConsoleOutputScope();

            service.RegistrarEntradaVeiculo(carro);

            Assert.Multiple(() =>
            {
                Assert.That(output.Output, Does.Contain("Entrada registrada com sucesso"));
                Assert.That(estacionamento.VagasDisponiveisParaCarro(), Is.EqualTo(0));
                Assert.That(estacionamento.ListarVeiculosEstacionados().Count(), Is.EqualTo(1));
            });
        }

        [Test]
        public void EstacionamentoService_Deve_Informar_Quando_Nao_Houver_Vaga()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(1, 0);
            var service = new EstacionamentoService(estacionamento);

            service.RegistrarEntradaVeiculo(new Carro("ABC1234", "Toyota", "Corolla", "Prata"));

            using var output = new ConsoleOutputScope();

            service.RegistrarEntradaVeiculo(new Carro("DEF5678", "Honda", "Civic", "Preto"));

            Assert.That(output.Output, Does.Contain("Não há vagas disponíveis"));
        }

        [Test]
        public void EstacionamentoService_Deve_Registrar_Saida_Quando_Placa_Existir()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(1, 0);
            var service = new EstacionamentoService(estacionamento);

            service.RegistrarEntradaVeiculo(new Carro("ABC1234", "Toyota", "Corolla", "Prata"));

            using var output = new ConsoleOutputScope();

            service.RegistrarSaidaVeiculo("ABC1234");

            Assert.Multiple(() =>
            {
                Assert.That(output.Output, Does.Contain("Saída registrada com sucesso"));
                Assert.That(estacionamento.VagasDisponiveisParaCarro(), Is.EqualTo(1));
                Assert.That(estacionamento.ListarVeiculosEstacionados(), Is.Empty);
            });
        }

        [Test]
        public void EstacionamentoService_Deve_Informar_Quando_Veiculo_Nao_Estiver_Estacionado()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(1, 0);
            var service = new EstacionamentoService(estacionamento);

            using var output = new ConsoleOutputScope();

            service.RegistrarSaidaVeiculo("AAA0000");

            Assert.That(output.Output, Does.Contain("não se encontra estacionado").IgnoreCase);
        }

        [Test]
        public void EstacionamentoService_Deve_Retornar_Vaga_Disponivel()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(1, 0);
            var service = new EstacionamentoService(estacionamento);

            var vaga = service.ObterVagaDisponivel(new Carro("ABC1234", "Toyota", "Corolla", "Prata"));

            Assert.That(vaga, Is.Not.Null);
            Assert.That(vaga, Is.TypeOf<VagaCarro>());
        }

        [Test]
        public void EstacionamentoService_Deve_Listar_Veiculos_Estacionados()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(1, 1);
            var service = new EstacionamentoService(estacionamento);

            service.RegistrarEntradaVeiculo(new Carro("ABC1234", "Toyota", "Corolla", "Prata"));
            service.RegistrarEntradaVeiculo(new Moto("BRA2E19", "Honda", "CG", "Preta"));

            var veiculos = service.ListarVeiculosEstacionados().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(veiculos.Count, Is.EqualTo(2));
                Assert.That(veiculos.Any(x => x.Tipo == "Carro"), Is.True);
                Assert.That(veiculos.Any(x => x.Tipo == "Moto"), Is.True);
            });
        }

        [Test]
        public void EntradaVeiculo_Deve_Registrar_Carro_A_Partir_Do_Dto()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(1, 0);
            var service = new EstacionamentoService(estacionamento);
            var app = new EntradaVeiculo(service);

            var dto = new EntradaVeiculoDTO("carro", "ABC1234", "Toyota", "Corolla", "Prata");

            app.Entrada(dto);

            var estacionados = estacionamento.ListarVeiculosEstacionados().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(estacionados.Count, Is.EqualTo(1));
                Assert.That(estacionados[0].Tipo, Is.EqualTo("Carro"));
                Assert.That(estacionados[0].Veiculo.Placa, Is.EqualTo("ABC1234"));
            });
        }

        [Test]
        public void EntradaVeiculo_Deve_Registrar_Moto_A_Partir_Do_Dto()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(0, 1);
            var service = new EstacionamentoService(estacionamento);
            var app = new EntradaVeiculo(service);

            var dto = new EntradaVeiculoDTO("moto", "BRA2E19", "Honda", "CG", "Preta");

            app.Entrada(dto);

            var estacionados = estacionamento.ListarVeiculosEstacionados().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(estacionados.Count, Is.EqualTo(1));
                Assert.That(estacionados[0].Tipo, Is.EqualTo("Moto"));
                Assert.That(estacionados[0].Veiculo.Placa, Is.EqualTo("BRA2E19"));
            });
        }

        [Test]
        public void SaidaVeiculo_Deve_Registrar_Saida_A_Partir_Do_Dto()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(1, 0);
            var service = new EstacionamentoService(estacionamento);
            var entrada = new EntradaVeiculo(service);
            var saida = new SaidaVeiculo(service);

            entrada.Entrada(new EntradaVeiculoDTO("carro", "ABC1234", "Toyota", "Corolla", "Prata"));
            saida.RegistrarSaida(new SaidaVeiculoDTO { Placa = "ABC1234" });

            Assert.Multiple(() =>
            {
                Assert.That(estacionamento.VagasDisponiveisParaCarro(), Is.EqualTo(1));
                Assert.That(estacionamento.ListarVeiculosEstacionados(), Is.Empty);
            });
        }

        [Test]
        public void VagaCarro_Deve_Aceitar_Somente_Carro()
        {
            var vaga = VagaFactory.CriarVagas(1, 0).Single();

            var aceitaMethod = vaga.GetType().GetMethod("Aceita", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(aceitaMethod, Is.Not.Null);

            var aceitaCarro = (bool)aceitaMethod!.Invoke(vaga, new object[] { new Carro("ABC1234", "Toyota", "Corolla", "Prata") })!;
            var aceitaMoto = (bool)aceitaMethod.Invoke(vaga, new object[] { new Moto("BRA2E19", "Honda", "CG", "Preta") })!;

            Assert.Multiple(() =>
            {
                Assert.That(aceitaCarro, Is.True);
                Assert.That(aceitaMoto, Is.False);
            });
        }

        [Test]
        public void VagaMoto_Deve_Aceitar_Somente_Moto()
        {
            var vaga = VagaFactory.CriarVagas(0, 1).Single();

            var aceitaMethod = vaga.GetType().GetMethod("Aceita", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.That(aceitaMethod, Is.Not.Null);

            var aceitaMoto = (bool)aceitaMethod!.Invoke(vaga, new object[] { new Moto("BRA2E19", "Honda", "CG", "Preta") })!;
            var aceitaCarro = (bool)aceitaMethod.Invoke(vaga, new object[] { new Carro("ABC1234", "Toyota", "Corolla", "Prata") })!;

            Assert.Multiple(() =>
            {
                Assert.That(aceitaMoto, Is.True);
                Assert.That(aceitaCarro, Is.False);
            });
        }

        [Test]
        public void ExecutarMenu_Deve_Encerrar_Quando_Opcao_For_Zero()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(3, 2);
            var service = new EstacionamentoService(estacionamento);
            var entrada = new EntradaVeiculo(service);
            var saida = new SaidaVeiculo(service);

            var input = new StringReader("0" + Environment.NewLine);
            var output = new StringWriter();

            Console.SetIn(input);
            Console.SetOut(output);

            Program.ExecutarMenu(estacionamento, service, entrada, saida);

            Assert.That(output.ToString(), Does.Contain("Digite a opção desejada:"));
        }

        [Test]
        public void ExecutarMenu_Deve_Exibir_Mensagem_Quando_Opcao_For_Invalida()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(3, 2);
            var service = new EstacionamentoService(estacionamento);
            var entrada = new EntradaVeiculo(service);
            var saida = new SaidaVeiculo(service);

            var input = new StringReader(
                "9" + Environment.NewLine +
                "0" + Environment.NewLine);

            var output = new StringWriter();

            Console.SetIn(input);
            Console.SetOut(output);

            Program.ExecutarMenu(estacionamento, service, entrada, saida);

            Assert.That(output.ToString(), Does.Contain("Opção inválida."));
        }

        [Test]
        public void ExecutarMenu_Deve_Registrar_Entrada_De_Carro()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(3, 2);
            var service = new EstacionamentoService(estacionamento);
            var entrada = new EntradaVeiculo(service);
            var saida = new SaidaVeiculo(service);

            var input = new StringReader(
                "1" + Environment.NewLine +
                "carro" + Environment.NewLine +
                "ABC1234" + Environment.NewLine +
                "Toyota" + Environment.NewLine +
                "Corolla" + Environment.NewLine +
                "Prata" + Environment.NewLine +
                "0" + Environment.NewLine);

            var output = new StringWriter();

            Console.SetIn(input);
            Console.SetOut(output);

            Program.ExecutarMenu(estacionamento, service, entrada, saida);

            Assert.That(estacionamento.ListarVeiculosEstacionados().Count(), Is.EqualTo(1));
        }

        [Test]
        public void Program_Deve_Exibir_Mensagem_Quando_Ocorrer_Excecao_Na_Entrada()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(3, 2);
            var service = new EstacionamentoService(estacionamento);
            var entrada = new EntradaVeiculo(service);
            var saida = new SaidaVeiculo(service);

            var input = new StringReader(
                "1" + Environment.NewLine +
                "carro" + Environment.NewLine +
                "" + Environment.NewLine +
                "Toyota" + Environment.NewLine +
                "Corolla" + Environment.NewLine +
                "Prata" + Environment.NewLine +
                "0" + Environment.NewLine);

            var output = new StringWriter();

            Console.SetIn(input);
            Console.SetOut(output);

            Assert.Throws<ArgumentException>(() => Program.ExecutarMenu(estacionamento, service, entrada, saida));
        }

        [Test]
        public void Program_Deve_Exibir_Mensagem_Quando_Ocorrer_Excecao_Na_Saida()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(3, 2);
            var service = new EstacionamentoService(estacionamento);
            var entrada = new EntradaVeiculo(service);
            var saida = new SaidaVeiculo(service);

            var input = new StringReader("2" + Environment.NewLine + "" + Environment.NewLine);

            var output = new StringWriter();

            Console.SetIn(input);
            Console.SetOut(output);

            Assert.Throws<ArgumentException>(() => Program.ExecutarMenu(estacionamento, service, entrada, saida));
        }

        [Test]
        public void Program_Deve_Listar_Veiculos_Quando_Opção_For_3()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(3, 2);
            var service = new EstacionamentoService(estacionamento);
            var entrada = new EntradaVeiculo(service);
            var saida = new SaidaVeiculo(service);

            var vagaCarro = estacionamento.ObterVagaDisponivel(new Carro("ABC1234", "Toyota", "Corolla", "Prata"));
            var vagaMoto = estacionamento.ObterVagaDisponivel(new Moto("BRA2E19", "Honda", "CG", "Preta"));

            estacionamento.RegistrarEntrada(new Carro("ABC1234", "Toyota", "Corolla", "Prata"), vagaCarro!);
            estacionamento.RegistrarEntrada(new Moto("BRA2E19", "Honda", "CG", "Preta"), vagaMoto!);

            var input = new StringReader(
                "3" + Environment.NewLine +
                "0" + Environment.NewLine);

            var output = new StringWriter();

            Console.SetIn(input);
            Console.SetOut(output);

            Program.ExecutarMenu(estacionamento, service, entrada, saida);

            var textoSaida = output.ToString();

            Assert.Multiple(() =>
            {
                Assert.That(textoSaida, Does.Contain("Veículos Estacionados:"));
                Assert.That(textoSaida, Does.Contain("Carro: ABC1234 - Toyota Corolla - Prata"));
                Assert.That(textoSaida, Does.Contain("Moto: BRA2E19 - Honda CG - Preta"));
            });
        }

        [Test]
        public void Program_Deve_Exibir_Mensagem_Quando_Opção_For_Invalida()
        {
            var estacionamento = new EstacionamentoConsole.Models.Estacionamento(3, 2);
            var service = new EstacionamentoService(estacionamento);
            var entrada = new EntradaVeiculo(service);
            var saida = new SaidaVeiculo(service);

            var input = new StringReader(
                "9" + Environment.NewLine +
                "0" + Environment.NewLine);

            var output = new StringWriter();

            Console.SetIn(input);
            Console.SetOut(output);

            Program.ExecutarMenu(estacionamento, service, entrada, saida);

            var textoSaida = output.ToString();

            Assert.That(textoSaida, Does.Contain("Opção inválida."));
        }
    }
}
