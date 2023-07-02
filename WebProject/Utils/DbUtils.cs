//Статический класс для работы с БД
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace WebProject
{
    public static class DbUtils
    {
        private static MySqlConnection Connection;
        //Инициализация соединения по строке
        public static void InitConnection(string strConnection)
        {
            Connection = new MySqlConnection(strConnection);
        }
        //Открытие соединения с БД
        public static void OpenConnection()
        {
            try
            {
                Connection.Open();
            }
            catch
            {
                throw new Exception("Не удается подключиться к базе данных");
            }
        }
        //Закрытие соединения с БД
        public static void CloseConnection()
        {
            try
            {
                Connection.Close();
            }
            catch
            {
                throw new Exception("Не удается подключиться к базе данных");
            }
        }
        //Запрос в БД без вывода результата из БД
        private static void ExcecuteSqlQueryNonResult(string sqlCommand)
        {
            OpenConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(sqlCommand, Connection);
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                CloseConnection();
                throw new Exception("Не удается произвести запрос в базу данных\n" + ex.Message);
            }
            CloseConnection();
        }
        //Запрос в БД с выводом результата из БД
        private static MySqlDataReader ExcecuteSqlQueryReader(string sqlCommand)
        {
            try
            {
                MySqlDataReader result = new MySqlCommand(sqlCommand, Connection).ExecuteReader();
                return result;
            }
            catch
            {
                CloseConnection();
                throw new Exception("Не удается произвести запрос в базу данных!");
            }
        }
        //Генерация ID по максимальному эл-ту таблицы БД
        public static string GetMaxValueFromTable(string columnName, string tableName)
        {
            string sqlCommand = $"SELECT max({columnName}) FROM {tableName};";
            string result;
            OpenConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(sqlCommand, Connection);
                result = command.ExecuteScalar().ToString();
                CloseConnection();
                return result;
            }
            catch
            {
                CloseConnection();
                throw new Exception("Не удается найти maxValue в базе данных!");
            }
            
        }
        //Добавление клиента в БД
        public static void AddClientInDB(Client client)
        {
            string sqlCommand = "INSERT INTO client (ID, surname, name, patrname, birth_date, phone, email, passport)" +
                $"VALUE ({client.ID}, '{client.Surname}', '{client.Name}', '{client.PatrName}', '{client.birthDate.ToShortDateString()}', '{client.Phone}', '{client.Email}', '{client.Passport}');";
            ExcecuteSqlQueryNonResult(sqlCommand);
        }
        //Добавление туриста в БД
        public static void AddTouristInDB(Tourist tourist)
        {
            string sqlCommand = "INSERT INTO tourist (ID, surname, name, patrname, birth_date, passport, intern_pass)" +
                $"VALUE ({tourist.ID}, '{tourist.Surname}', '{tourist.Name}', '{tourist.PatrName}', '{tourist.birthDate.ToShortDateString()}', '{tourist.Passport}', '{tourist.InternPassport}');";
            ExcecuteSqlQueryNonResult(sqlCommand);
        }
        //Добавление заказа в БД
        public static void AddTourOrderInDB(Order order)
        {
            string sqlCommand = "INSERT INTO tour_order (order_id, client_id, emp_id, tour_id, visa, date)" +
                $"VALUE ('{order.ID}', {order.Client.ID}, {order.Emloyee.ID}, {order.Tour.ID}, {order.Visa}, '{order.Date.ToShortDateString()}');";
            ExcecuteSqlQueryNonResult(sqlCommand);
        }
        //Добавление туристов заказа в БД
        public static void AddTouristOrderInDB(TouristOrder touristOrder)
        {
            string sqlCommand = "INSERT INTO tourist_order (order_id, tourist_id, visa)" +
                $"VALUE ({touristOrder.Order.ID}, {touristOrder.Tourist.ID}, {touristOrder.Visa});";
            ExcecuteSqlQueryNonResult(sqlCommand);
        }
        //Добавление списка туристов в БД
        public static void AddTouristOrderListInDB(List<TouristOrder> list)
        {
            for (int i = 0; i < list.Count; i++)
                AddTouristOrderInDB(list[i]);
        }
        //Получение списка туров из БД
        public static List<Tour> GetTourList()
        {
            string sqlCommand = "SELECT * FROM tour; ";
            List<Tour> tourList = new List<Tour>();
            OpenConnection();
            MySqlDataReader reader = ExcecuteSqlQueryReader(sqlCommand);
            while(reader.Read())
            {
                Tour tour = new Tour();
                tour.ID = Int32.Parse(reader[0].ToString());
                tour.Name = reader[1].ToString();
                tour.NumOp = reader[2].ToString();
                tour.Count = Int32.Parse(reader[3].ToString());
                tour.dateStart = DateTime.Parse(reader[4].ToString());
                tour.dateFinish = DateTime.Parse(reader[5].ToString());
                tour.Price = Int32.Parse(reader[6].ToString());
                tour.Visa = Convert.ToBoolean(Int32.Parse(reader[7].ToString()));
                tour.LinkSite = reader[8].ToString();
                tour.countryNum = Int32.Parse(reader[9].ToString());
                tour.operatorNum = Int32.Parse(reader[10].ToString());
                tourList.Add(tour);
            }
            CloseConnection();
            return tourList;
        }
        //Получение сотрудника из БД по id
        public static Employee GetEmloyee(int id)
        {
            Employee result = new  Employee();
            string sqlCommand = $"SELECT * FROM employee e WHERE e.ID = {id};";
            OpenConnection();
            try
            {
                MySqlDataReader reader = ExcecuteSqlQueryReader(sqlCommand);
                while (reader.Read())
                {
                    result.ID = Int32.Parse(reader[0].ToString());
                    result.Surname = reader[1].ToString();
                    result.Name = reader[2].ToString();
                    result.PatrName = reader[3].ToString();
                    result.Position = reader[4].ToString();
                    result.Phone = reader[5].ToString();
                    result.Email = reader[6].ToString();
                }
            }
            catch
            {
                CloseConnection();
                throw new Exception($"Сотрудник с номером {id} не найден");
            }
            CloseConnection();
            return result;
        }
        //Получение клиента из БД по id
        public static Client GetClient(int id)
        {
            Client result = new Client();
            string sqlCommand = $"SELECT * FROM client c WHERE c.ID = {id};";
            OpenConnection();
            try
            {
                MySqlDataReader reader = ExcecuteSqlQueryReader(sqlCommand);
                while(reader.Read())
                {
                    result.ID = Int32.Parse(reader[0].ToString());
                    result.Surname = reader[1].ToString();
                    result.Name = reader[2].ToString();
                    result.PatrName = reader[3].ToString();
                    result.birthDate = DateTime.Parse(reader[4].ToString());
                    result.Phone = reader[5].ToString();
                    result.Email = reader[6].ToString();
                    result.Passport = reader[7].ToString();
                }
            }
            catch
            {
                CloseConnection();
                throw new Exception($"Не удается найти клиента с номером: {id}");
            }
            CloseConnection();
            return result;
        }
        //Поиск пользователя по логину и паролю в БД с возвратом id 
        public static int GetUserID(string login, string password)
        {
            string sqlCommand = $"SELECT ID FROM user_auth WHERE login = '{login}' AND password = '{password}';";
            int result;
            OpenConnection();
            try
            {
                MySqlCommand command = new MySqlCommand(sqlCommand, Connection);
                result = Int32.Parse(command.ExecuteScalar().ToString());
                CloseConnection();
                return result;
            }
            catch(Exception ex)
            {
                CloseConnection();
                throw new Exception("Логин и пароль не найдены в базе данных " + ex.Message);
            }
        }
    }
}