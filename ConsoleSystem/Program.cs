using Logic;

namespace ConsoleSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader(writer);
            LogicSystem logicSystem = new LogicSystem();
            LogicTerminal logicTerminal = new LogicTerminal();
            MainMenu mainMenu = new MainMenu(reader, writer, logicSystem, logicTerminal);
        }
    }
}
