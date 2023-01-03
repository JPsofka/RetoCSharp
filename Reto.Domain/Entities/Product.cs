using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reto.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public int InInventory { get; set; }
        public int Enabled { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
