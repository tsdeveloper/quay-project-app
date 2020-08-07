using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Core.Entities
{
    public class City : BaseEntity
    {
        public City()
        {
            Forecast = new List<Forecast>();
        }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        
        [JsonProperty("uf")]
        public string Uf { get; set; }
          
        [JsonProperty("atualizacao")]
        public DateTime Atualizacao { get; set; }
        
        [JsonProperty("previsao")]
        public List<Forecast> Forecast { get; set; }
    }
}