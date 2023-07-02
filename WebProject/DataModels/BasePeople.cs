//Класс модели представления 
//ФИО человека
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject
{
    public abstract class BasePeople
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string PatrName { get; set; }
        
    }
}