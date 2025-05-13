// See https://aka.ms/new-console-template for more information
using EstacionamentoConsole.ApplicationLayer;
using EstacionamentoConsole.Models;
using EstacionamentoConsole.Models.DTOs;
using EstacionamentoConsole.Models.Services;

Console.WriteLine("Hello, World!");

var estacionamento = new Estacionamento(null);
var entradaService = new EntradaVeiculoService(estacionamento);
var entradaVeiculo = new EntradaVeiculo(entradaService);

var entradaDto = new EntradaVeiculoDTO("carro", "EQZ4I47", "Hyundai", "i30", "Prata");

entradaVeiculo.Entrada(entradaDto);

Console.ReadKey();