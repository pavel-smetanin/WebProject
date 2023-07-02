//Класс модели представления
//Турист в заказе
using System;

namespace WebProject
{
    public class TouristOrder
    {
        public Order Order { get; set; }
        public Tourist Tourist { get; set; }
        public bool Visa { get; set; }

    }
}