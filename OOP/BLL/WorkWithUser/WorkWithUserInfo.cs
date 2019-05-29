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
       private UnityOfWork db = new UnityOfWork();

        public Users_InfoDTO GetUser(string login)
        {
            var user = db.Users_Info.Get(login);
            if (user == null)
                return null;
            else
                return new Users_InfoDTO { UserID = user.UserID, UserName = user.UserName };
        }
    }
}
