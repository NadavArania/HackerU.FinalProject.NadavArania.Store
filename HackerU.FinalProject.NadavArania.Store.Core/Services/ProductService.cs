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
    //Using Unit Of Work And His Interface And Connecting with The Product Controller
    public class ProductService : IProductService
    {
        public IUnitOfWork unit;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public List<Product> GetAllProducts()
        {
            return unit.ProductRepository.GetList();
        }

        public Product GetProductById(int id)
        {
            return unit.ProductRepository.GetById(id);
        }

        public void AddProduct(ProductDTO product)
        {
            var newProduct = mapper.Map<ProductDTO, Product>(product);
            if(newProduct != null)
            {
                unit.ProductRepository.Add(newProduct);
                unit.Save();
            }
        }

        public void UpdateProduct(Product product)
        {
            if(product != null)
            {
                unit.ProductRepository.Update(product);
                unit.Save();
            }
        }

        public void DeleteProduct(Product product)
        {
            if(product != null)
            {
                unit.ProductRepository.Delete(product);
                unit.Save();
            }
        }
    }
}
