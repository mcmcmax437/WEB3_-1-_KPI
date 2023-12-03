namespace Hotel_PL_Access
{
    public class General_Methods
    {
        public static ConsoleKey SelectKey()
        {
            Console.WriteLine("Оберіть ключ: ");
            ConsoleKey salactedKey = Console.ReadKey().Key;
            return salactedKey;
        }
    }
}