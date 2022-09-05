using BAL.Service;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeltaX_MovieDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly ProducerService _producerService;

        public ProducerController(ProducerService producerService)
        {
            _producerService = producerService;
        }
        //Add Producer
        [HttpPost("AddProducer")]
        public async Task<Object> AddProducer([FromBody] Producer movie)
        {
            try
            {
                await _producerService.AddProducer(movie);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete Producer
        [HttpDelete("DeleteProducer")]
        public bool DeleteProducer(int id)
        {
            try
            {
                _producerService.DeleteProducer(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete Producer
        [HttpPut("UpdateProducer")]
        public bool UpdateProducer(Producer Object)
        {
            try
            {
                _producerService.UpdateProducer(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //GET  Producer by Id
        [HttpGet("GetProducerById")]
        public Object GetProducerById(int id)
        {
            var data = _producerService.GetProducerById(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Producer
        [HttpGet("GetAllProducers")]
        public Object GetAllProducers()
        {
            var data = _producerService.GetAllProducer();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
