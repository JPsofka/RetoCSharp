using Reto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Domain.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string? IdType { get; set; }
        public int Id { get; set; }
        public string? ClientName { get; set; }
        public List<Purchase>? Purchases { get; set; }
    }
}
