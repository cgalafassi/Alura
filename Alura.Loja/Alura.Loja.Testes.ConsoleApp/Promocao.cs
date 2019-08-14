using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promocao
    {
        public Promocao()
        {
            Produtos = new List<PromocaoProduto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public IList<PromocaoProduto> Produtos { get; set; }

        internal void IncluirPrdouto(Produto produto)
        {
            Produtos.Add(new PromocaoProduto() { Produto = produto });
        }
    }
}