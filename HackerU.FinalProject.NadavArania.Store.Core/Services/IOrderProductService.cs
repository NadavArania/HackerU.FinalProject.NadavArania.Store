using HackerU.FinalProject.NadavArania.Store.Core.DTOs;
using HackerU.FinalProject.NadavArania.Store.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerU.FinalProject.NadavArania.Store.Core.Services
{
    public interface IOrderProductService
    {
        //Crud Function With Get's Function For OrderProduct
        List<OrderProduct> GetAllOrderProducts();
        OrderProduct GetById(int id);
        void AddOrderProduct(OrderProductDTO op);
        void UpdateOrderProduct(OrderProduct op);
        void DeleteOrderProduct(OrderProduct op);
    }
}
