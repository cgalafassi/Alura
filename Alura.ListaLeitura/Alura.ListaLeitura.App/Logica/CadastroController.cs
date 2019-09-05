using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {
        public string Incluir(Livro livro)
        {
            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);
            return "Livro adicionado com sucesso!";
        }

        public IActionResult ExibeFormulario()
        {
            var html = new ViewResult { ViewName = "formulario" };
            return html;
        }

    }
}
