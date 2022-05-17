﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketService.interfaces
{
    public interface AbbonementIService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(int id);
        Task Add(T entity);
        Task Delete(T entity);

        Task Update(T entity);
        Task<T> FindById(int ploegID, int seizoenID);
    }
}
