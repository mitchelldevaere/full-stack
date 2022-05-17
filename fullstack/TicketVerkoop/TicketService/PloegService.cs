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
    public class PloegService : PloegIService<Ploeg>
    {
        private PloegIDAO<Ploeg> _PloegDAO;

        public PloegService(PloegIDAO<Ploeg> PloegDAO) // DI
        {
            _PloegDAO = PloegDAO;
        }

        public Task Add(Ploeg entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Ploeg entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Ploeg> FindById(int Id)
        {
            return await _PloegDAO.FindById(Id);
        }

        public async Task<Ploeg> FindByName(string name)
        {
            return await _PloegDAO.FindByName(name);
        }

        public async Task<IEnumerable<Ploeg>> GetAll()
        {
            return await _PloegDAO.GetAll();
        }

        public Task Update(Ploeg entity)
        {
            throw new NotImplementedException();
        }
    }
}
