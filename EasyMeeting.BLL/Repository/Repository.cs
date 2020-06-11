using EasyMeeting.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using EasyMeeting.Common.Interfaces;

namespace EasyMeeting.BLL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _context;
        public Repository(EasyMeetingDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        ///<inheridoc/>
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }
        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }
        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }
        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }

}
