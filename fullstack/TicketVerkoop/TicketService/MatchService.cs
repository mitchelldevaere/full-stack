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
    public class MatchService : IService<Match>
    {
        private IDAO<Match> _matchDAO;

        public MatchService(IDAO<Match> matchDAO) // DI
        {
            _matchDAO = matchDAO;
        }

        public Task Add(Match entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Match entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Match> FindById(int Id)
        {
            return await _matchDAO.FindById(Id);
        }

        public async Task<IEnumerable<Match>> GetAll()
        {
            return await _matchDAO.GetAll();
        }

        public Task Update(Match entity)
        {
            throw new NotImplementedException();
        }
    }
}
