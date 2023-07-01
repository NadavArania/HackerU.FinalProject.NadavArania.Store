using HackerU.FinalProject.NadavArania.Store.Db.Context;
using HackerU.FinalProject.NadavArania.Store.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerU.FinalProject.NadavArania.Store.Core.Repositories
{
    public class OrderProductRepository : GenericRepository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(StoreContext db) : base(db)
        {
        }
    }
}
