﻿using System;

namespace ConsoleSystem
{
    class ConsoleWriter : IWriter
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Writer(string input)
        {
            Console.WriteLine(input);
        }
    }
}
