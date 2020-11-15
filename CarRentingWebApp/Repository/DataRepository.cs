using System.Collections.Generic;
using System.Threading.Tasks;
using CarRentingWebApp.Models;
using Microsoft.EntityFrameworkCore;


namespace CarRentingWebApp.Repository
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _table;

        public DataRepository(ApplicationDbContext context)
        {
            this._context = context;
            this._table = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> SelectAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> SelectByID(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<T> SelectByCompositeKey(int movieId, int userId)
        {
            return await _table.FindAsync(movieId, userId);
        }

        public async Task Insert(T entity)
        {
            await _table.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task Update(T entity)
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T obj)
        {
            _table.Remove(obj);
            await _context.SaveChangesAsync();
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);

        }

        #endregion
    }
}
