//Абстрактный класс модели представления
//Базовый заказ
using System;

namespace WebProject
{
    public abstract class BaseOrder
    {
        public int ID { get; set; }
        public Client Client { get; set; }
        public Employee Emloyee { get; set; }
        public Tour Tour { get; set; }
    }
}