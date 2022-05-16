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
    public class VakService : VakIService<Vak>
    {
        private VakIDAO<Vak> _vakDAO;

        public VakService(VakIDAO<Vak> vakDAO) // DI
        {
            _vakDAO = vakDAO;
        }

        public Task Add(Vak entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Vak entity)
        {
            throw new NotImplementedException();
        }

        public Task<Vak> FindById(int Id)
        {
            return _vakDAO.FindById(Id);
        }

        public async Task<IEnumerable<Vak>> GetAll(int id)
        {
            return await _vakDAO.GetAll(id);
        }

        public async Task Update(Vak entity)
        {
            await _vakDAO.Update(entity);
        }
    }
}
