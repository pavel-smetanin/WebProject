//Класс модели представления
//Тур
using System;

namespace WebProject
{
    public class Tour
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NumOp { get; set; }
        public int Count { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateFinish { get; set; }
        public int Price { get; set; }
        public bool Visa { get; set; }
        public string LinkSite { get; set; }
        public int countryNum { get; set; }
        public int operatorNum { get; set; }
    }
}