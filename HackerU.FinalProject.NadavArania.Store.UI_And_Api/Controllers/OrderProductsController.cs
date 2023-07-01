using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HackerU.FinalProject.NadavArania.Store.Db.Context;
using HackerU.FinalProject.NadavArania.Store.Db.Models;
using HackerU.FinalProject.NadavArania.Store.Core.Services;
using HackerU.FinalProject.NadavArania.Store.Core.DTOs;

namespace HackerU.FinalProject.NadavArania.Store.ApiTestSwagger.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderProductsController : ControllerBase
    {
        private readonly IOrderProductService orderProductService;

        public OrderProductsController(IOrderProductService orderProductService)
        {
            this.orderProductService = orderProductService;
        }
        //Fetching All OrderProduct By Get Request
        [HttpGet]
        public List<OrderProduct> GetAll()
        {
            return orderProductService.GetAllOrderProducts();
        }
    }
}
