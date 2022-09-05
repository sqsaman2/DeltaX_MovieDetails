using BAL.Service;
using DAL.Models;
using DAL.ViewModels;
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
    public class MovieController : ControllerBase
    {

        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }
        //Add Movie
        [HttpPost("AddMovie")]
        public async Task<Object> AddMovie([FromBody] MovieViewModel movie)
        {
            try
            {

                await _movieService.AddMovie(movie);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //Delete Movie
        [HttpDelete("DeleteMovie")]
        public bool DeleteMovie(int id)
        {
            try
            {
                _movieService.DeleteMovie(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Delete Movie
        [HttpPut("UpdateMovie")]
        public bool UpdateMovie(MovieViewModel Object)
        {
            try
            {
                _movieService.UpdateMovie(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //GET  Movie by Id
        [HttpGet("GetMovieById")]
        public Object GetMovieById(int id)
        {
            var data = _movieService.GetMovieById(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Movie
        [HttpGet("GetAllMovies")]
        public Object GetAllMovies()
        {
            var data = _movieService.GetAllMovie();
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
