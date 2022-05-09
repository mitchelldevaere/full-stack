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
    public class ReserveringDAO : ReserveringIDAO<Reservering>
    {
        private readonly TicketVerkoopDbContext _dbContext;
        public ReserveringDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public async Task Add(Reservering entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("error in DAO");
            }
        }

        public Task Delete(Reservering entity)
        {
            throw new NotImplementedException();
        }

        public Task<Reservering> FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservering>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Reservering entity)
        {
            throw new NotImplementedException();
        }
    }
}
