using HackerU.FinalProject.NadavArania.Store.Db.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerU.FinalProject.NadavArania.Store.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //Layer Of Defence For The Repositories And Save Option
        private readonly StoreContext db;
        private IUserRepository userRepository;
        public IUserRepository UserRepository => userRepository ??= new UserRepository(db);
        private IOrderRepository orderRepository;
        public IOrderRepository OrderRepository => orderRepository ??= new OrderRepository(db);
        private IProductRepository productRepository;
        public IProductRepository ProductRepository => productRepository ??= new ProductRepository(db);
        private IOrderProductRepository orderProductRepository;
        public IOrderProductRepository OrderProductRepository => orderProductRepository ??= new OrderProductRepository(db);

        public UnitOfWork(StoreContext db)
        {
            this.db = db;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
