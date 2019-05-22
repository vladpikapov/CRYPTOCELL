using BLL.DTO;
using BLL.Interfaces;
using DAL.EF;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.WorkWithUser
{
   public class WorkWithUserInfo : UserInfoWork
    {
        Users_InfoRepository db { get; set; }

        public WorkWithUserInfo()
        {
            db = new Users_InfoRepository(new CryptoCellDB());
        }

        

        public Users_InfoDTO GetUser(string login)
        {
            var user = db.Get(login);
            return new Users_InfoDTO { UserID = user.UserID, UserName = user.UserName };
        }
    }
}
