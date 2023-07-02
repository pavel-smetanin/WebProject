using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject
{
    public class TourBooking : BaseOrder
    {
        public DateTime DateBook { get; set; }
        public DateTime DateFinish { get; set; }

    }
}