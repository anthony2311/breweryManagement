using Api.Models;
using AutoMapper;
using Data.Models;

namespace Api.Mappers
{
    /// <summary>
    /// class use on Automapper to map Dto to entity objects
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<Beer, BeerDto>();
            CreateMap<BeerDto, Beer>();
            CreateMap<Brewery, BreweryDto>();
            CreateMap<Wholesaler, WholesalerDto>();
        }
    }
}
