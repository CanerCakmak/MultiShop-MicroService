using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Context;
using MultiShop.Cargo.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CargoContext _context;

        public GenericRepository(CargoContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChangesAsync();
            });
        }

        public async Task DeleteByIdAsync(int id)
        {
            var value = await _context.Set<T>().FindAsync(id);

            if (value == null) return;

            await Task.Run(() =>
            {
                _context.Set<T>().Remove(value);
                _context.SaveChangesAsync();
            });
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().RemoveRange(entities);
                _context.SaveChangesAsync();
            });
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().Update(entity);
                _context.SaveChangesAsync();
            });
        }

        public async Task UpdateRangeAsync(IEnumerable<T> entities)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().UpdateRange(entities);
                _context.SaveChangesAsync();
            });
        }
    }
}
