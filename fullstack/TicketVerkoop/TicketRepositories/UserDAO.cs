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
    public class UserDAO : UserIDAO<AspNetUser>
    {
        private readonly TicketVerkoopDbContext _dbContext;
        public UserDAO()
        {
            _dbContext = new TicketVerkoopDbContext();
        }

        public Task Add(AspNetUser entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(AspNetUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<AspNetUser> FindByName(string name)
        {
            try
            {
                return await _dbContext.AspNetUsers.Where(u => u.UserName == name)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error in DAO");
                return null;
            }
        }

        public Task<IEnumerable<AspNetUser>> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(AspNetUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
