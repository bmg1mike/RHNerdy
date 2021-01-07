using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Dispatcher : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Dispatcher()
        {
            Orders = new HashSet<Order>();
        }
    }
}
