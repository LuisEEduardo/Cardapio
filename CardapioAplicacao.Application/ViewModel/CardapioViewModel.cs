﻿using CardapioAplicacao.Domain.Entities;

namespace CardapioAplicacao.Application.ViewModel;

public class CardapioViewModel
{
    public CardapioViewModel()
    {
        Pizzas = new List<Pizza>();
    }

    public int Id { get; set; }
    public IList<Pizza> Pizzas { get; private set; }
}
