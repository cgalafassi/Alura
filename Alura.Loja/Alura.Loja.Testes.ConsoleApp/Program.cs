using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var promocao = new Promocao()
            {
                Nome = "Pascoa legal",
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddMonths(2)
            };

            Produto p1 = new Produto
            {
                Nome = "Pão de trigo",
                Categoria = "Padaria",
                PrecoUnitario = 0.4,
                Unidade = "Unidade"
            };
            promocao.IncluirPrdouto(p1);
            Produto p2 = new Produto
            {
                Nome = "Suco de laranja",
                Categoria = "Bebidas",
                PrecoUnitario = 8.56,
                Unidade = "Litros"
            };
            promocao.IncluirPrdouto(p2);
            Produto p3 = new Produto
            {
                Nome = "Café",
                Categoria = "Bebidas",
                PrecoUnitario = 10,
                Unidade = "Gramas"
            };
            promocao.IncluirPrdouto(p3);



            using (var contexto = new LojaContext())
            {
                //contexto.Promocoes.Add(promocao);
                var p = contexto.Promocoes.Find(1);

                contexto.Promocoes.Remove(p);

                contexto.SaveChanges();

            }
        }
    }
}
