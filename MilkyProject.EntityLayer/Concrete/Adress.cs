using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.EntityLayer.Concrete
{
    public class Adress
    {
        public int AdressId { get; set; }
        public string? AdressDetail { get; set; }
        public string? Phone { get; set; }
        public string? Mail { get; set; }
        public string? Weekdays{ get; set; }
        public string? Saturday{ get; set; }
        public string? Sunday{ get; set; }
    }
}
