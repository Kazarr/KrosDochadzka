using Logic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AttendanceSystem
{
    public class PasswordChangeViewModel : INotifyPropertyChanged
    {
        private LogicSystem _logic;
        private int _employeeId;
        private string _oldPass = string.Empty;
        private string _newPass = string.Empty;
        private string _confirmPass = string.Empty;
        private string _userMessage = string.Empty;

        public string OldPass
        {
            get => _oldPass;
            set
            {
                _oldPass = value;
                CheckOldPass();
                OnPropertyChange();
            }
        }

        public string NewPass
        {
            get => _newPass;
            set
            {
                _newPass = value;
            }
        }
        public string ConfirmPass
        {
            get => _confirmPass;
            set
            {
                _confirmPass = value;
                CompareNewPass();
                OnPropertyChange();
            }
        }
        public string UserMessage
        {
            get => _userMessage;
            set
            {
                _userMessage = value;
                OnPropertyChange();
            }
        }

        public PasswordChangeViewModel(LogicSystem logic, int employeeId)
        {
            _logic = logic;
            _employeeId = employeeId;
        }

        public void CheckOldPass()
        {
            if (!(_logic.CheckLogin(_employeeId, _oldPass)))
            {
                UserMessage = "Current password is wrong";
            }
            else
            {
                UserMessage = string.Empty;
            }
        }

        public void CompareNewPass()
        {
            if (!(_newPass.Equals(_confirmPass)))
            {
                UserMessage = "The new password does not match";
            }
            else
            {
                UserMessage = string.Empty;
            }
        }

        public void ChangePassword()
        {
            if (_logic.CheckLogin(_employeeId, _oldPass) && (_newPass.Equals(_confirmPass)))
            {
                _logic.ChangePasswordByEmployeeId(_employeeId, _newPass);
                UserMessage = "Password has been changed successfully";
            }
            else
            {
                UserMessage = "Password not changed";
            }
        }


        #region Inotify Property Change

        private void OnPropertyChange([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
