using AutoMapper;
using Common.Helper.Cities;
using Core.Dtos;
using Core.Entities;

namespace API.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<City, CityToReturnDto>()
                .ForMember(x => x.ForecastReturnDto, source => source.MapFrom(new CityNameForecastResolver()))
                .ReverseMap();
            
            CreateMap<City, ForecastReturnDto>();
            CreateMap<CityToReturnDto, ForecastReturnDto>();
            CreateMap<Forecast, ForecastReturnDto>();
        }
    }
}