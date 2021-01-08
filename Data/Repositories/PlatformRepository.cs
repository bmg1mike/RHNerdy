using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PlatformRepository : GenericRepository<OrderPlatform>, IPlatformRepository
    {
        private readonly NerdyContext _context;
        public PlatformRepository(NerdyContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<OrderPlatform> UpdateOrderPlatform(string id, OrderPlatform platform)
        //{
        //    var orderPlatform = await _context.OrderPlatforms.FindAsync(id);
        //    orderPlatform.Platform = platform.Platform;
        //    orderPlatform.DateModified = platform.DateModified;

        //}
    }
}
