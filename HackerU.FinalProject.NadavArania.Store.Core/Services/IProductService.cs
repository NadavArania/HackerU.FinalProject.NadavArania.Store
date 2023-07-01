using HackerU.FinalProject.NadavArania.Store.Core.DTOs;
using HackerU.FinalProject.NadavArania.Store.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerU.FinalProject.NadavArania.Store.Core.Services
{
    public interface IProductService
    {
        //Crud Function With Get's Function For Product
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        void AddProduct(ProductDTO product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
