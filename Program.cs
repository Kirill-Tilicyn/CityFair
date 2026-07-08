using System;

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

            while (isProgramWorking)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine($" - Добавить новую ярмарку");
                Console.WriteLine($"2 - Добавить нового продавца");
                Console.WriteLine($"3 - Зарегистрировать продавца на ярмарку");
                Console.WriteLine($"4 - Снять продавца с ярмарки");
                Console.WriteLine($"5 - Просмотреть список доступных ярмарок");
                Console.WriteLine($"6 - Просмотреть список продавцов");
                Console.WriteLine($"7 - Просмотреть все ярмарки и зарегистрированных продавцов");
                Console.WriteLine($"8 - Завершить работу приложения");
                Console.Write("Выберите вариант действия: ");
                string userNumberText = Console.ReadLine().Trim();
                bool isUserNumberValid = int.TryParse(userNumberText, out int userNumber);

            }
        }
    }
}