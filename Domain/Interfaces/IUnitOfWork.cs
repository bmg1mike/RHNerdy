using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        IBookRepository Book { get; }
        IGenreRepository Genre { get; }
        IPlatformRepository Platform { get; }
        IOrderRepository Order { get; }
        Task<int> Complete();
    }
}
