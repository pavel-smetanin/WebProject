//Статический класс для работы с моделями представлениями
using System;
using System.Collections.Generic;

namespace WebProject
{
    public static class ModelUtils
    {
        private static BasePeople FIOInit(BasePeople people, string surname, string name, string patrname )
        {
            people.Surname = surname;
            people.Name = name;
            people.PatrName = patrname;
            return people;
        }
        public static Client InitClient(string surname, string name, string patrname, DateTime birthDate, string phone, string email, string pass)
        {
            Client client = (Client)FIOInit(new Client(), surname, name, patrname);
            client.ID = Int32.Parse(DbUtils.GetMaxValueFromTable("ID", "client")) + 1;
            client.birthDate = birthDate;
            client.Phone = phone;
            client.Email = email;
            client.Passport = pass;
            return client;
        }
        public static Tourist InitTourist(string surname, string name, string patrname, DateTime birthDate, string pass, string internPass)
        {
            Tourist tourist = (Tourist)FIOInit(new Tourist(), surname, name, patrname);
            tourist.ID = Int32.Parse(DbUtils.GetMaxValueFromTable("ID", "tourist")) + 1;
            tourist.birthDate = birthDate;
            tourist.Passport = pass;
            tourist.InternPassport = internPass;
            return tourist;
        }
        public static Order InitOrder(Client client, Tour tour, Employee employee, bool visa, DateTime date)
        {
            Order order = new Order();
            order.ID = Int32.Parse(DbUtils.GetMaxValueFromTable("order_id", "tour_order")) + 1;
            order.Client = client;
            order.Tour = tour;
            order.Emloyee = employee;
            order.Visa = visa;
            order.Date = date;
            return order;
        }
        public static TouristOrder InitTouristOrder(Order order, Tourist tourist, bool visa)
        {
            TouristOrder touristOrder = new TouristOrder();
            touristOrder.Order = order;
            touristOrder.Tourist = tourist;
            touristOrder.Visa = visa;
            return touristOrder;
        }
        public static List<TouristOrder> CreateTouristOrderList(List<Tourist> touristList, Order order)
        {
            List<TouristOrder> list = new List<TouristOrder>();
            for (int i = 0; i < touristList.Count; i++)
            {
                TouristOrder touristOrder = new TouristOrder();
                touristOrder.Tourist = touristList[i];
                touristOrder.Order = order;
                list.Add(touristOrder);
            }
            return list;
        }
        public static Tour SearchInTourList(List<Tour> list, int id)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if (id == list[i].ID)
                    return list[i];
            }
            throw new Exception($"Не удается найти тур по номеру: {id}");
        }
        

    }
}