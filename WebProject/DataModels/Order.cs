//Класс модели представления
//Заказ на тур
using System;

namespace WebProject
{
    public class Order : BaseOrder
    {
        public bool Visa { get; set; }
        public DateTime Date { get; set; }
    }
}