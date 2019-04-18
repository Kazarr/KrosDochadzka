using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    class LoginViewModel
    {
        public bool CheckLogin(int id, string password)
        {
            return ManagerRepository.employeeRepository.CheckLogin(id,password);
        }
    }
}
