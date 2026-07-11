using System;
using System.Collections.Generic;
using System.IO.Pipes;

namespace CityFair
{
    internal class Program
    {
        private enum MenuAction
        {
            ShowFairs = 1,
            ShowPoints = 2,
            AddPoint = 3,
            ShowSellers = 4,
            AddSeller = 5,
            RegisterSeller = 6,
            RemoveSeller = 7,
            ShowAll = 8,
            Exit = 9
        }

        public static void Main(string[] args)
        {
            bool isProgramWorking = true;

            List<Fair> fairs = new List<Fair>
            {
                new Fair("Северная Ярмарка"),
                new Fair("Южная Ярмарка"),
                new Fair("Западная Ярмарка"),
                new Fair("Восточная Ярмарка")
            };

            List<Seller> sellers = new List<Seller>();

            while (isProgramWorking)
            {
                ShowMenu();

                string userNumberText = Console.ReadLine().Trim();
                bool isUserNumberValid = int.TryParse(userNumberText, out int userNumber);

                Console.WriteLine();

            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine();

            Console.WriteLine("--- Ярмарки ---");
            Console.WriteLine($"{(int)MenuAction.ShowFairs}. Просмотреть список ярмарок");
            Console.WriteLine();

            Console.WriteLine("--- Торговые точки ---");
            Console.WriteLine($"{(int)MenuAction.ShowPoints}. Просмотреть торговые точки ярмарки");
            Console.WriteLine($"{(int)MenuAction.AddPoint}. Добавить торговую точку в ярмарку");
            Console.WriteLine();

            Console.WriteLine("--- Продавцы ---");
            Console.WriteLine($"{(int)MenuAction.ShowSellers}. Просмотреть список продавцов");
            Console.WriteLine($"{(int)MenuAction.AddSeller}. Добавить нового продавца");
            Console.WriteLine();

            Console.WriteLine("--- Регистрация ---");
            Console.WriteLine($"{(int)MenuAction.RegisterSeller}. Зарегистрировать продавца на торговую точку");
            Console.WriteLine($"{(int)MenuAction.RemoveSeller}. Снять продавца с торговой точки");
            Console.WriteLine();

            Console.WriteLine("--- Информация ---");
            Console.WriteLine($"{(int)MenuAction.ShowAll}. Показать все ярмарки, точки и продавцов");
            Console.WriteLine($"{(int)MenuAction.Exit}. Завершить работу приложения");
            Console.WriteLine();

            Console.Write("Выберите действие: ");
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