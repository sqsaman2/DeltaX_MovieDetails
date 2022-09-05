using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Http;
namespace DAL.ViewModels
{
    public class MovieViewModel 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Plot { get; set; }

        public DateTime DateOfRelease { get; set; }
        public List<Actor> Actors { get; set; }
        public string ProducerName { get; set; }
        public int? ProducerId { get; set; }
        public IFormFile PosterImage { get; set; }
        public int? PosterId { get; set; }
    }
}
