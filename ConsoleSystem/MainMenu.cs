using Logic;
using System;

namespace ConsoleSystem
{
    class MainMenu
    {
        private IWriter _writer;
        private IReader _reader;
        private LogicSystem _logicSystem;
        private LogicTerminal _logicTerminal;

        public MainMenu(IReader reader, IWriter writer, LogicSystem logicSystem, LogicTerminal logicTerminal)
        {
            _writer = writer;
            _reader = reader;
            _logicSystem = logicSystem;
            _logicTerminal = logicTerminal;
            MenuChooseSystem();
        }

        private void MenuChooseSystem()
        {
            _writer.Writer(Properties.Resources.MenuChooseSystem);
            int choice = _reader.NumberReader();

            switch (choice)
            {
                case 1: _writer.Clear(); EnterLogin(); break;
                case 2: _writer.Clear(); LogInWithPassword(); break;
                case 3: _writer.Clear(); Environment.Exit(0); break;
                default: _writer.Writer(Properties.Resources.WrongInputError); MenuChooseSystem(); break;
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
                MonthOverviewConsole monthOverview = new MonthOverviewConsole(login, _reader, _writer, _logicSystem);
                monthOverview.GetMonthOverview();
                MenuChooseSystem();
            }
            else
            {
                _writer.Clear();
                _writer.Writer(Properties.Resources.WrongLoginPassError);
                MenuChooseSystem();
            }
        }

        private void EnterLogin()
        {
            _writer.Writer(Properties.Resources.EnterLogin);
            int loginID = _reader.NumberReader();
            if (_logicTerminal.IsCorrectEmp(loginID))
            {
                TerminalConsole terminal = new TerminalConsole(loginID, _reader, _writer, _logicTerminal);
                terminal.TerminalMenu();
                MenuChooseSystem();
            }
            else
            {
                _writer.Writer(Properties.Resources.WrongUser);
                MenuChooseSystem();
            }
        }
    }
}
