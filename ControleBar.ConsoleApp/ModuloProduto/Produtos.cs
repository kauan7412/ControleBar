using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloConta
{
    public class Produtos : EntidadeBase
    {
        public string _produtos { get; set; }
        public int _preco { get; set; }
        public Produtos(string produtos, int preco)
        {
            _produtos = produtos;
            _preco = preco;
        }

        public override string ToString()
        {
            return "Pedido: " + id + Environment.NewLine +
            "Produtos:" + _produtos + Environment.NewLine +
            "Preço:" + _preco + Environment.NewLine;
            
            
        }
    }
}
