using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class BookDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Cover { get; set; }
        public string ISBN { get; set; }
        public string BookUrl { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Genre { get; set; }
    }
}
