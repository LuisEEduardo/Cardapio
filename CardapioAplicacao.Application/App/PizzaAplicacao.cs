﻿using AutoMapper;
using CardapioAplicacao.Application.Interface;
using CardapioAplicacao.Application.ViewModel;
using CardapioAplicacao.Domain.Entities;
using CardapioAplicacao.Domain.Repositories;

namespace CardapioAplicacao.Application.App;

public class PizzaAplicacao : IPizzaAplicacao
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PizzaAplicacao(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void AdicionarPizza(PizzaViewModel pizza)
    {
        _unitOfWork.PizzaRepositorio.Incluir(_mapper.Map<Pizza>(pizza));
    }

    public void AlterarPizza(PizzaViewModel pizza)
    {
        _unitOfWork.PizzaRepositorio.Alterar(_mapper.Map<Pizza>(pizza));
    }

    public void Excluir(int id)
    {
        _unitOfWork.PizzaRepositorio.ExcluirPorId(p => p.Id == id);
    }

    public PizzaViewModel SelecionarPorId(int id)
    {
        return _mapper.Map<PizzaViewModel>(_unitOfWork.PizzaRepositorio.SelecionarPorId(p => p.Id == id));
    }

    public IEnumerable<PizzaViewModel> SelecionarTodas()
    {
        return _mapper.Map<IEnumerable<PizzaViewModel>>(_unitOfWork.PizzaRepositorio.SelecionarTodos());
    }
}
