using Microsoft.AspNetCore.Mvc;
using HackerU.FinalProject.NadavArania.Store.Db.Models;
using HackerU.FinalProject.NadavArania.Store.Core.Services;
using HackerU.FinalProject.NadavArania.Store.Core.DTOs;
using HackerU.FinalProject.NadavArania.Store.Api_And_UI.Logics;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using HackerU.FinalProject.NadavArania.Store.UI_And_Api.Logics;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HackerU.FinalProject.NadavArania.Store.Api_And_UI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static readonly string authSchema = "myauthentication";
        private readonly IUserService userService;
        private readonly IOrderService orderService;
        private readonly IProductService productService;
        private readonly IOrderProductService orderProductService;

        public UsersController(IUserService userService,IOrderService orderService, IProductService productService, IOrderProductService orderProductService)
        {
            this.userService = userService;
            this.orderService = orderService;
            this.productService = productService;
            this.orderProductService = orderProductService;
            var users = userService.GetAllUsers().FindAll(x => x.Id <= 3);
            for (int i = 0; i < users.Count; i++)
            {
                users[0].Password = "ya12!mmo";
                users[1].Password = "4rt@4abc";
                users[2].Password = "i8per!mn";
            }
            users.ForEach(y => { y.Password = PasswordHasherAndSalter.HashPassword(y.Password); userService.UpdateUser(y); });
        }

        //Fetching Get Request For Logged User Details
        [HttpGet]
        public List<User> GetLoggedUser()
        {
            var users = userService.GetAllUsers();
            var usersSessionId = Sessions.GetSessionUser(HttpContext.Session);
            users.ForEach((x) =>
            {
                x.Logged = usersSessionId.Any(y => y == x.Id);
            });
            return users;
        }

        //Register Post Request
        [HttpPost]
        public void Register(string email,string password,string phone,string city,string address)
        {
            var users = userService.GetAllUsers();
            var checkIfUsed = CheckIfExists.CheckIfUserExistsInsideTheList(users, email);
            if(users != null && checkIfUsed != true)
            {
                var newUser = new UserDTO
                {
                    Email = email,
                    Password = password,
                    Phone = phone,
                    City = city,
                    Address = address,
                    Type = Db.ITypes.UType.User
                };
                newUser.Password = PasswordHasherAndSalter.HashPassword(newUser.Password);
                var check = CheckIfExists.CheckIfUserExistsInsideTheList(users, email);
                if (check != true && newUser != null && PasswordHasherAndSalter.ValidatePassword(password,newUser.Password))
                {
                    userService.AddUser(newUser);
                }
            }
        }
        //Login Post Request
        [HttpPost]
        [Route("[action]")]
        public async Task Login(string email,string password)
        {
            if(email != null && password != null)
            {
                var users = userService.GetAllUsers();
                var usersSession = Sessions.GetSessionUser(HttpContext.Session);
                var check = CheckIfExists.CheckIfUserExistsInsideTheList(users, email);
                var regUser = users.SingleOrDefault(x => x.Email == email);
                if(regUser != null && check == true && PasswordHasherAndSalter.ValidatePassword(password,regUser.Password))
                {
                        usersSession.Add(regUser.Id);
                        var user = ClaimsLogic.AddClaims("Email", "Passowrd", regUser.Email, regUser.Password, authSchema);
                        await HttpContext.SignInAsync(authSchema, user);
                }
                else
                {
                    HttpContext.Response.StatusCode = 401;
                }
                Sessions.SetSessionUser(usersSession, HttpContext.Session);
            }
        }
        //Logout Post Request
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task Logout()
        {
            var users = userService.GetAllUsers();
            var usersSession = Sessions.GetSessionUser(HttpContext.Session);
            users.ForEach((x) =>
            {
                x.Logged = usersSession.Any(y => y == x.Id);
            });
            var loggedUser = users.SingleOrDefault(x => x.Logged == true);
            if (loggedUser != null)
            {
                usersSession.Remove(loggedUser.Id);
                if (usersSession.Count == 0)
                {
                    loggedUser.Logged = false;
                    Sessions.DeleteSessionUser(HttpContext.Session);
                }
            }
            await HttpContext.SignOutAsync(authSchema);
        }
        //Update Put Request For User Details
        [HttpPut]
        [Authorize]
        public void UpdateUser(int id,string email,string password,string phone,string city,string address)
        {
            var users = userService.GetAllUsers();
            var checkIfUsed = CheckIfExists.CheckIfUserExistsInsideTheList(users, email);
            if (checkIfUsed == true && id > 0 && email != null && password != null && phone != null && city != null && address != null)
            {
                var user = users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    var check = CheckIfExists.CheckIfUserExistsInsideTheList(users, user.Email);
                    if (check == true)
                    {
                        user.Email = email;
                        user.Password = PasswordHasherAndSalter.HashPassword(password);
                        user.Phone = phone;
                        user.City = city;
                        user.Address = address;
                        user.Type = Db.ITypes.UType.User;
                        userService.UpdateUser(user);
                    }
                }
            }
        }
        //Fetch Get Request For User Full Orders History
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<object> GetUserFullOrderHistory(int id)
        {
            var users = userService.GetAllUsers();
            var orders = orderService.GetAllOrders();
            var products = productService.GetAllProducts();
            var orderProduct = orderProductService.GetAllOrderProducts();
            if (id > 0)
            {
                var userFullDetails =
                from u in users
                where u.Id == id
                join o in orders on u.Id equals o.UserId
                join op in orderProduct on o.Id equals op.OrderId
                join p in products on op.ProductId equals p.Id
                select new
                {
                    OrderNumber = o.Number,
                    OrderDate = o.Date,
                    ProductName = p.Name,
                    ProductPrice = p.Price,
                    ProductImage = p.Image,
                    Quantity = op.Quantity
                };
                return userFullDetails.ToList();
            }
            else
            {
                return null;
            }
        }
        //Get Request For Number Of Total Orders By Id
        [HttpGet]
        [Route("[action]")]
        public int NumberOfOrderByUserId(int id)
        {
            if (id > 0)
            {
                return GetUserFullOrderHistory(id).Count();
            }
            else
            {
                return HttpContext.Response.StatusCode = 401;
            }
        }
        //Fetch Get Request For All Users Details
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<User> AllUsers()
        {
            var users = userService.GetAllUsers();
            return users;
        }
        //Delete Request For Deleting User From DB
        [HttpDelete]
        [Authorize]
        public void DeleteUser(int id)
        {
            if(id > 0)
            {
                var users = userService.GetAllUsers();
                if (users != null)
                {
                    var chosenUser = users.SingleOrDefault(x => x.Id == id);
                    if(chosenUser != null)
                    {
                        userService.DeleteUser(chosenUser);
                    }
                }
            }
        }
    }
}
