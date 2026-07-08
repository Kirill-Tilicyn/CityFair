using System;
using System.Collections.Generic;
using System.IO.Pipes;

namespace CityFair
{
    internal class Program
    {
        private enum MenuAction
        {
            AddFair = 1,
            AddSeller = 2,
            RegisterSeller = 3,
            RemoveSeller = 4,
            ShowFairs = 5,
            ShowSellers = 6,
            ShowAll = 7,
            Exit = 8
        }

        public static void Main(string[] args)
        {
            bool isProgramWorking = true;

            List<Fair> fairs = new List<Fair>();
            List<Seller> sellers = new List<Seller>();

            while (isProgramWorking)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine($"{(int)MenuAction.AddFair} - Добавить новую ярмарку");
                Console.WriteLine($"{(int)MenuAction.AddSeller} - Добавить нового продавца");
                Console.WriteLine($"{(int)MenuAction.RegisterSeller} - Зарегистрировать продавца на ярмарку");
                Console.WriteLine($"{(int)MenuAction.RemoveSeller} - Снять продавца с ярмарки");
                Console.WriteLine($"{(int)MenuAction.ShowFairs} - Просмотреть список доступных ярмарок");
                Console.WriteLine($"{(int)MenuAction.ShowSellers} - Просмотреть список продавцов");
                Console.WriteLine($"{(int)MenuAction.ShowAll} - Просмотреть все ярмарки и зарегистрированных продавцов");
                Console.WriteLine($"{(int)MenuAction.Exit} - Завершить работу приложения");
                Console.Write("Выберите вариант действия: ");
                string userNumberText = Console.ReadLine().Trim();
                bool isUserNumberValid = int.TryParse(userNumberText, out int userNumber);

                Console.WriteLine();

                string nameSeller = "";
                string nameFair = "";

                if (isUserNumberValid)
                {
                    if (userNumber == (int)MenuAction.AddFair)
                    {
                        bool isNameFairValid = RequestNameFair(ref nameFair);

                        if (isNameFairValid)
                        {
                            fairs.Add(new Fair(nameFair));

                            Console.WriteLine("Ярмарка создана!");
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели некорректные данные! Ярмарка не создана!");
                        }
                    }
                    else if (userNumber == (int)MenuAction.AddSeller)
                    {
                        bool isNameSellerValid = RequestNameSeller(ref nameSeller);

                        if (isNameSellerValid)
                        {
                            sellers.Add(new Seller(nameSeller));

                            Console.WriteLine("Продавец создан!");
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели некорректные данные! Продавец не создан!");
                        }
                    }
                    else if (userNumber == (int)MenuAction.RegisterSeller)
                    {
                        bool isNameSellerValid = RequestNameSeller(ref nameSeller);
                        bool isNameFairValid = RequestNameFair(ref nameFair);
                        
                        if (isNameSellerValid && isNameFairValid)
                        {

                        }
                        else
                        {
                            Console.WriteLine("Вы ввели некорректные данные! Действие невозможно!");
                        }
                    }
                    else if (userNumber == (int)MenuAction.RemoveSeller)
                    {
                        bool isNameSellerValid = RequestNameSeller(ref nameSeller);
                        bool isNameFairValid = RequestNameFair(ref nameFair);
                        
                        if (isNameSellerValid && isNameFairValid)
                        {

                        }
                        else
                        {
                            Console.WriteLine("Вы ввели некорректные данные! Действие невозможно!");
                        }
                    }
                    else if (userNumber == (int)MenuAction.ShowFairs)
                    {

                    }
                    else if (userNumber == (int)MenuAction.ShowSellers)                    
                    {
                        
                    }
                    else if (userNumber == (int)MenuAction.ShowAll)
                    {
                    }
                    else if (userNumber == (int)MenuAction.Exit)
                    {
                        isProgramWorking = false;
                    }
                    else
                    {
                        Console.WriteLine("Некорректный выбор. Пожалуйста, выберите действие из списка.");
                    }
                }
            }

            Console.WriteLine("Завершение работы приложения...");
            Console.ReadKey();
        }

        public static bool RequestNameFair(ref string nameFair)
        {
            Console.Write("Введите название ярмарки: ");
            nameFair = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(nameFair))
            {
                return false;
            }
            return true;
        }

        public static bool RequestNameSeller(ref string nameSeller)
        {
            Console.Write("Введите имя продавца: ");
            nameSeller = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(nameSeller))
            {
                return false;
            }

            return true;
        }
    }
}