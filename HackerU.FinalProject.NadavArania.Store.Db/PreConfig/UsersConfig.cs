using HackerU.FinalProject.NadavArania.Store.Db.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HackerU.FinalProject.NadavArania.Store.Db.PreConfig
{
    public class UsersConfig : IEntityTypeConfiguration<User>
    {
        //Pre Configuration Users To DB
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
            (new User
            {
                Id = 1,
                Email = "admin@email.com",
                Password = "ya12!mmo",
                Phone = "0567811234",
                City = "Tel Aviv",
                Address = "Herzal 5",
                Type = ITypes.UType.Admin
            }),
            new User
            {
                Id = 2,
                Email = "regUser@email.com",
                Password = "4rt@4abc",
                Phone = "0538912341",
                City = "Netanya",
                Address ="Yamim 18",
                Type = ITypes.UType.User
            },
            new User
            {
                Id = 3,
                Email = "mike_north154@email.com",
                Password = "i8per!mn",
                Phone = "0529088453",
                City = "Beersheva",
                Address = "Giborim 9",
                Type = ITypes.UType.User
            }
            );
        }
    }
}
