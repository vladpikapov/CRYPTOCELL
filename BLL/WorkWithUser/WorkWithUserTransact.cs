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
        Users_TransactionsRepository db { get; set; }
        public WorkWithUserTransact()
        {
            db = new Users_TransactionsRepository(new DAL.EF.CryptoCellDB());
        }

        public void AddTransact(Users_TransactionDTO transact)
        {
            USERS_TRANSACTIONS transactDB = new USERS_TRANSACTIONS
            {
                FromUserName = transact.FromUserName,
                ToUserName = transact.ToUserName,
                SumOfTans = transact.SumOfTans
            };
            db.Create(transactDB);
            db.Save();

        }

        public IEnumerable<Users_TransactionDTO> GetTransaction(Users_InfoDTO info)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<USERS_TRANSACTIONS, Users_TransactionDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<USERS_TRANSACTIONS>, List<Users_TransactionDTO>>(db.GetAll()).Where(x=>x.FromUserName.Equals(info.UserName)||x.ToUserName.Equals(info.UserName));
        }

       
    }
}
