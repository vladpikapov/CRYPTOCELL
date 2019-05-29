using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BLL.WorkWithUser
{
    public class WorkWithUserTransact : UserTransactWork
    {
        private UnityOfWork db = new UnityOfWork();

        public void AddTransact(Users_TransactionDTO transact)
        {
            USERS_TRANSACTIONS transactDB = new USERS_TRANSACTIONS
            {
                FromUserName = transact.FromUserName,
                ToUserName = transact.ToUserName,
                SumOfTans = transact.SumOfTans,
                DateOfTrans = transact.DateOfTrans,
                UserID = transact.UserID
            };
            db.Users_Transactions.Create(transactDB);
            db.Users_Transactions.Save();

        }

        public IEnumerable<Users_TransactionDTO> GetTransaction(Users_InfoDTO info)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<USERS_TRANSACTIONS, Users_TransactionDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<USERS_TRANSACTIONS>, List<Users_TransactionDTO>>(db.Users_Transactions.GetAll()).Where(x=>x.UserID == info.UserID);
        }

    }
}
