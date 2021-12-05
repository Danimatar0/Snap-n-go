using Snap_n_go.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snap_n_go.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _dbContext;
        public UserRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User create(User user)
        {
            _dbContext.users.Add(user);
            user.Id=_dbContext.SaveChanges();
            return user;
        }

        public  User getByEmail(string email)
        {
            return _dbContext.users.FirstOrDefault(u=>u.Email == email);
        }

        public User getById(int id)
        {
            return _dbContext.users.Find(id);
        }
    }
}
