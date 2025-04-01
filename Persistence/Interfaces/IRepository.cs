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
        Task<OperationResult<T>> Delete(string id);
        Task<OperationResult<T>> Update(T entity);
        Task<OperationResult<T>> Get(string id);
        Task<OperationResult<T>> Add(T entity);
        Task<OperationResult<List<T>>> GetAll();
    }
}
