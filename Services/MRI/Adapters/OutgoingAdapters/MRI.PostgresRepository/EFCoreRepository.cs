using Microsoft.EntityFrameworkCore;
using MRI.Domain.Entities.Abstract;
using MRI.OutgoingPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MRI.PostgresRepository
{
    public class EFCoreRepository : IRepository
    {
        readonly DbContext _db;

        public EFCoreRepository(MriDbContext mriDbContext)
        {
            _db = mriDbContext;
        }
        public async Task<T> Get<T>(int id) where T : Entity
        {
            return await _db.Set<T>().SingleOrDefaultAsync(t => t.Id == id);
        }
        public async Task Save<T>(T entity) where T : Entity
        {
            if (entity.Id < 1)
            {
                _db.Set<T>().Add(entity);
                await _db.SaveChangesAsync();
            }
            else
            {
                var cache = _db.Set<T>().Find(entity.Id);
                _db.Entry<T>(cache).CurrentValues.SetValues(entity);
                await _db.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<T>> GetAll<T>() where T : Entity
        {
            //return await db.Set<T>().OrderBy(t => t.Id).ToListAsync();//.AsQueryable(); // спросить у Егорова
            var result = await _db.Set<T>().OrderBy(t => t.Id).ToListAsync();
            return result.AsQueryable();    // спросить у егорова
        }
        public async Task Remove<T>(T entity) where T : Entity
        {
            var cache = await _db.Set<T>().FindAsync(entity.Id);    //Todo
            _db.Set<T>().Remove(cache);
            await _db.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetBy<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            var result = await _db.Set<T>().Where(predicate).ToListAsync();
            return result;
        }

        public async Task Update<T>(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
        public void Dispose()     // Async?
        {
            _db.Dispose();
        }
    }
}
