using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketModels.Entities;
using TicketRepositories.interfaces;
using TicketService.interfaces;

namespace TicketService
{
    public class UserService : UserIService<AspNetUser>
    {
        private UserIDAO<AspNetUser> _userDAO;

        public UserService(UserIDAO<AspNetUser> userDAO) // DI
        {
            _userDAO = userDAO;
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
            return await _userDAO.FindByName(name);
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
