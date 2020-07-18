using MeetingRoom.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MeetingRoom.Infra.Data.Command.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<object> AddAsync(T entity)
        {
            return await _unitOfWork.Context.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(async () =>
             {
                 _unitOfWork.Context.Set<T>().Remove(await _unitOfWork.Context.Set<T>().FindAsync(entity));
             });
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await Task.Run(() =>
            {
                return _unitOfWork.Context.Set<T>().AsQueryable<T>().AsEnumerable();
            });
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.Run(() =>
            {
                return _unitOfWork.Context.Set<T>().AsQueryable<T>().Where(expression).AsEnumerable();

            });
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
                _unitOfWork.Context.Set<T>().Attach(entity);
            });
        }
    }
}
