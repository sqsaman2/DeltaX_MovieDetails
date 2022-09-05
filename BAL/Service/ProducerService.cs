using DAL.Models;
using DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class ProducerService
    {
        private readonly ApplicationDbContext _context;

        public ProducerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Producer> GetProducerById(int id)
        {
            return _context.Producer.Where(x => x.Id == id).ToList();
        }

        public IEnumerable<Producer> GetAllProducer()
        {
            try
            {
                return _context.Producer.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Add Producer
        public async Task<Producer> AddProducer(Producer movie)
        {
            var obj = await _context.Producer.AddAsync(movie);
            _context.SaveChanges();
            return obj.Entity;
        }
        //Delete Producer 
        public bool DeleteProducer(int Id)
        {

            try
            {
                var Data = _context.Producer.Where(x => x.Id == Id);
                _context.Remove(Data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        //Update Producer Details
        public bool UpdateProducer(Producer movie)
        {
            try
            {
               // var DataList = _context.Producer.Where(x => x.IsDeleted != true).ToList();
                _context.Producer.Update(movie);
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