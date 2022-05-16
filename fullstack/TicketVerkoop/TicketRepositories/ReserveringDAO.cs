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

        public async Task<Reservering> FindById(int Id)
        {
            try
            {
                return await _dbContext.Reserverings
                    .Where(b => b.ReserveringId == Id)
                    .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw new Exception("error DAO beer");

            }
        }

        public async Task<IEnumerable<Reservering>> GetAll(string userID)
        {
            try
            {
                return await _dbContext.Reserverings
                    .Include(b => b.User)
                    .Include(b => b.Vak)
                    .Include(b => b.Match)
                    .Include(b => b.AbbonnementNavigation)
                    .Where(b => b.UserId == userID)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                throw new Exception("error DAO beer");

            }
        }

        public async Task Update(Reservering entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
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
    }
}
