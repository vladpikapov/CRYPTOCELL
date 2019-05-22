using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;

namespace BLL.WorkWithUser
{
    public class WorkWithUserLog : UserLogWork
    {
      private  Users_LogRepository db { get; set; }
        public WorkWithUserLog()
        {
            db = new Users_LogRepository(new DAL.EF.CryptoCellDB());
          
        }
        public void AddUser(Users_LogDTO user)
        {
            USERS_LOG userLog = new USERS_LOG
            {
                UserLogName = user.UserLogName,
                UserLogPassword = user.UserLogPassword,
                UserMail = user.UserMail
            };
            db.Create(userLog);
            db.Save();

        }

        public Users_LogDTO GetUser(string username)
        {
            USERS_LOG log = db.Get(username);
            if (log != null)
                return new Users_LogDTO { UserLogName = log.UserLogName, UserLogPassword = log.UserLogPassword, UserMail = log.UserMail };
            else
                return null;
        }

        public void SaveInfo(Users_LogDTO info)
        {
            var log = db.Get(info.UserLogName);
            log.UserLogPassword = info.UserLogPassword;
            db.UpdateAndSave(log);
        }
    }
}
