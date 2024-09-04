using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.BusinnessLayer.Abstract
{
    public interface IEmployeService:IGenericService<Employe>
    {
        public List<Employe> TGetEmployeWithJob();

        public List<Employe> TGetFirst3EmployeWithJob();
        public int TGetTotalEmployeeCount();
    }
}
