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
    public class ActorController : ControllerBase
    {
        private readonly ActorService _actorService;

        public ActorController(ActorService actorService)
        {
            _actorService = actorService;
        }
        //Add Actor
        [HttpPost("AddActor")]
        public async Task<Object> AddActor([FromBody] Actor movie)
        {
            try
            {
                await _actorService.AddActor(movie);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete Actor
        [HttpDelete("DeleteActor")]
        public bool DeleteActor(int id)
        {
            try
            {
                _actorService.DeleteActor(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete Actor
        [HttpPut("UpdateActor")]
        public bool UpdateActor(Actor Object)
        {
            try
            {
                _actorService.UpdateActor(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //GET  Actor by Id
        [HttpGet("GetActorById")]
        public Object GetActorById(int id)
        {
            var data = _actorService.GetActorById(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Actor
        [HttpGet("GetAllActors")]
        public Object GetAllActors()
        {
            var data = _actorService.GetAllActor();
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
