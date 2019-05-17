using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class PasswordChangeViewModel
    {
        private LogicSystem _logicSystem = new LogicSystem();

        public bool CheckOldPass(int idEmployee, string oldPassword)
        {
            return (_logicSystem.CheckLogin(idEmployee, oldPassword));
        }

        public bool CompareNewPass(string newPass, string confirmPass)
        {
            return (newPass.Equals(confirmPass));
        }

        public void ChangePassword(int idEmployee, string newPass)
        {
            _logicSystem.ChangePassword(idEmployee, newPass);
        }
    }
}
