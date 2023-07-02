//Класс модели представления
//Турист
using System;

namespace WebProject
{
    public class Tourist : BasePeople
    {
        public DateTime birthDate { get; set; }
        public string Passport { get; set; }
        public string InternPassport { get; set; }
    }
}