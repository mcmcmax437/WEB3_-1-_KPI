using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel_PL_Access;

namespace Hotel_PL
{
    public class Menu
    {
        public static void StartMainMenu()
        {
            ConsoleKey key;
            bool exit = false;

            

            while (exit == false)
            {
                //Console.Clear();
                Console.WriteLine(Print_Menu.Print_MainMenu());
                key = General_Methods.SelectKey();

                try
                {
                    switch (key)
                    {
                        case ConsoleKey.D1:
                            Console.Clear();
                            Console.WriteLine(Print_Menu.Hotel_Menu());

                            key = General_Methods.SelectKey();

                            break;
                      
                        case ConsoleKey.D5:
                            exit = true;
                            return;
                    }

                }
                catch (Exception e)
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

