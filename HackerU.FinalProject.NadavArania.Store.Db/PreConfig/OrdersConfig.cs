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
    public class OrdersConfig : IEntityTypeConfiguration<Order>
    {
        //Pre Configuration Orders To DB
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData
            (
                new Order
                {
                    Id = 1,
                    Number = "YA3451123",
                    Date = DateTime.Now,
                    UserId = 2,
                    Quantity = 2
                },
                new Order
                {
                    Id = 2,
                    Number = "GH223499",
                    Date = DateTime.Now,
                    UserId = 3,
                    Quantity = 2
                }
            );
        }
    }
}
