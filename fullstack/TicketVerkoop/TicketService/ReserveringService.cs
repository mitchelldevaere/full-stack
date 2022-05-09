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
        private ReserveringIService<Reservering> _reserveringDAO;

        public ReserveringService(ReserveringIService<Reservering> reserveringDAO) // DI
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
