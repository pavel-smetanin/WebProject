//Класс модели представления
//Сотрудник
using System;

namespace WebProject
{
    public class Employee : BasePeople
    {
        public string Position { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}