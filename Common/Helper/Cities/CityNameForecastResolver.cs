using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using Common.Extensions.Enumeration;
using Core.Dtos;
using Core.Entities;

namespace Common.Helper.Cities
{
    public class CityNameForecastResolver: IValueResolver<City, CityToReturnDto, List<ForecastReturnDto>>
    {
      
        public List<ForecastReturnDto> Resolve(City source, CityToReturnDto destination, List<ForecastReturnDto> destMember, ResolutionContext context)
        {
            if (source.Forecast.Any())
            {
                foreach (var item in source.Forecast)
                {
                    var forecast = context.Mapper.Map<ForecastReturnDto>(item);
                    forecast.Time = item.Time.GetDescription();
                    destMember.Add(forecast);
                }
                
                return destMember;
            }
            
            return null;
        }
    }
}