using System;
using System.Collections.Generic;
using Core.Entities;
using Newtonsoft.Json;

namespace Core.Dtos
{
    public class CityToReturnDto : BaseEntity
    {
        public CityToReturnDto()
        {
            ForecastReturnDto =new List<ForecastReturnDto>();
        }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public DateTime Atualizacao { get; set; }
        public List<ForecastReturnDto> ForecastReturnDto { get; set; }
    }

    public class ForecastReturnDto
    {
        [JsonProperty("dia")]
        public DateTime Day { get; set; }
        
        [JsonProperty("tempo")]
        public string Time { get; set; }
        
        [JsonProperty("minima")]
        public int Min { get; set; }
        
        [JsonProperty("maxima")]
        public int Max { get; set; }
        
        [JsonProperty("iuv")]
        public double Iuv { get; set; }
    }
}