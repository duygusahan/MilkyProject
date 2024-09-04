using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.BusinnessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        public List<Product> TGetProductsWithCategory();
        public int TGetTotalProductCount();
        public Dictionary<string, int> TGetProductCountByCategory();
       
        public Dictionary<string, int> TGetCategoryProductPercentage();
    }
}
