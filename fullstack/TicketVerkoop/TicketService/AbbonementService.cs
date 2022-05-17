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
    public class AbbonementService : AbbonementIService<Abbonement>
    {
        private AbbonementIDAO<Abbonement> _abbonementDAO;

        public AbbonementService(AbbonementIDAO<Abbonement> abbonenementDAO) // DI
        {
            _abbonementDAO = abbonenementDAO;
        }

        public Task Add(Abbonement entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Abbonement entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Abbonement> FindById(int ploegID, int seizoenID)
        {
            return await _abbonementDAO.FindById(ploegID, seizoenID);
        }

        public Task<IEnumerable<Abbonement>> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Abbonement entity)
        {
            throw new NotImplementedException();
        }
    }
}
