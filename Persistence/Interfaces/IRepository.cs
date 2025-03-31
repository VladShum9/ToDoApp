using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Interfaces
{
    public interface IRepository<T>
    {
        Task Delete(string id);
        Task Update(T entity);
        Task<T> Get(string id);
        Task<OperationResult<T>> Add(T entity);
        Task<List<T>> GetAll();
    }
}
