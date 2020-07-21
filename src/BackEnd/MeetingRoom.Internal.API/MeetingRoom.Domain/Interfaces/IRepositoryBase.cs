using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MeetingRoom.Domain.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<T> AddAsync(T entity);
        Task DeleteAsync(object id);
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> UpdateAsync(T entity);
        Task<T> SingleOrDefault(Expression<Func<T, bool>> expression);
        Task<bool> CommitAsync();
    }
}
