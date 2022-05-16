using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketRepositories.interfaces
{
    public interface UserIDAO<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(int id);
        Task Add(T entity);
        Task Delete(T entity);

        Task Update(T entity);
        Task<T> FindByName(string name);
    }
}
