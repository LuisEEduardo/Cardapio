using AutoMapper;
using CardapioAplicacao.Api.Controllers;
using CardapioAplicacao.Application.App;
using CardapioAplicacao.Application.Interface;
using CardapioAplicacao.Application.ViewModel;
using CardapioAplicacao.Data;
using CardapioAplicacao.Data.Repositories;
using CardapioAplicacao.Domain.Entities;
using CardapioAplicacao.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardapioAplicacao.Test.Controllers;

public class PizzaControllerTest
{
    private IMapper _mapper;
    private IUnitOfWork _uniOfWork;
    private static DbContextOptions<Contexto> dbConextOptions { get; }
    public PizzaController _pizzaController { get; set; }
    public static string connectionString = "Server=localhost,1433;Database=Cardapio;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
    public IPizzaAplicacao _app { get; set; }
    public PizzaViewModel _pizza { get; set; } = new PizzaViewModel
    {
        Nome = "Teste",
        Ingredientes = "teste"
    };


    static PizzaControllerTest()
    {
        dbConextOptions = new DbContextOptionsBuilder<Contexto>()
            .UseSqlServer(connectionString)
            .Options;
    }

    public PizzaControllerTest()
    {
        var config = new MapperConfiguration(cfg =>
        {
            //cfg.AddProfile(new MappingProfile());
            cfg.CreateMap<Pizza, PizzaViewModel>().ReverseMap();
        });

        _mapper = config.CreateMapper();

        var contexto = new Contexto(dbConextOptions);
        _uniOfWork = new UnitOfWork(contexto);

        _app = new PizzaApp(_uniOfWork, _mapper);
        _pizzaController = new PizzaController(_app);
    }

    [Fact]
    public void SelecionarTodosPizzas_resultado_Ok()
    {
        var pizzas = _pizzaController.SelecionarTodas();
        Assert.IsType<OkObjectResult>(pizzas.Result);
    }

    [Fact]
    public void SelecionarTodosPizzas_resultdo_BadRequest()
    {
        var pizzas = _pizzaController.SelecionarTodas();
        Assert.IsType<BadRequestObjectResult>(pizzas.Result);
    }

    [Fact]
    public void SelecionarPizzasPorId_resultado_Ok()
    {        
        var data = _pizzaController.SelecionarPorId(1);
        Assert.IsType<OkObjectResult>(data.Result.Result);
    }

    [Fact]
    public void AdicionarPizza_resultado_Ok()
    {        
        var data = _pizzaController.Incluir(_pizza);
        Assert.IsType<OkObjectResult>(data.Result.Result);
    }

    [Fact]
    public void AlterarPizza_resultado_Ok()
    {
        var data = _pizzaController.Alterar(_pizza);
        Assert.IsType<OkObjectResult>(data.Result.Result);
    }

    [Fact]
    public void ExcluirPizza_resultado_Ok()
    {
        var data = _pizzaController.Excluir(5);
        Assert.IsType<OkObjectResult>(data.Result.Result);
    }

}
