using Alura.ListaLeitura.App.Logica;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

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
            routeBuilder.MapRoute("livros/paraler", LivrosLogica.LivrosParaLer);
            routeBuilder.MapRoute("livros/lendo", LivrosLogica.LivrosLendo);
            routeBuilder.MapRoute("livros/lidos", LivrosLogica.LivrosLidos);
            routeBuilder.MapRoute("cadastro/novolivro/{nome}/{autor}", CadastroLogica.CadastroNovoLivro);
            routeBuilder.MapRoute("livros/detalhes/{id}", CadastroLogica.LivrosDetalhes);
            routeBuilder.MapRoute("Cadastro/NovoLivro", CadastroLogica.ExibeFormulario);
            routeBuilder.MapRoute("Cadastro/Incluir", CadastroLogica.ProcessaFormulario);
            var rotas = routeBuilder.Build();

            app.UseRouter(rotas);
        }        
    }
}