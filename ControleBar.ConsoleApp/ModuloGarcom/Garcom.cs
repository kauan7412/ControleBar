﻿using ControleBar.ConsoleApp.Compartilhado;
using System;

namespace ControleBar.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public decimal Gorjeta { get; set; } = 0m;

        public Garcom(string nome, string cpf)
        {
            Nome = nome;
            CPF = cpf;
        }

        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Nome do garçom: " + Nome + Environment.NewLine +
                "Gorjetas recebidas: R$" + Gorjeta + Environment.NewLine;
        }

        public void ReceberGorjeta(decimal gorjetaCalculada)
        {
            Gorjeta += gorjetaCalculada;
        }
    }
}
