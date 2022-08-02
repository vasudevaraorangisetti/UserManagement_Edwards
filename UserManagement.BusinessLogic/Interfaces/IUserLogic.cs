using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Common;

namespace UserManagement.BusinessLogic
{
    public interface IUserLogic
    {
        IEnumerable<User> List();
        User Get(int id);

        Response Insert(User user);

        Response Update(User user);

        Response Delete(int id);
    }
}
