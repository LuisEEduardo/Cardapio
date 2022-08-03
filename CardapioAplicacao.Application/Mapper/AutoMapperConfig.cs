using AutoMapper;
using CardapioAplicacao.Application.ViewModel;
using CardapioAplicacao.Domain.Entities;

namespace CardapioAplicacao.Application.Mapper;

public class AutoMapperConfig : Profile
{
    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(x => x.AllowNullCollections = true);
    }

    public AutoMapperConfig()
    {
        CreateMap<Pizza, PizzaViewModel>().ReverseMap();
        CreateMap<Cardapio, CardapioViewModel>().ReverseMap();
    }

}
