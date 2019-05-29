using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;
using System.Collections.Generic;

namespace BLL.WorkWithUser
{
    public class WorkWithUserLog : UserLogWork
    {
        private UnityOfWork db = new UnityOfWork();
     
        public void AddUser(Users_LogDTO user)
        {
            USERS_LOG userLog = new USERS_LOG
            {
                UserLogName = user.UserLogName,
                UserLogPassword = user.UserLogPassword,
                UserMail = user.UserMail
            };
            db.Users_Log.Create(userLog);
            db.Users_Log.Save();

        }

        public Users_LogDTO GetUser(string username)
        {
            USERS_LOG log = db.Users_Log.Get(username);
            if (log != null)
                return new Users_LogDTO { UserLogName = log.UserLogName, UserLogPassword = log.UserLogPassword, UserMail = log.UserMail };
            else
                return null;
        }

        public bool CheckMail(string mail)
        {
            return db.Users_Log.GetAllMail(mail);
        }

        public void SaveInfo(Users_LogDTO info)
        {
            var log = db.Users_Log.Get(info.UserLogName);
            log.UserLogPassword = info.UserLogPassword;
            db.Users_Log.UpdateAndSave(log);
        }
    }
}
