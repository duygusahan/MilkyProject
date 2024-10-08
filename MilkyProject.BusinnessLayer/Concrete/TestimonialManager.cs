﻿using MilkyProject.BusinnessLayer.Abstract;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.BusinnessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TDelete(int id)
        {
            _testimonialDal.Delete(id);
        }

        public Testimonial TGetById(int id)
        {
            return _testimonialDal.GetById(id);
        }

        public List<Testimonial> TGetListAll()
        {
            return _testimonialDal.GetListAll();
        }

        public int TGetTotalTestimonialCount()
        {
           return _testimonialDal.GetTotalTestimonialCount();
        }

        public void TInsert(Testimonial entity)
        {
            _testimonialDal.Insert(entity);
        }

        public void TUpdate(Testimonial entity)
        {
            _testimonialDal.Update(entity);
        }
    }
}
