using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.EntityLayer.Concrete
{
    public class Employe
    {
        public int EmployeId { get; set; }
        public string EmployeName { get; set; }
        public string ImageUrl { get; set; }

        public int? JobId { get; set; }
        public Job Job { get; set; }
    }
}
