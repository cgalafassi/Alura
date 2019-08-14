namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var produto = new Produto
            {
                Nome = "Pão de trigo",
                Categoria = "Padaria",
                PrecoUnitario = 0.4,
                Unidade = "Unidade"
            };

            var compras = new Compra()
            {
                Produto = produto,
                Quantidade = 6,
                Preco = 6 * produto.PrecoUnitario
            };

            using (var contexto = new LojaContext())
            {
                contexto.Compras.Add(compras);

                contexto.SaveChanges();
            }
        }
    }
}
