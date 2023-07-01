using System.Text;

namespace HackerU.FinalProject.NadavArania.Store.UI_And_Api.Logics
{
    public static class GenerateRandom
    {
        private readonly static Random rand = new Random();

        public static int RandomNumber(int min,int max)
        {
            return rand.Next(min,max);
        }

        public static string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);
            char offset = lowerCase ? 'a' : 'A';
            const int letterOffset = 26;
            for(var i = 0; i < size; i++)
            {
                var s = (char)rand.Next(offset,offset + letterOffset);
                builder.Append(s);
            }
            return lowerCase? builder.ToString().ToLower() : builder.ToString();
        }

        public static string OrderNumber()
        {
            var orderBuilder = new StringBuilder();
            orderBuilder.Append(RandomString(2, false));
            orderBuilder.Append(RandomNumber(1000000, 9999999));
            return orderBuilder.ToString();
        }
    }
}
