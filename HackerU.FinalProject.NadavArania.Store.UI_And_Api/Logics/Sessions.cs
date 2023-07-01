namespace HackerU.FinalProject.NadavArania.Store.UI_And_Api.Logics
{
    public static class Sessions
    {
        private static readonly string productKey = "ProductKey";
        private static readonly string userKey = "UserKey";

        public static List<int> GetSessionProduct(ISession session)
        {
            var sessionList = new List<int>();
            string? ps = session.GetString(productKey);
            if (ps != null)
            {
                ps.Split(",").ToList().ForEach(x => sessionList.Add(int.Parse(x)));
            }
            return sessionList;
        }
        public static void SetSessionProduct(List<int> listOfIds, ISession session)
        {
            string s = "";
            listOfIds.ForEach(x => s += x + ",");
            if (s.Length > 0)
            {
                s = s.Remove(s.Length - 1);
            }
            session.SetString(productKey, s);
        }

        public static void DeleteSessionProduct(ISession session)
        {
            session.Remove(productKey);
        }

        public static List<int> GetSessionUser(ISession session)
        {
            var sessionList = new List<int>();
            string? ps = session.GetString(userKey);
            if (ps != null && ps != "")
            {
                ps.Split(",").ToList().ForEach(x => sessionList.Add(int.Parse(x)));
            }
            return sessionList;
        }
        public static void SetSessionUser(List<int> listOfIds, ISession session)
        {
            string s = "";
            listOfIds.ForEach(x => s += x + ",");
            if (s.Length > 0)
            {
                s = s.Remove(s.Length - 1);
            }
            session.SetString(userKey, s);
        }

        public static void DeleteSessionUser(ISession session)
        {
            session.Remove(userKey);
        }
    }
}
