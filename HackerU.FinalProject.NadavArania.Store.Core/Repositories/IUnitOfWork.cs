using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerU.FinalProject.NadavArania.Store.Core.Repositories
{
    public interface IUnitOfWork
    {
        //Layer Of Defence For The Repositories And Save Option
        IUserRepository UserRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderProductRepository OrderProductRepository { get; }
        void Save();
    }
}
