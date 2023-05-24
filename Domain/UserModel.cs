using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Domain
{
    public class UserModel
    {

        UserDAO userDao = new UserDAO();

        public bool LoginUser(string correo, string password)
        {
            return userDao.Login(correo, password);
        }

    }
}
