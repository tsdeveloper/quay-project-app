using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Core.Dtos;
using AutoMapper;
using Common.Extensions.Enumeration;
using Core.Entities;
using Core.Specifications.Cities.SpecParams;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CityDetailsController : ControllerBase
    {
        private readonly IMapper _mapper;
        public CityDetailsController(IMapper mapper)
        {
            _mapper = mapper;
        }

       
        
        // GET
        [HttpGet]
        [Route("get-forecast")]
        public async Task<ActionResult<CityToReturnDto>> GetForecast([FromQuery] CitySpecParams citySpecParams)
        {
            var cityDto = new CityToReturnDto();
            var client = new RestClient("http://servicos.cptec.inpe.br");
            var request = new RestRequest($"XML/cidade/7dias/{citySpecParams.Id}/previsao.xml", DataFormat.Xml);
            request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer();
          
            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
           
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(response.Content);

                var jsonText = JsonConvert.SerializeXmlNode(doc);
              dynamic input = JsonConvert.DeserializeObject(jsonText);

                var resultString =  JsonConvert.SerializeObject(input.cidade);
                var resultJson =  JsonConvert.DeserializeObject<City>(resultString);
                var cityMapper = _mapper.Map<City>(resultJson);
                var result = _mapper.Map<CityToReturnDto>(cityMapper);
                cityDto = result;


            }

            return Ok(cityDto);
        }
        
        
        [HttpGet]
        [Route("get-city")]
        public async Task<ActionResult<CityToReturnDto>> GetCity([FromQuery] CitySpecParams citySpecParams)
        {
            var cityDto = new CityToReturnDto();
            var client = new RestClient("http://servicos.cptec.inpe.br");
            var request = new RestRequest($"XML/listaCidades?city={citySpecParams.Id}", DataFormat.Xml);
            request.XmlSerializer = new RestSharp.Serializers.DotNetXmlSerializer();
          
            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
           
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(response.Content);

                var jsonText = JsonConvert.SerializeXmlNode(doc);
                dynamic input = JsonConvert.DeserializeObject(jsonText);

                var resultString =  JsonConvert.SerializeObject(input.cidade);
                var resultJson =  JsonConvert.DeserializeObject<City>(resultString);
                var cityMapper = _mapper.Map<City>(resultJson);
                var result = _mapper.Map<CityToReturnDto>(cityMapper);
                cityDto = result;


            }

            return Ok(cityDto);
        }
    }
}