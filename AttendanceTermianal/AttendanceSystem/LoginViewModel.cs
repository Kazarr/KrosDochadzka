﻿using Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    class LoginViewModel
    {
        public bool CheckLogin(int id, string password)
        {
            return ManagerRepository.EmployeeRepository.CheckLogin(id,password);
        }

       
    }
}
