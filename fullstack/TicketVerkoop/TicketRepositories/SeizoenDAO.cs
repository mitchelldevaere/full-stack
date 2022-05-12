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
    public class SeizoenDAO : SeizoenIDAO<Seizoen>
    {
        private readonly TicketVerkoopDbContext _dbContext;
        public SeizoenDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public Task Add(Seizoen entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Seizoen entity)
        {
            throw new NotImplementedException();
        }

        public Task<Seizoen> FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Seizoen>> GetAll()
        {
            try
            {
                return await _dbContext.Seizoens
                    .ToListAsync(); // volgende Namespaces toevoegen bovenaan using System.Linq; using Microsoft.EntityFrameworkCore;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw new Exception("error DAO beer");

            }
        }

        public Task Update(Seizoen entity)
        {
            throw new NotImplementedException();
        }
    }
}
