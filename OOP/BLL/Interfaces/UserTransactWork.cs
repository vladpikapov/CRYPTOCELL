using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    interface UserTransactWork
    {
        void AddTransact(Users_TransactionDTO transact);
        IEnumerable<Users_TransactionDTO> GetTransaction(Users_InfoDTO info);
        
    }
}
