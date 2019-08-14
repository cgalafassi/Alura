namespace Alura.Loja.Testes.ConsoleApp
{
    internal class Compra
    {
        public Compra()
        {
        }

        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }

    }
}