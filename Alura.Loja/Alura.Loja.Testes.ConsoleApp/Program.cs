using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = new Cliente()
            {
                Nome = "Christian",
                EnderecoEntrega = new Endereco()
                {
                    Numero = 12,
                    Logradouro = "Rua dos invalidos",
                    Complemento ="302",
                    Bairo = "Centro",
                    Cidade = "Lages"
                }
            };

            using (var contexto = new LojaContext())
            {
                contexto.Clientes.Add(cliente);

                contexto.SaveChanges();

            }
        }
    }
}
