using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V_StateOnline.Core.Models;
using System.Runtime.Caching;

namespace V_StateOnline.DataAccess.Inmemory
{
    public class CategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public CategoryRepository()
        {
            productCategories = cache["categories"] as List<ProductCategory>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;

        }
        public void Insert(ProductCategory p)
            
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory productCategoryToUpdate = productCategories.Find(p=> p.Id == p.Id);
            if (productCategoryToUpdate !=null)
            {
                productCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Category Not Found");
            }
        }
        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productCategories.Find(p => p.Id == Id);
            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("Category Not Found");
            }
        }

        public ProductCategory Find(string id)
        {
            throw new NotImplementedException();
        }
    }
}
