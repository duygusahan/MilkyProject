using Microsoft.EntityFrameworkCore;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.DataAccessLayer.Context;
using MilkyProject.DataAccessLayer.Repositories;
using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.DataAccessLayer.EntityFramework
{
    public class EfEmployeDal : GenericRepository<Employe>, IEmployeDal
    {
        public EfEmployeDal(MilkyContext context) : base(context)
        {
        }

        public List<Employe> GetEmployeWithJob()
        {
            var context = new MilkyContext();
            var values=context.Employes.Include(x=>x.Job).Select(y=> new Employe
            {
                EmployeId = y.EmployeId,
                JobId = y.JobId,
                EmployeName = y.EmployeName,
                ImageUrl = y.ImageUrl,  
                Job = new Job { JobName=y.Job.JobName }
            }).ToList();
            return values;
        }
    }
}
