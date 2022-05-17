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
    public class ReserveringService : ReserveringIService<Reservering>
    {
        private ReserveringIDAO<Reservering> _reserveringDAO;

        public ReserveringService(ReserveringIDAO<Reservering> reserveringDAO) // DI
        {
            _reserveringDAO = reserveringDAO;
        }

        public async Task Add(Reservering entity)
        {
            await _reserveringDAO.Add(entity);
        }

        public Task Delete(Reservering entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Reservering> FindById(int Id)
        {
            return await _reserveringDAO.FindById(Id);
        }

        public async Task<IEnumerable<Reservering>> GetAll(string userID)
        {
            return await _reserveringDAO.GetAll(userID);
        }

        public async Task<IEnumerable<Reservering>> GetAllTrue(string userID, bool cancelled)
        {
            return await _reserveringDAO.GetAllTrue(userID, cancelled);
        }

        public async Task Update(Reservering entity)
        {
            await _reserveringDAO.Update(entity);
        }
    }
}
