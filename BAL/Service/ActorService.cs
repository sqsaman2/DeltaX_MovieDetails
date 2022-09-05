using DAL.Models;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class ActorService
    {
        private readonly ApplicationDbContext _context;

        public ActorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Actor> GetActorById(int id)
        {
            return _context.Actor.Where(x => x.Id == id).ToList();
        }

        public IEnumerable<Actor> GetAllActor()
        {
            try
            {
                return _context.Actor.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Add Actor
        public async Task<Actor> AddActor(Actor movie)
        {
            var obj = await _context.Actor.AddAsync(movie);
            _context.SaveChanges();
            return obj.Entity;
        }
        //Delete Actor 
        public bool DeleteActor(int Id)
        {

            try
            {
                var Data = _context.Actor.Where(x => x.Id == Id);
                _context.Remove(Data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        //Update Actor Details
        public bool UpdateActor(Actor movie)
        {
            try
            {
               // var DataList = _context.Actor.Where(x => x.IsDeleted != true).ToList();
                _context.Actor.Update(movie);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}