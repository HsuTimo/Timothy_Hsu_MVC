using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timothy_Hsu_MVC.Interfaces;

namespace Timothy_Hsu_MVC.Repository
{
    public class GenericRepository<TContext> : IRepository where TContext : DbContext
    {
        private readonly TContext _context;
        public GenericRepository(TContext context)
        {
            _context = context;
        }
        public async Task CreateAsync<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> SelectAllAsync<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> SelectByIdAsync<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
