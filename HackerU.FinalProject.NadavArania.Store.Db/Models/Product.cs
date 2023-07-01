using HackerU.FinalProject.NadavArania.Store.Db.ITypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerU.FinalProject.NadavArania.Store.Db.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public PType Type { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        public List<Order> Orders { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public PCat Category { get; set; }
        [Required]
        public int Quantity { get; set; }
        [NotMapped]
        public bool Added { get; set; }
    }
}
