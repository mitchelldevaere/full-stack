﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketRepositories.interfaces
{
    public interface ReserveringIDAO<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Delete(T entity);

        Task Update(T entity);
        Task<T> FindById(int Id);
    }
}
