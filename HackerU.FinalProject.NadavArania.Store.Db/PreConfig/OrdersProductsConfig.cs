using HackerU.FinalProject.NadavArania.Store.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerU.FinalProject.NadavArania.Store.Db.PreConfig
{
    public class OrdersProductsConfig : IEntityTypeConfiguration<OrderProduct>
    {
        //Pre Configuration OrdersProducts To DB
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.HasData
            (
                new OrderProduct
                {
                    OrderId = 1,
                    ProductId = 1,
                    TotalPrice = 48.99,
                    Quantity =1
                },
                new OrderProduct
                {
                    OrderId = 1,
                    ProductId = 2,
                    TotalPrice = 29.99,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 2,
                    ProductId = 3,
                    TotalPrice = 16.99,
                    Quantity = 1
                },
                new OrderProduct
                {
                    OrderId = 2,
                    ProductId = 4,
                    TotalPrice = 34.99,
                    Quantity = 1
                }
            );
        }
    }
}
