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
    //public class EfProductDal : GenericRepository<Product>, IProductDal
    //{

    //    public EfProductDal(MilkyContext context) : base(context)
    //    {
    //    }

    //    public Dictionary<string, double> GetCategoryProductPercentage()
    //    {
    //        var productCountByCategory = GetProductCountByCategory();
    //        var totalProductCount = GetTotalProductCount();
    //        var categoryPercentage = new Dictionary<string, double>();

    //        foreach (var category in productCountByCategory)
    //        {
    //            double percentage=(category.Value/totalProductCount)*100;
    //            categoryPercentage.Add(category.Key, percentage);
    //        }
    //        return categoryPercentage;
    //    }

    //    public Dictionary<string, int> GetProductCountByCategory()
    //    {
    //        var context = new MilkyContext();
    //        return context.Products
    //           .GroupBy(p => p.Category.CategoryName)
    //           .Select(g => new
    //           {
    //               CategoryName = g.Key,
    //               Count = g.Count()
    //           })
    //           .ToDictionary(x => x.CategoryName, x => x.Count);

    //    }

    //    public List<Product> GetProductsWithCategory()
    //    {
    //        var context = new MilkyContext();
    //        var values = context.Products.Include(x => x.Category).Select(y => new Product
    //        {
    //            NewPrice = y.NewPrice,
    //            ProductName = y.ProductName,
    //            CategoryId = y.CategoryId,
    //            ImageUrl = y.ImageUrl,
    //            OldPrice = y.OldPrice,
    //            ProductId = y.ProductId,
    //            Status = y.Status,
    //            Category = new Category { CategoryName = y.Category.CategoryName }
    //        }).ToList();
    //        return values;
    //    }

    //    public int GetTotalProductCount()
    //    {
    //        using (var context = new MilkyContext())
    //        {
    //            return context.Products.Count();
    //        }
    //    }
    //}
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(MilkyContext context) : base(context)
        {
        }

        //public Dictionary<string, double> GetCategoryProductPercentage()
        //{
        //    var productCountByCategory = GetProductCountByCategory();
        //    var totalProductCount = GetTotalProductCount();
        //    var categoryPercentage = new Dictionary<string, double>();

        //    foreach (var category in productCountByCategory)
        //    {
        //        // Tam sayı bölmesi yerine double bölmesi yapmak için totalProductCount'ı double'a dönüştürüyoruz
        //        double percentage = (category.Value / (double)totalProductCount) * 100;
        //        categoryPercentage.Add(category.Key, percentage);
        //    }

        //    return categoryPercentage;
        //}
        public Dictionary<string, int> GetCategoryProductPercentage()
        {
            var productCountByCategory = GetProductCountByCategory();
            var totalProductCount = GetTotalProductCount();
            var categoryPercentage = new Dictionary<string, int>();

            foreach (var category in productCountByCategory)
            {
                // Yüzdeleri tam sayıya yuvarlıyoruz
                int percentage = (int)Math.Round((category.Value / (double)totalProductCount) * 100);
                categoryPercentage.Add(category.Key, percentage);
            }

            return categoryPercentage;
        }

        public Dictionary<string, int> GetProductCountByCategory()
        {
            var context = new MilkyContext();
            return context.Products
               .GroupBy(p => p.Category.CategoryName)
               .Select(g => new
               {
                   CategoryName = g.Key,
                   Count = g.Count()
               })
               .ToDictionary(x => x.CategoryName, x => x.Count);
        }

        public List<Product> GetProductsWithCategory()
        {
            var context = new MilkyContext();
            var values = context.Products.Include(x => x.Category).Select(y => new Product
            {
                NewPrice = y.NewPrice,
                ProductName = y.ProductName,
                CategoryId = y.CategoryId,
                ImageUrl = y.ImageUrl,
                OldPrice = y.OldPrice,
                ProductId = y.ProductId,
                Status = y.Status,
                Category = new Category { CategoryName = y.Category.CategoryName }
            }).ToList();
            return values;
        }

        public int GetTotalProductCount()
        {
            using (var context = new MilkyContext())
            {
                return context.Products.Count();
            }
        }
    }

}
