using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class ProdutoDaoEntity : IProdutoDao, IDisposable
    {
        private LojaContext Contexto { get; set; }

        public ProdutoDaoEntity()
        {
            Contexto = new LojaContext();
        }

        public void Adicionar(Produto p)
        {
            Contexto.Produtos.Add(p);
            Contexto.SaveChanges();
        }

        public void Atualizar(Produto p)
        {
            Contexto.Produtos.Update(p);
            Contexto.SaveChanges();
        }

        public void Dispose()
        {
            Contexto.Dispose();
        }

        public IList<Produto> Produtos()
        {
            return Contexto.Produtos.ToList();
        }

        public void Remover(Produto p)
        {
            Contexto.Produtos.Remove(p);
            Contexto.SaveChanges();
        }
    }
}
