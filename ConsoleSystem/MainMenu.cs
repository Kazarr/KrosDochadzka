using Logic;
using System;

namespace ConsoleSystem
{
    class MainMenu
    {
        private IWriter _writer = new ConsoleWriter();
        private IReader _reader = new ConsoleReader();
        private LogicSystem _logicSystem = new LogicSystem();

        public MainMenu()
        {
            MenuChooseSystem();
        }

        private void MenuChooseSystem()
        {
            _writer.Writer(Properties.Resources.MenuChooseSystem);
            int choice = _reader.NumberReader();
            if (choice == 2)
            {
                Console.Clear();
                LogInWithPassword();

            }
            else if (choice == 1)
            {
                Console.Clear();
                EnterLogin();
            }
            else if (choice==3)
            {
                Console.Clear();
                Environment.Exit(0);
            }
            else
            {
                _writer.Writer(Properties.Resources.WrongInputError);
                MenuChooseSystem();
            }
        }

        private void LogInWithPassword()
        {
            
            _writer.Writer(Properties.Resources.EnterLogin);
            int login = _reader.NumberReader();
            _writer.Writer(Properties.Resources.EnterPassword);
            string password = _reader.PasswordReader();

            if (_logicSystem.CheckLogin(login, password))
            {
                MonthOverviewConsole monthOverview = new MonthOverviewConsole(login, _reader, _writer,_logicSystem);
                MenuChooseSystem();
            }
            else
            {
                Console.Clear();
                _writer.Writer(Properties.Resources.WrongLoginPassError);
                LogInWithPassword();
            }
        }

        private void EnterLogin()
        {
            _writer.Writer(Properties.Resources.EnterLogin);
            int loginID = _reader.NumberReader();
            //loginCheck
        }


    }
}
