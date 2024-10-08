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
    public class GalleryManager : IGalleryService
    {
        private readonly IGalleryDal _galleryDal;

        public GalleryManager(IGalleryDal galleryDal)
        {
            _galleryDal = galleryDal;
        }

        public void TDelete(int id)
        {
            _galleryDal.Delete(id);
        }

        public Gallery TGetById(int id)
        {
            return _galleryDal.GetById(id); 
        }

        public List<Gallery> TGetListAll()
        {
            return _galleryDal.GetListAll();
        }

        public int TGetTotalGalleryCount()
        {
            return _galleryDal.GetTotalGalleryCount();
        }

        public void TInsert(Gallery entity)
        {
            _galleryDal.Insert(entity);
        }

        public void TUpdate(Gallery entity)
        {
            _galleryDal.Update(entity);
        }
    }
}
