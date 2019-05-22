using Logic;

namespace AttendanceSystem
{
    public class PasswordChangeViewModel
    {
        private LogicSystem _logic;

        public PasswordChangeViewModel(LogicSystem logic)
        {
            _logic = logic;
        }

        public bool CheckOldPass(int idEmployee, string oldPassword)
        {
            return (_logic.CheckLogin(idEmployee, oldPassword));
        }

        public bool CompareNewPass(string newPass, string confirmPass)
        {
            return (newPass.Equals(confirmPass));
        }

        public void ChangePassword(int idEmployee, string newPass)
        {
            _logic.ChangePasswordByEmployeeId(idEmployee, newPass);
        }
    }
}
