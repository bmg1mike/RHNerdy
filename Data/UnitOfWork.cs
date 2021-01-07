using Data.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NerdyContext _context;
        public IBookRepository Book { get; private set; }
        public IGenreRepository Genre { get; private set; }
        public IPlatformRepository Platform { get; private set; }
        public IOrderRepository Order { get; private set; }
        public UnitOfWork(NerdyContext context)
        {
            _context = context;
            Book = new BookRepository(context);
            Genre = new GenreRepository(context);
            Platform = new PlatformRepository(context);
            Order = new OrderRepository(context);
        }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        //public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        //{
        //    if(_repositories == null)
        //    {
        //        _repositories = new Hashtable();
        //    }

        //    var type = typeof(TEntity).Name;

        //    if (!_repositories.ContainsKey(type))
        //    {
        //        var repositoryType = typeof(GenericRepository<>);
        //        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)),_context);
        //        _repositories.Add(type, repositoryInstance);
        //    }
        //    return (IGenericRepository<TEntity>)_repositories[type];
        //}
    }
}
