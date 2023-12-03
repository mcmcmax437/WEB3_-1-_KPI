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
            General_Methods.Check_DB_Files();

            ConsoleKey key;
            bool exit = false;

            

            while (exit == false)
            {
                Console.Clear();
                Console.WriteLine(Print_Menu.Print_MainMenu());
                key = General_Methods.SelectKey();

                try
                {
                    switch (key)
                    {
                        //Меню Готеля
                        case ConsoleKey.D1:
            hotel_anchor:

                            Console.Clear();
                            Console.WriteLine(Print_Menu.Hotel_Menu());

                            key = General_Methods.SelectKey();

                            switch (key)
                            {

                                //Створити
                                case ConsoleKey.D1:
                                    Console.Clear();
                                    Action_with_Hotel.Add_Hotel();
                                    break;

                                //Видалити
                                case ConsoleKey.D2:
                                    Action_with_Hotel.Remove_Hotel();
                                    break;

                                //Інформація про готелі
                                case ConsoleKey.D3:
                                    Console.Clear();
                                    Action_with_Hotel.Show_Hotels(key);
                                    Console.WriteLine("Натисни будь яку кнопку для повернення до Головного Меню");
                                    Console.ReadKey();

                                    break;

                                //Інформація про конкретний готель
                                case ConsoleKey.D4:
                                    Action_with_Hotel.Show_specific_Hotel();
                                    break;


                                case ConsoleKey.D5:
                                    Console.Clear();
                                    Action_with_Hotel.Show_Hotels(ConsoleKey.D4);
                                    Console.WriteLine("Натисни будь яку кнопку для повернення до Головного Меню");
                                    Console.ReadKey();
                                    break;

                                case ConsoleKey.R:
                                    break;

                                default: goto hotel_anchor;
                            }
                            break;

                        //Меню Клієнтів
                        case ConsoleKey.D2:
            client_anchor:

                            Console.Clear();
                            Console.WriteLine(Print_Menu.Visitors_Menu());

                            key = General_Methods.SelectKey();

                            switch (key)
                            {
                                case ConsoleKey.D1:
                                    break;
                                case ConsoleKey.D2:
                                    break;
                                case ConsoleKey.D3:
                                    break;
                                case ConsoleKey.D4:
                                    break;
                                case ConsoleKey.D5:
                                    break;
                                case ConsoleKey.R:
                                    break;

                                default: goto client_anchor;
                            }
                            break;

                        //Меню Кімнат
                        case ConsoleKey.D3:
            room_anchor:
                            Console.Clear();
                            Console.WriteLine(Print_Menu.Room_Menu());

                            key = General_Methods.SelectKey();

                            switch (key)
                            {
                                case ConsoleKey.D1:
                                    break;
                                case ConsoleKey.D2:
                                    break;
                                case ConsoleKey.D3:
                                    break;
                                case ConsoleKey.D4:
                                    break;
                                case ConsoleKey.D5:
                                    break;
                                case ConsoleKey.R:
                                    break;

                                default: goto room_anchor;
                            }
                            break;

                        //Меню Пошуку
                        case ConsoleKey.D4:
            search_anchor:

                            Console.Clear();
                            Console.WriteLine(Print_Menu.Search_Menu());

                            key = General_Methods.SelectKey();

                            switch (key)
                            {
                                case ConsoleKey.D1:
                                    break;
                                case ConsoleKey.D2:
                                    break;
                                case ConsoleKey.D3:
                                    break;
                                case ConsoleKey.D4:
                                    break;
                                case ConsoleKey.D5:
                                    break;
                                case ConsoleKey.R:
                                    break;

                                default: goto search_anchor;
                            }
                            break;

                        case ConsoleKey.D5:
                            exit = true;
                            return;
                    }

                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Натисни кнопку для повернення до Головного Меню");
                    Console.ReadKey();
                }
            }
        }
    }
}

