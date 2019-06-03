using Data.Model;
using Logic;

namespace ConsoleSystem
{
    class TerminalConsole
    {
        private IReader _reader;
        private IWriter _writer;
        private int _loginId;
        private LogicTerminal _logicTerminal;

        public TerminalConsole(int id, IReader reader, IWriter writer, LogicTerminal terminal)
        {
            _loginId = id;
            _reader = reader;
            _writer = writer;
            _logicTerminal = terminal;
        }

        public void TerminalMenu()
        {
            _writer.Writer(Properties.Resources.TerminalMenu);
            int choice = _reader.NumberReader();
            switch (choice)
            {
                case 1: DescribeAndProcessAction(EnumWorkType.Work); break;
                case 2: DescribeAndProcessAction(EnumWorkType.Lunch); break;
                case 3: DescribeAndProcessAction(EnumWorkType.Doctor); break;
                case 4: DescribeAndProcessAction(EnumWorkType.BusinessTrip); break;
                case 5: DescribeAndProcessAction(EnumWorkType.Private); break;
                case 6: DescribeAndProcessAction(EnumWorkType.Exit); break;
                case 0: break;
                default:
                    _writer.Writer(Properties.Resources.WrongInputError);
                    TerminalMenu();
                    break;
            }
            _writer.Writer(Properties.Resources.PressKey);
            _reader.ReadLine();
            _writer.Clear();
        }

        private void DescribeAndProcessAction(EnumWorkType workType)
        {
            _logicTerminal.ProcessAction(_loginId, workType);
            _writer.Writer($"{_logicTerminal.DescriptionFullname(_loginId)} {workType}");
        }
    }
}
