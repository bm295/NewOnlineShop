using Model.EntityFramework;

namespace Model.DAO
{
    public class ContentService
    {
        private readonly OnlineShopDbContext _dbContext;

        public ContentService()
        {
            _dbContext = new OnlineShopDbContext();
        }

        public Content GetContentBy(long id)
        {
            return _dbContext.Contents.Find(id);
        }
    }
}
