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
    public class MatchDAO : IDAO<Match>
    {
        private readonly TicketVerkoopDbContext _dbContext;
        public MatchDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public Task Add(Match entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Match entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Match> FindById(int Id)
        {
            try
            {// select * from Bieren
                return await _dbContext.Matches.Where(b => b.MatchId == Id)
                    .Include(b => b.Thuisploeg)
                    .Include(b => b.Uitploeg)
                    .Include(b => b.Stadion)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw new Exception("error DAO beer");

            }
        }

        public async Task<IEnumerable<Match>> GetAll()
        {
            try
            { 
                return await _dbContext.Matches
                    .Include(b => b.Thuisploeg)
                    .Include(b => b.Uitploeg)
                    .Include(b => b.Stadion)
                    .ToListAsync(); // volgende Namespaces toevoegen bovenaan using System.Linq; using Microsoft.EntityFrameworkCore;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw new Exception("error DAO beer");

            }
        }

        public Task Update(Match entity)
        {
            throw new NotImplementedException();
        }
    }
}
