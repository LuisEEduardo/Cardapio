using CardapioAplicacao.Application.App;
using CardapioAplicacao.Application.Interface;
using CardapioAplicacao.Application.Mapper;
using CardapioAplicacao.Data;
using CardapioAplicacao.Data.Repositories;
using CardapioAplicacao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CardapioAplicacao.Infra.Ioc;

public class Bootstrap
{
    public static void RegistroDeServicos(IServiceCollection services, IConfiguration configuration)
    {
        // Connection string 
        services.AddDbContext<Contexto>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Conexao")));

        // AutoMapper 
        services.AddAutoMapper(typeof(AutoMapperConfig));

        // Repositorios  
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Aplicação
        services.AddScoped<ICardapioAplicacao, CardapioApp>();
        services.AddScoped<IPizzaAplicacao, PizzaApp>();
    }    
}
