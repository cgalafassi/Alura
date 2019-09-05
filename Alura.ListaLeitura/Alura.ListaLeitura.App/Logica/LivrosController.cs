using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController
    {
        private static string CarregaLista(IEnumerable<Livro> livros)
        {
            var conteudoArquivo = HtmlUtils.CarregaArquivoHTML("lista");

            foreach (var livro in livros)
            {
                conteudoArquivo = conteudoArquivo
                    .Replace("#NOVO-ITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM#");
            }

            return conteudoArquivo.Replace("#NOVO-ITEM#", "");
        }

        public IActionResult ParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = CarregaLista(_repo.ParaLer.Livros);

            return context.Response.WriteAsync(html);
        }

        public IActionResult Lendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();

            var html = CarregaLista(_repo.Lendo.Livros);

            return context.Response.WriteAsync(html);
        }

        public IActionResult Lidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();

            var html = CarregaLista(_repo.Lidos.Livros);

            return context.Response.WriteAsync(html);
        }

        public string Detalhes(int id)
        {
            var _repo = new LivroRepositorioCSV();
            var livro = _repo.Todos.First(x => x.Id.Equals(id));

            return livro.Detalhes();
        }
    }
}
