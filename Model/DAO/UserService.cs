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

        public bool Login(string username, string password)
        {
            var result = onlineShopDbContext.Users.Count(x => x.Username == username && x.Password == password);
            if (result > 0)
                return true;
            return false;
        }
    }
}
