using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject
{
    public static class ModelBufer
    {
        static ModelBufer()
        {
            TouristList = new List<Tourist>();
        }
        public static Client Client { get; set; }
        public static Tour Tour { get; set; }
        public static List<Tourist> TouristList { get; set; }
    }
}