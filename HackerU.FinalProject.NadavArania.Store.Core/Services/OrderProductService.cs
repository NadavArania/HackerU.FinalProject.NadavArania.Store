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
    //Using Unit Of Work And His Interface And Connecting with The OrderProduct Controller
    public class OrderProductService : IOrderProductService
    {
        public IUnitOfWork unit;
        private readonly IMapper mapper;

        public OrderProductService(IUnitOfWork unit,IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public void AddOrderProduct(OrderProductDTO op)
        {
            var newop = mapper.Map<OrderProductDTO, OrderProduct>(op);
            if (newop != null)
            {
                unit.OrderProductRepository.Add(newop);
                unit.Save();
            }
        }

        public void DeleteOrderProduct(OrderProduct op)
        {
            unit.OrderProductRepository.Delete(op);
            unit.Save();
        }

        public List<OrderProduct> GetAllOrderProducts()
        {
            return unit.OrderProductRepository.GetList();
        }

        public OrderProduct GetById(int id)
        {
            return unit.OrderProductRepository.GetById(id);
        }

        public void UpdateOrderProduct(OrderProduct op)
        {
            unit.OrderProductRepository.Update(op);
        }
    }
}
