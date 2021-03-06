using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketModels.Entities;

namespace TicketService.interfaces
{
    public interface ReserveringIService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(string userID);
        Task<IEnumerable<T>> GetAllTrue(string userID, bool cancelled);
        Task Add(T entity);
        Task Delete(T entity);

        Task Update(T entity);
        Task<T> FindById(int Id);
    }
}
