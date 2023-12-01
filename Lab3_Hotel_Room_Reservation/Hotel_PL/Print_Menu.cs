﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_PL
{
    internal class Print_Menu
    {

        internal static string Print_MainMenu()
        {
            return "\tГОЛОВНЕ МЕНЮ \n" +
                "Оберіть додаткове меню: \n\n" +
                "1 - Готелі \n" +
                "2 - Кімнати \n" +
                "3 - Клієнти \n" +
                "4 - Пошук \n" +
                "5 - Вихід \n";
        }

        internal static string Hotel_Menu()
        {
            return "\tМенеджмент ГОТЕЛЮ \n" +
                   $"Створені готелі:  .....\n\n" +
                    "Оберіть:  \n\n" +
                    "1 - Додати готель.\n" +
                    "2 - Видалити готель.\n" +
                    "3 - Список всіх створених готелів.\n" +
                    "4 - Інформація про конретний готель.\n" +
                    "5 - Інформація про всі готелі.\n" +
                    "F - Повернутися до головного меню";
        }

        internal static string Visitors_Menu()
        {
            return "\tМенеджмент КЛІЄНТІВ \n" +
                      $"Створено клієнтів:  .....\n\n" +
                      "Оберіть: \n\n" + 
                      "1 - Додати клієнта.\n" + 
                      "2 - Видалити клієнта.\n" + 
                      "3 - Змінити інформацію про клієнта.\n" + 
                      "4 - Список всіх створених клієнтів.\n" + 
                      "5 - Інформацію про конкретного клієнта.\n" + 
                      "6 - Інформацію про всіх клієнтів.\n" +
                      "7 - Сортування списку за іменем (↑) і (↓).\n" +
                      "8 - Сортування списку за прізвищем (↑) і (↓).\n" + 
                      "F - Повернутися до головного меню";
        }

        internal static string Room_Menu()
        {
            return "\tМенеджмент КІМНАТ \n" +
                       "Оберіть: \n\n" +
                       "1 - Забронювати кімнату в готелі.\n" +
                       "2 - Відміна резервації.\n" +
                       "3 - Список всіх кімнат у готелі.\n" +
                       "4 - Загальна інформацію про кімнати, резервацію, ціни і дату.\n" +
                       "F - Повернутися до головного меню";
        }

        internal static string Search_Menu()
        {
            return "\tШукати (оберіть ключ): \n"+
                "1 - Пошук за ключовим словом серед готелів\n\n" +
                "2 - Пошук за ключовим словом серед клієнтів.\n" +
                "F - Повернутися до головного меню";
        }
    }
}
