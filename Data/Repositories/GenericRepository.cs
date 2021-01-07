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
        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Create(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            return result.Entity;
        }


        public async Task<T> Update(string id,T entity)
        {
            throw new NotImplementedException();
        }

    }
}
