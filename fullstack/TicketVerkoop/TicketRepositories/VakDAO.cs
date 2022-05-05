using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketModels.Data;
using TicketModels.Entities;
using TicketRepositories.interfaces;

namespace TicketRepositories
{
    public class VakDAO : VakIDAO<Vak>
    {
        private readonly TicketVerkoopDbContext _dbContext;
        public VakDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public Task Add(Vak entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Vak entity)
        {
            throw new NotImplementedException();
        }

        public Task<Vak> FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Vak>> GetAll(int id)
        {
            try
            {
                return await _dbContext.Vaks
                    .Include(b => b.Stadion)
                    .Where(b => b.StadionId == id)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw new Exception("error DAO beer");

            }
        }

        public Task Update(Vak entity)
        {
            throw new NotImplementedException();
        }
    }
}
