using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using Common.Cache;

namespace Domain
{
    public class UserModel
    {

        UserDAO userDao = new UserDAO();

        public bool LoginUser(string correo, string password)
        {
            return userDao.Login(correo, password);
        }

        public List<UsersCache> ObtenerUsuarios()
        {
            return userDao.ObtenerUsuarios();
        }

    }
}
