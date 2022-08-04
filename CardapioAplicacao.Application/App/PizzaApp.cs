using AutoMapper;
using CardapioAplicacao.Application.Interface;
using CardapioAplicacao.Application.ViewModel;
using CardapioAplicacao.Domain.Entities;
using CardapioAplicacao.Domain.Repositories;

namespace CardapioAplicacao.Application.App;

public class PizzaApp : IPizzaAplicacao
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PizzaApp(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task AdicionarPizza(PizzaViewModel pizza)
    {
        _unitOfWork.PizzaRepositorio.Incluir(_mapper.Map<Pizza>(pizza));
        await _unitOfWork.Commit();
    }

    public async Task AlterarPizza(PizzaViewModel pizza)
    {
        _unitOfWork.PizzaRepositorio.Alterar(_mapper.Map<Pizza>(pizza));
        await _unitOfWork.Commit();
    }

    public async Task Excluir(int id)
    {
        await _unitOfWork.PizzaRepositorio.ExcluirPorId(p => p.Id == id);
        await _unitOfWork.Commit();
    }

    public async Task<PizzaViewModel> SelecionarPorId(int id)
    {
        return _mapper.Map<PizzaViewModel>(await _unitOfWork.PizzaRepositorio.SelecionarPorId(p => p.Id == id));
    }

    public IEnumerable<PizzaViewModel> SelecionarTodas()
    {
        return _mapper.Map<IEnumerable<PizzaViewModel>>(_unitOfWork.PizzaRepositorio.SelecionarTodos());
    }
}
