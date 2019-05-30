namespace ConsoleSystem
{
    interface IReader
    {
        T Reader<T>();
        int NumberReader();
        string PasswordReader();
    }
}
