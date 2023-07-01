using Microsoft.AspNetCore.Mvc;
using HackerU.FinalProject.NadavArania.Store.Db.Models;
using HackerU.FinalProject.NadavArania.Store.Core.Services;
using HackerU.FinalProject.NadavArania.Store.Core.DTOs;
using HackerU.FinalProject.NadavArania.Store.Api_And_UI.Logics;
using HackerU.FinalProject.NadavArania.Store.UI_And_Api.Logics;
using Microsoft.AspNetCore.Authorization;
using HackerU.FinalProject.NadavArania.Store.Db.ITypes;

namespace HackerU.FinalProject.NadavArania.Store.Api_And_UI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        //Fetch Get Request For All Product Details
        [HttpGet]
        public List<Product> GetAllProductsInStore()
        {
            var contextList = productService.GetAllProducts();
            var productSessionIds = Sessions.GetSessionProduct(HttpContext.Session);
            contextList.ForEach((x) =>
            {
                x.Added = productSessionIds.Any(y => y == x.Id);
            });
            return contextList;
        }
        //Post Request For Adding Product To Cart
        [HttpPost]
        [Authorize]
        public void AddProductToCart(int id)
        {
            var products = Sessions.GetSessionProduct(HttpContext.Session);
            if (!products.Any(x => x == id))
            {
                products.Add(id);
            }
            Sessions.SetSessionProduct(products, HttpContext.Session);
        }
        //Delete Request For Deleting Product From Cart
        [HttpDelete]
        [Authorize]
        public void DeleteProductFromCart(int id)
        {
            var products = productService.GetAllProducts();
            var productsIds = Sessions.GetSessionProduct(HttpContext.Session);
            productsIds.Remove(id);
            if (productsIds.Count == 0)
            {
                Sessions.DeleteSessionProduct(HttpContext.Session);
            }
            else
            {
                var deletedProduct = products.SingleOrDefault(x => x.Id == id);
                if (deletedProduct != null)
                {
                    deletedProduct.Added = false;
                }
                Sessions.SetSessionProduct(productsIds, HttpContext.Session);
            }
        }
        //Delete Request For Deleting Product From DB
        [HttpDelete]
        [Route("[action]")]
        [Authorize]
        public void DeleteProduct(int id)
        {
            if(id > 0)
            {
                var products = productService.GetAllProducts();
                if(products != null)
                {
                    var chosenProdcut = products.SingleOrDefault(x => x.Id == id);
                    if(chosenProdcut != null)
                    {
                        productService.DeleteProduct(chosenProdcut);
                    }
                }
            }
        }
        //Post Request For Adding Product To DB
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public void AddProduct(PType type,string name, double price, string description, string image, PCat category)
        {
            var products = productService.GetAllProducts();
            if(products != null)
            {
                var newProduct = new ProductDTO
                {
                    Type = type,
                    Name = name,
                    Price = price,
                    Description = description,
                    Image = image,
                    Category = category,
                    Quantity = 1
                };
                var check = CheckIfExists.CheckIfProductExsistsInsideTheList(products, name);
                if(check != true)
                {
                    productService.AddProduct(newProduct);
                }
            }
        }
        //Put Request For Editing Product From DB
        [HttpPut]
        [Authorize]
        public void EditProduct(int id, PType type, string name, double price, string description, string image, PCat category)
        {
            if(id > 0 && name != null && price > 0 && description != null && image != null)
            {
                var products = productService.GetAllProducts();
                if (products != null)
                {
                    var product = products.SingleOrDefault(x => x.Id == id);
                    if(product != null)
                    {
                        var check = CheckIfExists.CheckIfProductExsistsInsideTheList(products, product.Name);
                        if (check == true)
                        {
                            product.Type = type;
                            product.Name = name;
                            product.Price = price;
                            product.Description = description;
                            product.Image = image;
                            product.Category = category;
                            product.Quantity = 1;
                            productService.UpdateProduct(product);
                        }
                    }
                }
            }
        }
    }
}
