using System;
using System.Collections.Generic;
using System.Text;

namespace Complements.Repository;

public interface IRepository<T>
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
}
