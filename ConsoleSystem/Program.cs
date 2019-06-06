using Logic;
using System.Globalization;

namespace ConsoleSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en");
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader(writer);
            LogicSystem logicSystem = new LogicSystem();
            LogicTerminal logicTerminal = new LogicTerminal();
            MainMenu mainMenu = new MainMenu(reader, writer, logicSystem, logicTerminal);
        }
    }
}
