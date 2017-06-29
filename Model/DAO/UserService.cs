using Model.EntityFramework;
using System.Linq;

namespace Model.DAO
{
    public class UserService
    {
        OnlineShopDbContext onlineShopDbContext = null;

        public UserService()
        {
            onlineShopDbContext = new OnlineShopDbContext();
        }

        public long Insert(User user)
        {
            onlineShopDbContext.Users.Add(user);
            onlineShopDbContext.SaveChanges();
            return user.Id;
        }

        public User GetUserBy(string username)
        {
            return onlineShopDbContext.Users.SingleOrDefault(x => x.Username == username);
        }

        public int Login(string username, string password)
        {
            var result = onlineShopDbContext.Users.SingleOrDefault(x => x.Username == username);
            if (result == null)
                return 0;
            if (result.Status == false)
                return -1;
            if (result.Password == password)
                return 1;
            return -2;
        }
    }
}
