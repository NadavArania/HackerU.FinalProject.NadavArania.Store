using HackerU.FinalProject.NadavArania.Store.Core.DTOs;
using HackerU.FinalProject.NadavArania.Store.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerU.FinalProject.NadavArania.Store.Core.Services
{
    public interface IUserService
    {
        //Crud Function With Get's Function For User
        List<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(UserDTO user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
