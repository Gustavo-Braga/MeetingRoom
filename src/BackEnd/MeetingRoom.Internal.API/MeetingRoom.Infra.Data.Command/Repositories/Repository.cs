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

        public async Task<T> AddAsync(T entity)
        {
            var entityEntry = await _unitOfWork.Context.Set<T>().AddAsync(entity);
            return entityEntry.Entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() =>
             {
                 _unitOfWork.Context.Set<T>().Remove(entity);
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

        public async Task<T> UpdateAsync(T entity)
        {
            return await Task.Run(() =>
            {
                _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
                var entityEntry = _unitOfWork.Context.Set<T>().Attach(entity);
                return entityEntry.Entity;
            });
        }

        public async Task<T> SingleOrDefault(Expression<Func<T, bool>> expression)
        {
            return await Task.Run(() =>
            {
                var entityEntry = _unitOfWork.Context.Set<T>().SingleOrDefault(expression);
                return entityEntry;
            });

        }
    }
}
