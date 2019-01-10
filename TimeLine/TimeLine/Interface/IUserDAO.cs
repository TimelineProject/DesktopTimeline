using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLine.Entity;

namespace TimeLine.Interface
{
    public interface IUserDAO
    {
        int RegisterUser(User user);
        int GetUserNumByAccountAndPassword(User user);
        int GetUserNumByAccount(User user);
        int getUserIdByUser(IDataReader reader);
    }
}
