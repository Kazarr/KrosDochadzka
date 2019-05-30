using System;

namespace ConsoleSystem
{
    class ConsoleWriter : IWriter
    {
        public void Writer(string input)
        {
            Console.WriteLine(input);
        }
    }
}
