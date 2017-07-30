using Model.EntityFramework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.DAO
{
    public class UserService
    {
        private readonly OnlineShopDbContext _dbContext;

        public UserService()
        {
            _dbContext = new OnlineShopDbContext();
        }

        public long Insert(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return user.Id;
        }

        public bool Update(User entity)
        {
            try
            {
                var user = _dbContext.Users.Find(entity.Id);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                    user.Password = entity.Password;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> users = _dbContext.Users;
            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(x => x.Username.Contains(searchString) || x.Name.Contains(searchString));
            }
            return users.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }

        public User GetUserBy(string username)
        {
            return _dbContext.Users.SingleOrDefault(x => x.Username == username);
        }

        public User GetUserBy(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public int Login(string username, string password)
        {
            var result = _dbContext.Users.SingleOrDefault(x => x.Username == username);
            if (result == null)
                return 0;
            if (result.Status == false)
                return -1;
            if (result.Password == password)
                return 1;
            return -2;
        }

        public bool Delete(int id)
        {
            try
            {
                var user = _dbContext.Users.Find(id);
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
