using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmailAddress { get; set; }
        public string CustomerAddress { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        [ForeignKey("PlatformId")]
        public OrderPlatform Platform { get; set; }
        public string PlatformId { get; set; }
        public Dispatcher Dispatcher { get; set; }
        [ForeignKey("Dispatcher")]
        public string DispatcherId { get; set; }
        public ICollection<Book> Books { get; set; }
        public OrderStatus Status { get; set; }
        public Order()
        {
            Books = new HashSet<Book>();
        }
    }
}
