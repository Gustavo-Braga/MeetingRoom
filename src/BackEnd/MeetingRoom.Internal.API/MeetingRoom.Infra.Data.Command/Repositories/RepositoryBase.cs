using MeetingRoom.Domain.Interfaces;
using MeetingRoom.Infra.Data.Command.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MeetingRoom.Infra.Data.Command.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DbContext _dbContext;
        protected DbSet<T> _dbSet;

        public RepositoryBase(MeetingRoomDBContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var entityEntry = await _dbSet.AddAsync(entity);
            return entityEntry.Entity;
        }

        public virtual async Task DeleteAsync(object id)
        {
            var response = await _dbSet.FindAsync(id);
            _dbSet.Remove(response);
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await Task.Run(() =>
            {
                return _dbSet.AsQueryable<T>().AsEnumerable();
            });
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Func<T, bool> predicate)
        {
            return await Task.Run(() =>
            {
                return _dbSet.AsQueryable().Where(predicate).AsEnumerable();

            });
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            return await Task.Run(() =>
            {
                _dbContext.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;

                //_unitOfWork.Context.Entry(exists).CurrentValues.SetValues(currentValues);
                //var entityEntry = _unitOfWork.Context.Set<T>().Update(exists);
                return entity;
            });
        }

        public virtual async Task<T> SingleOrDefault(Expression<Func<T, bool>> expression)
        {
            return await Task.Run(() =>
            {
                var entityEntry = _dbSet.SingleOrDefault(expression);
                return entityEntry;
            });

        }

        public virtual async Task DetachLocal(Func<T, bool> expression)
        {
            await Task.Run(() =>
            {
                var local = _dbSet.Local.Where(expression).FirstOrDefault();
                if (local != null)
                    _dbContext.Entry(local).State = EntityState.Detached;
            });

        }

        public async Task<bool> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
