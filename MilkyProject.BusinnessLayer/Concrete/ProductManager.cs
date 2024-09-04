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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TDelete(int id)
        {
            _productDal.Delete(id);
        }

        public Product TGetById(int id)
        {
           return  _productDal.GetById(id);
        }

        public Dictionary<string, int> TGetCategoryProductPercentage()
        {
            return _productDal.GetCategoryProductPercentage();  
        }

        public List<Product> TGetListAll()
        {
           return _productDal.GetListAll();
        }

        public Dictionary<string, int> TGetProductCountByCategory()
        {
            return _productDal.GetProductCountByCategory();
        }

        public List<Product> TGetProductsWithCategory()
        {
            return _productDal.GetProductsWithCategory();
        }

        public int TGetTotalProductCount()
        {
            return _productDal.GetTotalProductCount();
        }

        public void TInsert(Product entity)
        {
            _productDal.Insert(entity);
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

       
    }
}
