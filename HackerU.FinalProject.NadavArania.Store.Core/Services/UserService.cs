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
    //Using Unit Of Work And His Interface And Connecting with The User Controller
    public class UserService : IUserService
    {
        public IUnitOfWork unit;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public void AddUser(UserDTO user)
        {
            var newUser = mapper.Map<UserDTO,User>(user);
            if(newUser != null)
            {
                unit.UserRepository.Add(newUser);
                unit.Save();
            }
        }

        public void DeleteUser(User user)
        {
            if(user != null)
            {
                unit.UserRepository.Delete(user);
                unit.Save();
            }
        }

        public List<User> GetAllUsers()
        {
            return unit.UserRepository.GetList();
        }

        public User GetUserById(int id)
        {
            return unit.UserRepository.GetById(id);
        }

        public void UpdateUser(User user)
        {
            if(user != null)
            {
                unit.UserRepository.Update(user);
                unit.Save();
            }
        }
    }
}
