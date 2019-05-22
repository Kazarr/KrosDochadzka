using System;

namespace Data.Generator
{
    class PasswordGenerator
    {
        public string GeneratePassword()
        {
            string chars = "QWERTYUIOPLKJHGFDSAZXCVBNM123456789.";
            Random random = new Random();
            string result = "";
            for (int i = 0; i < 12; i++)
            {
                result = $"{result}{chars[random.Next(0, chars.Length)]}";
            }
            return result;
        }
    }
}
