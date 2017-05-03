using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalesTracker.Models
{
    [Table("Inventory")]
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<InventorySale> InventorySales { get; set; }

        public Inventory(string name, string description, string price, int id = 0)
        {
            Name = name;
            Description = description;
            Price = price;
        }
        public Inventory() { }
    }
}
