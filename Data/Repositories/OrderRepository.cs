using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class OrderRepository : GenericRepository<Order>,IOrderRepository
    {
        private readonly NerdyContext _context;
        public OrderRepository(NerdyContext context):base(context)
        {

        }
    }
}
