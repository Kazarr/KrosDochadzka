using System;

namespace ConsoleSystem
{
    class ConsoleReader : IReader
    {
        private IWriter _writer;

        public ConsoleReader(IWriter writer)
        {
            _writer = writer;
        }

        public int NumberReader()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int output))
                {
                    return output;
                }
                else
                {
                    _writer.Writer(Properties.Resources.WrongInputError);
                }
            }
        }

        public string PasswordReader()
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            return pass;
        }

        public void ReadLine()
        {
            Console.ReadLine();
        }
    }
}
