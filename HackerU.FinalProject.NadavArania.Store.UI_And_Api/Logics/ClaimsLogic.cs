using System.Security.Claims;

namespace HackerU.FinalProject.NadavArania.Store.UI_And_Api.Logics
{
    public static class ClaimsLogic
    {
        public static ClaimsPrincipal AddClaims(string title1,string title2,string x,string y,string authSchema)
        {
            List<Claim> claims = new List<Claim>()
                {
                    new Claim(title1,x),
                    new Claim(title2,y)
                };
            var identity = new ClaimsIdentity(claims, authSchema);
            var user = new ClaimsPrincipal(identity);
            return user;
        }
    }
}
