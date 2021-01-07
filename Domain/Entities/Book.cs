using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public BookCover Cover { get; set; }
        public string ISBN { get; set; }
        public string BookUrl { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public ICollection<Genre> Genres { get; set; }

        public Book()
        {
            Genres = new HashSet<Genre>();
        }
    }
}
