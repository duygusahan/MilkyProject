﻿using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.DataAccessLayer.Abstract
{
    public interface IEmployeDal:IGenericDal<Employe>
    {
        List<Employe> GetEmployeWithJob();
        List<Employe> GetFirst3EmployeWithJob();
    }
}
