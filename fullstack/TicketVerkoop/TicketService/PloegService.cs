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

        public PloegService(PloegIDAO<Ploeg> _PloegDAO) // DI
        {
                _PloegDAO = _PloegDAO;
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
            return await _PloegDAO.GetAll();
        }

        public Task Update(Ploeg entity)
        {
            throw new NotImplementedException();
        }
    }
}
