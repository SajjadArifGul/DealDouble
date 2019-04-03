using DealDouble.Data;
using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class CategoriesService
    {
        public List<Category> GetAllCategories()
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Categories.ToList();
        }

        public List<Category> GetAllParentCategories()
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Categories.Where(x=>!x.ParentCategoryID.HasValue).ToList();
        }

        public Category GetCategoryByID(int ID)
        {
            DealDoubleContext context = new DealDoubleContext();

            return context.Categories.Find(ID);
        }

        public void SaveCategory(Category category)
        {
            DealDoubleContext context = new DealDoubleContext();

            context.Categories.Add(category);

            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            DealDoubleContext context = new DealDoubleContext();

            context.Entry(category).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }


        public void DeleteCategory(Category category)
        {
            DealDoubleContext context = new DealDoubleContext();

            context.Entry(category).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();
        }


        public List<Category> SearchCategories(int? parentCategoryID, string searchTerm, int? pageNo, int pageSize)
        {
            DealDoubleContext context = new DealDoubleContext();

            var categories = context.Categories.AsQueryable();

            if (parentCategoryID.HasValue && parentCategoryID.Value > 0)
            {
                categories = categories.Where(x => x.ParentCategoryID == parentCategoryID.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                categories = categories.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            pageNo = pageNo ?? 1;
            var skipCount = (pageNo.Value - 1) * pageSize;

            return categories.OrderByDescending(x => x.ID).Skip(skipCount).Take(pageSize).ToList();
        }

        public int GetCategoriesCount(int? parentCategoryID, string searchTerm)
        {
            DealDoubleContext context = new DealDoubleContext();

            var categories = context.Categories.AsQueryable();

            if (parentCategoryID.HasValue && parentCategoryID.Value > 0)
            {
                categories = categories.Where(x => x.ParentCategoryID == parentCategoryID.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                categories = categories.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            return categories.Count();
        }
    }
}
