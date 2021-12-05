using Snap_n_go.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snap_n_go.Data
{
    public interface IUserRepository
    {
        User create(User user);
        User getByEmail(string email);
        User getById(int id);
    }
}
