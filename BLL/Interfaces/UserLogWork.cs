﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
   public interface UserLogWork
    {
        Users_LogDTO GetUser(string username);
        void AddUser(Users_LogDTO user);
        void SaveInfo(Users_LogDTO info);
       
    }
}
