using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloMesas
{
    public class Mesas : EntidadeBase
    {
        public int quantidadeDeMesas { get; set; }

        public Mesas(int quantidadeDeMesas)
        {
            this.quantidadeDeMesas = quantidadeDeMesas;
        }
        public override string ToString()
        {
            return 
            "mesas" + quantidadeDeMesas + Environment.NewLine;
        }
    }
}
