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
    public class PloegDAO : PloegIDAO<Ploeg>
    {
        private readonly TicketVerkoopDbContext _dbContext;
        public PloegDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public Task Add(Ploeg entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Ploeg entity)
        {
            throw new NotImplementedException();
        }

        public Task<Ploeg> FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ploeg>> GetAll()
        {
            try
            {
                return await _dbContext.Ploegs
                    .ToListAsync(); // volgende Namespaces toevoegen bovenaan using System.Linq; using Microsoft.EntityFrameworkCore;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw new Exception("error DAO beer");

            }
        }

        public Task Update(Ploeg entity)
        {
            throw new NotImplementedException();
        }
    }
}
