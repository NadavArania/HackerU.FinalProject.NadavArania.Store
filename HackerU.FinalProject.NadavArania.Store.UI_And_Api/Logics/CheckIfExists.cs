using HackerU.FinalProject.NadavArania.Store.Db.Models;

namespace HackerU.FinalProject.NadavArania.Store.Api_And_UI.Logics
{
    public static class CheckIfExists
    {
        public static bool CheckIfUserExistsInsideTheList(List<User> users, string email)
        {
            return users.Any(x => x.Email == email);
        }

        public static bool CheckIfProductExsistsInsideTheList(List<Product> products,string name)
        {
            return products.Any(x => x.Name == name);
        }

        public static bool CheckIfOrderExsistsInsideTheList(List<Order> orders, string number)
        {
            return orders.Any(x => x.Number == number);
        }
    }
}
