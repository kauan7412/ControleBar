using ControleBar.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;

namespace ControleBar.ConsoleApp.ModuloConta
{
    public class TelaCadastroProdutos : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Produtos> _repositorioProdutos;
        private readonly Notificador _notificador;

        public TelaCadastroProdutos(IRepositorio<Produtos> repositorioProdutos, Notificador notificador)
            : base("Cadastro de Contas")
        {
            _repositorioProdutos = repositorioProdutos;
            _notificador = notificador;
        }
        public void Inserir()
        {
            MostrarTitulo("Cadastro de Pedidos");

            Produtos NovaConta = ObterProduto();

            _repositorioProdutos.Inserir(NovaConta);

            _notificador.ApresentarMensagem("Pedido cadastrado com sucesso!", TipoMensagem.Sucesso);
        }
        public void Editar()
        {
            MostrarTitulo("Editando Pedido");
            bool RegistrosCadastrados = VisualizarRegistros("pesquisando");
            if (RegistrosCadastrados == false)
            {
                _notificador.ApresentarMensagem("nenhum pedido para editar",TipoMensagem.Atencao);
                return;
            }

            int numeroGenero = ObterNumeroRegistro();

            Produtos produtoAtualizado = ObterProduto();

            bool conseguiuEditar = _repositorioProdutos.Editar(numeroGenero, produtoAtualizado);
            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possivel editar", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("O produto foi editado com sucesso", TipoMensagem.Sucesso);
        }
        public void Excluir()
        {
            MostrarTitulo("Excluindo pedido");

            bool pedidosRealizados = VisualizarRegistros("pesquisando");

            if(pedidosRealizados == false)
            {
                _notificador.ApresentarMensagem("Não possui nenhum pedido", TipoMensagem.Atencao);
                return;
            }

            int numeroPedidos = ObterNumeroRegistro();

            bool pedidoExcluido = _repositorioProdutos.Excluir(numeroPedidos);

            if (!pedidoExcluido)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Garçom excluído com sucesso!", TipoMensagem.Sucesso);
        }
        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de pedidos cadastrados");

            List<Produtos> produtos = _repositorioProdutos.SelecionarTodos();
            
            if(produtos.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum pedido foi realizado", TipoMensagem.Atencao);
                return false;
            }

            foreach (Produtos produto in produtos)
                Console.WriteLine(produto.ToString());

            Console.ReadLine();

            return true;
        }
        private Produtos ObterProduto()
        {
            Console.WriteLine("digite o pedido do cliente");
            string produto = Console.ReadLine();

            Console.WriteLine("digite o preço dos produtos");
            int preco = Convert.ToInt32(Console.ReadLine());

            return new Produtos(produto,preco);
        }
        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.WriteLine("Digite o numero do pedido para editar");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioProdutos.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("O pedido não foi encontrado,digite novamente", TipoMensagem.Atencao);

            }while (false);
            
            return numeroRegistro;
        }
    }
}
