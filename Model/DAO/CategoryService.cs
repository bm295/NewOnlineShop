using System.Collections.Generic;
using System.Linq;
using Model.EntityFramework;

namespace Model.DAO
{
    public class CategoryService
    {
        private readonly OnlineShopDbContext _dbContext;

        public CategoryService()
        {
            _dbContext = new OnlineShopDbContext();
        }

        public List<Category> ListAll()
        {
            return _dbContext.Categories.Where(x => x.Status == true).ToList();
        }
    }
}
