//Класс модели представления
//Клиент
using System;

namespace WebProject
{
    public class Client : BasePeople
    {
        public DateTime birthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Passport { get; set; }
    }
}