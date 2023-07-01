using HackerU.FinalProject.NadavArania.Store.Db.ITypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerU.FinalProject.NadavArania.Store.Core.DTOs
{
    public class ProductDTO
    {
        public PType Type { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public PCat Category { get; set; }
        public int Quantity { get; set; }
    }
}
