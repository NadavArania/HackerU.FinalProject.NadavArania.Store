using Microsoft.AspNetCore.Mvc;
using HackerU.FinalProject.NadavArania.Store.Db.Models;
using HackerU.FinalProject.NadavArania.Store.Core.Services;
using HackerU.FinalProject.NadavArania.Store.Core.DTOs;
using HackerU.FinalProject.NadavArania.Store.Api_And_UI.Logics;
using System.Text;
using HackerU.FinalProject.NadavArania.Store.UI_And_Api.Logics;
using Newtonsoft.Json;

namespace HackerU.FinalProject.NadavArania.Store.Api_And_UI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IOrderProductService orderProductService;
        private readonly IProductService productService;

        public OrdersController(IOrderService orderService, IOrderProductService orderProductService, IProductService productService)
        {
            this.orderService = orderService;
            this.orderProductService = orderProductService;
            this.productService = productService;
        }
        //Fetch Get Request For All Orders Details
        [HttpGet]
        public List<Order> GetAllOrders()
        {
            return orderService.GetAllOrders();
        }
        //Adding Order By Post Request To DB
        [HttpPost]
        public void AddOrder(int id,string products,double total)
        {
            if (products != null)
            {
                var productsList = JsonConvert.DeserializeObject<List<Product>>(products);
                var orders = orderService.GetAllOrders();
                if (productsList != null)
                {
                    var orderNum = GenerateRandom.OrderNumber();
                    var newOrder = new OrderDTO
                    {
                        Number = orderNum,
                        Date = DateTime.Now,
                        UserId = id,
                        Quantity = productsList.Count()
                    };
                    var check = CheckIfExists.CheckIfOrderExsistsInsideTheList(orders, orderNum);
                    if (check != true && newOrder != null)
                    {
                        orderService.AddOrder(newOrder);
                        var productsL = productService.GetAllProducts();
                        var productsIds = Sessions.GetSessionProduct(HttpContext.Session);
                        productsL.ForEach(x => productsIds.Remove(x.Id));
                        if (productsIds.Count == 0)
                        {
                            Sessions.DeleteSessionProduct(HttpContext.Session);
                        }
                    }
                    if (newOrder != null)
                    {
                        var ordersList = orderService.GetAllOrders();
                        var o = ordersList.SingleOrDefault(x => x.Number == newOrder.Number);
                        if (o != null)
                        {
                            productsList.ForEach(x => orderProductService.AddOrderProduct(new OrderProductDTO
                            {
                                OrderId = o.Id,
                                ProductId = x.Id,
                                TotalPrice = total,
                                Quantity = x.Quantity
                            }));
                        }
                    }
                }
            }
            
        }
        //Delete Request For Deleting Order From DB
        [HttpDelete]
        public void DeleteOrder(string number)
        {
            var orders = orderService.GetAllOrders();
            if(number != null)
            {
                var order = orders.FirstOrDefault(x => x.Number == number);
                if (order != null)
                {
                    var check = CheckIfExists.CheckIfOrderExsistsInsideTheList(orders, order.Number);
                    if (check == true)
                    {
                        orderService.DeleteOrder(order);
                    }
                }
            }
            
        }
        //Normal Function For Getting Order Quantity
        [NonAction]
        public int GetQuantityInOrder(string num)
        {
            var orders = orderService.GetAllOrders();
            var orderProducts = orderProductService.GetAllOrderProducts();
            var products = productService.GetAllProducts();
            var quan = from o in orders
                       where o.Number == num
                       join op in orderProducts on o.Id equals op.OrderId
                       join p in products on op.ProductId equals p.Id
                       select p;

            return quan.Count();
        }
    }
}
