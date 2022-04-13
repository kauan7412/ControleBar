using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleBar.ConsoleApp.ModuloMesas
{
    public class TelaCadastroMesas : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Mesas> _repositorioMesas;
        private readonly Notificador _notificador;

        public TelaCadastroMesas(IRepositorio<Mesas> repositorioMesas, Notificador notificador)
            : base("Cadastro de Mesas")
        {
            _repositorioMesas = repositorioMesas;
            _notificador = notificador;
        }
        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            return false;
        }
        public void Excluir()
        {

        }
        public void Editar()
        {

        }
        public void Inserir()
        {

        }
        private Mesas ObterMesas()
        {
            Console.WriteLine("digite")
        }
    }
}
