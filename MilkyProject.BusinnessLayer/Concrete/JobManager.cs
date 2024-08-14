using MilkyProject.BusinnessLayer.Abstract;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.BusinnessLayer.Concrete
{
    public class JobManager : IJobService
    {
        private readonly IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public void TDelete(int id)
        {
            _jobDal.Delete(id);
        }

        public Job TGetById(int id)
        {
           return _jobDal.GetById(id);  
        }

        public List<Job> TGetListAll()
        {
            return _jobDal.GetListAll();
        }

        public void TInsert(Job entity)
        {
           _jobDal.Insert(entity);
        }

        public void TUpdate(Job entity)
        {
            _jobDal.Update(entity); 
        }
    }
}
