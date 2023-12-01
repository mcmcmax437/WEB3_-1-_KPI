using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_PL
{
    public class Menu
    {
        public static void StartMainMenu()
        {
            ConsoleKey keyInfo;
            bool exit = false;

            int temp_key = 0;

            while (exit == false)
            {
                //Console.Clear();
                Console.WriteLine("Нюхай бебру");
                Console.WriteLine("1 - xxxxxx");
                Console.WriteLine("2 - xxxxxx");
                Console.WriteLine("3 - xxxxxx");
                Console.WriteLine("4 - xxxxxx");
                Console.WriteLine("5 - Exit");
                Console.Write("Ваш вибір: ");
                temp_key = int.Parse(Console.ReadLine());

                try
                {
                    switch (temp_key)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Поставте 60 ПЖ");
                            Console.ReadKey();
                            Console.Clear();
                            
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("І Не туди");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Знову не туди");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Нєа, не туди");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 5:
                            exit = true;
                            return;
                    }
                        
                }catch (Exception e)
                {
                   // Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Натисни кнопку для повернення до Головного Меню");
                    Console.ReadKey();
                }
            }
        }
    }
}
