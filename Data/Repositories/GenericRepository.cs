using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly NerdyContext _context;
        
        public GenericRepository(NerdyContext context)
        {
            _context = context;
            
        }
        public async Task<T> GetByIdAsync(string id, string includeProperties = null)
        {
            var query =  _context.Set<T>();

            if(includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = (DbSet<T>)query.Include(item);
                }
            }

            return await query.FindAsync(id);
        }

        

        public async Task<IReadOnlyList<T>> ListAllAsync(string includeProperties = null)
        {
            // includeProperties should contain a comma seperated list

            var query = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                {
                    query = (DbSet<T>)query.Include(item);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> Create(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            return result.Entity;
        }
        public async Task Delete(string id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            entity.IsDeleted = true;
        }
    }
}
