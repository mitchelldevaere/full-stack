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
    public class SeizoenService : SeizoenIService<Seizoen>
    {
        private SeizoenIDAO<Seizoen> _seizoenDAO;

        public SeizoenService(SeizoenIDAO<Seizoen> seizoenDAO) // DI
        {
            _seizoenDAO = seizoenDAO;
        }

        public Task Add(Seizoen entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Seizoen entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Seizoen> FindById(int Id)
        {
            return await _seizoenDAO.FindById(Id);
        }

        public async Task<IEnumerable<Seizoen>> GetAll()
        {
            return await _seizoenDAO.GetAll();
        }

        public Task Update(Seizoen entity)
        {
            throw new NotImplementedException();
        }
    }
}
