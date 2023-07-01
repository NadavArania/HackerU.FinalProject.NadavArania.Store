using HackerU.FinalProject.NadavArania.Store.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerU.FinalProject.NadavArania.Store.Core.DTOs
{
    public class OrderDTO
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
    }
}
