using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketService.interfaces
{
    public interface PloegIService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Delete(T entity);

        Task Update(T entity);
        Task<T> FindById(int Id);
        Task<T> FindByName(string name);
    }
}
