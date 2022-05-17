using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketModels.Data;
using TicketModels.Entities;

namespace TicketRepositories.interfaces
{
    public class AbbonementDAO : AbbonementIDAO<Abbonement>
    {
        private readonly TicketVerkoopDbContext _dbContext;
        public AbbonementDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public Task Add(Abbonement entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Abbonement entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Abbonement> FindById(int ploegID, int seizoenID)
        {
            try
            {
                return await _dbContext.Abbonements
                    .Include(b => b.Ploeg)
                    .Include(b => b.Seizoen)
                    .Where(b => b.PloegId == ploegID)
                    .Where(b => b.SeizoenId == seizoenID)
                    .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw new Exception("error DAO beer");

            }
        }

        public Task<IEnumerable<Abbonement>> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Abbonement entity)
        {
            throw new NotImplementedException();
        }
    }
}
