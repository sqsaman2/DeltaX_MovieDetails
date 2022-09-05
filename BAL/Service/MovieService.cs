using DAL.Models;
using DAL.ViewModels;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BAL.Service
{
    public class MovieService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostBuilder webHostEnvironment;
        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetMovieById(int id)
        {
            return _context.Movie.Where(x => x.Id == id).ToList();
        }

        public IEnumerable<MovieViewModel> GetAllMovie()
        {
            try
            {
                var data = (from a in _context.Movie
                            select new MovieViewModel
                            {
                                Actors = _context.Actor_Movie.Where(x => x.MovieId == a.Id).Select(y => new Actor {Id=y.Id, Name=y.Actor.Name}).ToList(),
                                Id=a.Id,
                                Name=a.Name,
                                Plot=a.Plot,
                                ProducerName=a.Producer.Name,
                                DateOfRelease=a.DateOfRelease,                                
                            }
                          );
                return data.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private async Task<int> UploadedFile(IFormFile PosterImage)
        {

            try
            {
                var fileName = Path.GetFileName(PosterImage.FileName);
                var ms = new MemoryStream();
                PosterImage.OpenReadStream().CopyTo(ms);
                var ContentByte = ms.ToArray();
                var imgModel = new Image
                {
                    ContentByte = ms.ToArray(),
                    ContentType = PosterImage.ContentType,
                    ContentLength = PosterImage.FileName.Length,
                    FileName = fileName,
                    FileExtension = Path.GetExtension(PosterImage.FileName)
                };
                var obj = await _context.Image.AddAsync(imgModel);
                _context.SaveChanges();
                return obj.Entity.Id;
            }
            catch(Exception e)
            {
                throw e;
            }
                
            }

        //Add Movie
        public async Task<Movie> AddMovie(MovieViewModel movie)
        {
            try
            {
                var movData = new Movie();
                if (movie.PosterImage != null)
                {
                    var imgId = await UploadedFile(movie.PosterImage);
                    if (imgId != 0)
                    {
                        movData.PosterId = imgId;
                    }
                }                             
                movData.Name = movie.Name;
                movData.Plot = movie.Plot;
                movData.DateOfRelease = movie.DateOfRelease;
                movData.ProducerId = movie.ProducerId;
                movData.CreatedOn = DateTime.Now;
                movData.IsDeleted = false;
                var obj = await _context.Movie.AddAsync(movData);
                _context.SaveChanges();
                if (obj != null)
                {
                    foreach (var item in movie.Actors)
                    {
                        var actorMov = new Actor_Movie();
                        actorMov.MovieId = obj.Entity.Id;
                        actorMov.ActorId = item.Id;
                        actorMov.CreatedOn = DateTime.Now;
                        await _context.Actor_Movie.AddAsync(actorMov);
                        _context.SaveChanges();
                    }

                }

                return obj.Entity;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
        //Delete Movie 
        public bool DeleteMovie(int Id)
        {

            try
            {
                var Data = _context.Movie.FirstOrDefault(x => x.Id == Id);
                _context.Movie.Remove(Data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        //Update Movie Details
        public async Task<bool> UpdateMovie(MovieViewModel movie)
        {
            try
            {
                var movData = _context.Movie.FirstOrDefault(x=>x.Id==movie.Id);
                if (movie.PosterImage != null)
                {
                    var imgId = await UploadedFile(movie.PosterImage);
                    if (imgId != 0)
                    {
                        movData.PosterId = imgId;
                    }
                }
                movData.Name = movie.Name;
                movData.Plot = movie.Plot;
                movData.DateOfRelease = movie.DateOfRelease;
                movData.ProducerId = movie.ProducerId;
                movData.CreatedOn = DateTime.Now;
                movData.IsDeleted = false;
                var obj =  _context.Movie.Update(movData);
                _context.SaveChanges();
                var exist = _context.Actor_Movie.Where(x => x.MovieId == movie.Id).ToList();
                var dellist = exist.Select(x => x.ActorId).Except(movie.Actors.Select(y => y.Id)).ToList();
                var addlist2 = movie.Actors.Select(x => x.Id).Except(exist.Select(y => y.ActorId)).ToList();
                foreach (var item in dellist)
                {
                    var del = exist.FirstOrDefault(x => x.ActorId == item);
                    _context.Actor_Movie.Remove(del);
                    _context.SaveChanges();
                }
                foreach (var item in addlist2)
                 {
                     var actorMov = new Actor_Movie();
                     actorMov.MovieId = movie.Id;
                     actorMov.ActorId = item;
                     actorMov.CreatedOn = DateTime.Now;
                     await _context.Actor_Movie.AddAsync(actorMov);
                     _context.SaveChanges();
                 }

                return true; 
            }
            catch (Exception e)
            {
                //throw e;
                return false;
            }
        }
    }
}