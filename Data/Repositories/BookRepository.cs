using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BookRepository : GenericRepository<Book>,IBookRepository
    {
        private readonly NerdyContext _context;
        public BookRepository(NerdyContext context) : base(context)
        {
            _context = context;
        }
    }
}
