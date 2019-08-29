using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);
            routeBuilder.MapRoute("livros/paraler", LivrosParaLer);
            routeBuilder.MapRoute("livros/lendo", LivrosLendo);
            routeBuilder.MapRoute("livros/lidos", LivrosLidos);
            routeBuilder.MapRoute("cadastro/novolivro/{nome}/{autor}", CadastroNovoLivro);
            routeBuilder.MapRoute("livros/detalhes/{id}", LivrosDetalhes);
            var rotas = routeBuilder.Build();

            app.UseRouter(rotas);
        }

        private Task LivrosDetalhes(HttpContext context)
        {
            var id = Convert.ToInt32(context.GetRouteValue("id"));
            var _repo = new LivroRepositorioCSV();
            var livro = _repo.Todos.First(x => x.Id.Equals(id));

            return context.Response.WriteAsync(livro.Detalhes());
        }

        public Task CadastroNovoLivro(HttpContext context)
        {
            var livro = new Livro
            {
                Titulo = Convert.ToString(context.GetRouteValue("nome")),
                Autor = Convert.ToString(context.GetRouteValue("autor")),
            };
            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);
            return context.Response.WriteAsync("Livro adicionado com sucesso!");
        }

        public Task LivrosParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.ParaLer.ToString());
        }
        public Task LivrosLendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lendo.ToString());
        }

        public Task LivrosLidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lidos.ToString());
        }
    }
}