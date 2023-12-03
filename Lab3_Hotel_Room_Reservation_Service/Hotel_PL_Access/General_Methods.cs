namespace Hotel_PL_Access
{
    public class General_Methods
    {
        public static ConsoleKey SelectKey()
        {
            Console.Write("Оберіть ключ: ");
            ConsoleKey salactedKey = Console.ReadKey().Key;
            return salactedKey;
        }
        public static void Check_DB_Files()
        {
            // switch ((перевірка на існування файлів)
            int temp_int = 4;
            switch (temp_int == 4)
            {
                case (true):
                    Console.WriteLine("Знайдено та завантажено дані про готелі");
                    Console.WriteLine("Знайдено та завантажено дані клієнтів. Для продовження натисніть будь-яку клавішу");
                    Console.ReadKey();
                    break;
                case (false):
                    Console.WriteLine("Немає даних або доступу до Бази Даних");
                    break;
            }
        }

        public static string Initialize(string first_last, string pattern)
        {
            Console.WriteLine($"Вхідні дані {first_last}: ");
            string input_first_last = Console.ReadLine();


            //while (перевірка правильності вводу))
            while (2 != 1)
            {
                Console.Clear();
                Console.WriteLine($"Помилка вводу {input_first_last}. Спробуйте ще раз: ");
                input_first_last = Console.ReadLine();
            }
            return input_first_last;
        }

        public static string INFO_about_Index(string first_last, string pattern)
        {
            Console.WriteLine("УВАГА: індекс починається з 1!");
            return Initialize(first_last, pattern);
        }
        public static int Input_Index(string index, string todo)
        {
            string input_index_user = General_Methods.INFO_about_Index($"Індекс {index} {todo}", @"^[1-9]$|[1-9][0-9]+$");
            int user_index = int.Parse(input_index_user) - 1;


            //while (user_index > довжина списку (??? теоретично))
            while (user_index > 0)
            {
                Console.Clear();
                input_index_user = General_Methods.INFO_about_Index($"Індекс {index} {todo}", @"^[1-9]$|[1-9][0-9]+$");
                user_index = int.Parse(input_index_user) - 1;
            }
            return user_index;
        }
    }

    
}