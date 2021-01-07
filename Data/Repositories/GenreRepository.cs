using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GenreRepository:GenericRepository<Genre>, IGenreRepository
    {
        private NerdyContext _context;
        public GenreRepository(NerdyContext context):base(context)
        {
            _context = context;
        }
    }
}
