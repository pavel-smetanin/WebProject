//Статический класс для реализации информационной безопасности
using System;

namespace WebProject
{
    public static class SecurityUtils
    {
        private static string dBStrConnection = "Server = localhost; Database = tour_agency; port = 3306; User Id = root; password = q1234as";
        public static int currUserID { get; private set; }
        public static string GetDbStrConnection()
        {
            return dBStrConnection;
        }
        public static void UserAutorisation(string login, string password)
        {
            try
            {
                currUserID = CheckUserAndGetIdInDb(login, password);
                return;
            }
            catch
            {
                throw new Exception();
            }
        }
        private static int CheckUserAndGetIdInDb(string login, string password)
        {
            DbUtils.InitConnection(GetDbStrConnection());
            int id = DbUtils.GetUserID(login, password);
            if (id == null || id <= 0)
                throw new Exception();
            return id;
        }
        public static bool CheckCurrID()
        {
            if (currUserID == null || currUserID <= 0)
                return false;
            return true;
        }
    }
}