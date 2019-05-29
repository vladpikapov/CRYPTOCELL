using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UnityOfWork
    {
        private CryptoCellDB db = new CryptoCellDB();
        private CurreinciesRepository curreinciesRepository;
        private Users_InfoRepository infoRepository;
        private Users_LogRepository logRepository;
        private Users_TransactionsRepository transactionsRepository;
        public CurreinciesRepository Curreincies
        {
            get
            {
                if (curreinciesRepository == null)
                    curreinciesRepository = new CurreinciesRepository(db);
                return curreinciesRepository;
            }
        }
        public Users_InfoRepository Users_Info
        {
            get
            {
                if (infoRepository == null)
                    infoRepository = new Users_InfoRepository(db);
                return infoRepository;
            }
        }
        public Users_LogRepository Users_Log
        {
            get
            {
                if (logRepository == null)
                    logRepository = new Users_LogRepository(db);
                return logRepository;
            }
        }
        public Users_TransactionsRepository Users_Transactions
        {
            get
            {
                if (transactionsRepository == null)
                    transactionsRepository = new Users_TransactionsRepository(db);
                return transactionsRepository;
            }
        }
    }
}
