using HackerU.FinalProject.NadavArania.Store.Core.DTOs;
using HackerU.FinalProject.NadavArania.Store.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerU.FinalProject.NadavArania.Store.Core.Services
{
    public interface IOrderService
    {
        //Crud Function With Get's Function For Order
        List<Order> GetAllOrders ();
        Order GetOrderById(int id);
        void AddOrder(OrderDTO order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
