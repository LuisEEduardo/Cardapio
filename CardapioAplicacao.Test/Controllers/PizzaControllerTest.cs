using AutoMapper;
using CardapioAplicacao.Api.Controllers;
using CardapioAplicacao.Data;
using CardapioAplicacao.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CardapioAplicacao.Test.Controllers;

public class PizzaControllerTest
{
    private IMapper _mapper;
    private IUnitOfWork _uniOfWork;
    private static DbContextOptions<Contexto> dbConextOptions { get; }

    public PizzaController _pizzaController { get; set; }
    private string connectionString = "Server=localhost,1433;Database=Cardapio;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";

    static PizzaControllerTest()
    {
        dbConextOptions = new DbContextOptionsBuilder<Contexto>()
            .UseSqlServer();
    }


}
