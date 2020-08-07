using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Core.Entities
{
    public class Forecast : BaseEntity
    {
        [JsonProperty("dia")]
        public DateTime Day { get; set; }
        
        [JsonProperty("tempo")]
        public Time Time { get; set; }
        
        [JsonProperty("minima")]
        public int Min { get; set; }
        
        [JsonProperty("maxima")]
        public int Max { get; set; }
        
        [JsonProperty("iuv")]
        public double Iuv { get; set; }
    }

    public enum Time
    {
        
        [Description("Não Informado")]
        NI = 0,

        [Description("Encoberto com Chuvas Isoladas")]
        EC = 1,
        
        [Description("Chuvas Isoladas")]
        CI = 2,
        
        [Description("Chuva")]
        C = 3,
        
        [Description("Instável")]
        IN = 4,
        
        [Description("Possibilidade de Pancadas de Chuva")]
        PP = 5,
        
        [Description("Chuva pela Manhã")]
        CM = 6,
        
        [Description("Chuva pela Noite")]
        CN = 7,
        
        [Description("Pancadas de Chuva a Tarde")]
        PT = 8,
        
        [Description("Pancadas de Chuva pela Manhã")]
        PM = 9,
        
        [Description("Nublado e Pancadas de Chuva")]
        NP= 10,
        
        [Description("Pancadas de Chuva")]
        PC= 11,
        
        [Description("Parcialmente Nublado")]
        PN= 12,
        
        [Description("Chuvisco")]
        CV= 13,
        
        [Description("Chuvoso")]
        CH= 14,
        
        [Description("Tempestade")]
        T= 15,
        
        [Description("Predomínio de Sol")]
        PS= 16,
        
        [Description("Encoberto")]
        E=  17,
        
        [Description("Nublado")]
        N=  18,
        
        [Description("Céu Claro")]
        CL= 19,
        
        [Description("Nevoeiro")]
        NV=  20,
        
        [Description("Geada")]
        G= 21,
        
        [Description("Neve")]
        NE= 22,
        
        [Description("Pancadas de Chuva a Noite")]
        PNT= 23,
        
        [Description("Possibilidade de Chuva")]
        PSC= 24,
        
        [Description("Possibilidade de Chuva pela Manhã")]
        PCM= 25,
        
        [Description("Possibilidade de Chuva a Tarde")]
        PCT=  26,
        
        [Description("Possibilidade de Chuva a Noite")]
        PCN= 27,
        
        [Description("Nublado com Pancadas a Tarde")]
        NPT= 28,
        
        [Description("Nublado com Pancadas a Noite")]
        NPN= 29,
        
        [Description("Nublado com Possibilidade de Chuva a Noite")]
        NCN= 30,
        
        [Description("Nublado com Possibilidade de Chuva a Tarde")]
        NCT= 31,
        
        [Description("Nublado com Possibilidade de Chuva pela Manhã")]
        NCM= 32,
        
        [Description("Nublado com Pancadas pela Manhã")]
        NPM= 33,
        
        [Description("Nublado com Possibilidade de Chuva")]
        NPP= 34,
        
        [Description("Variação de Nebulosidade")]
        VN= 35,
        
        [Description("Chuva a Tarde")]
        CT= 36,
        
        [Description("Possibilidade de Pancadas de Chuva a Noite")]
        PPN=37,
        
        [Description("Possibilidade de Pancadas de Chuva a Tarde")]
        PPT= 38,
        
        [Description("Possibilidade de Pancadas de Chuva pela Manhã")]
        PPM= 39,
        
        [Description("Não Definido")]
        LT= 40,
    }
}