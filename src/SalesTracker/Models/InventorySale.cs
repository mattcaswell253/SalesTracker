using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models
{
    [Table("InventorySales")]
    public class InventorySale
    {
        [Key]
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
