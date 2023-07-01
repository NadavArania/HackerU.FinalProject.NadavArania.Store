using AutoMapper;
using HackerU.FinalProject.NadavArania.Store.Core.DTOs;
using HackerU.FinalProject.NadavArania.Store.Core.Repositories;
using HackerU.FinalProject.NadavArania.Store.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerU.FinalProject.NadavArania.Store.Core.Services
{
    //Using Unit Of Work And His Interface And Connecting with The Order Controller
    public class OrderService : IOrderService
    {
        public IUnitOfWork unit;
        private readonly IMapper mapper;

        public OrderService(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public List<Order> GetAllOrders()
        {
            return unit.OrderRepository.GetList();
        }

        public Order GetOrderById(int id)
        {
            return unit.OrderRepository.GetById(id);
        }

        public void AddOrder(OrderDTO order)
        {
            var newOrder = mapper.Map<OrderDTO, Order>(order);
            if (newOrder != null)
            {
                unit.OrderRepository.Add(newOrder);
                unit.Save();
            }
        }

        public void UpdateOrder(Order order)
        {
            if (order != null)
            {
                unit.OrderRepository.Update(order);
                unit.Save();
            }
        }

        public void DeleteOrder(Order order)
        {
            if (order != null)
            {
                unit.OrderRepository.Delete(order);
                unit.Save();
            }
        }
    }
}
