using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.DomainModel.DTO
{
    public class AddUpdateProductDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
        public int LowStockThreshold { get; set; }
    }
}
