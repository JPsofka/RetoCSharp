using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string? IdType { get; set; }
        public int Id { get; set; }
        public string? ClientName { get; set; }


    }
}
