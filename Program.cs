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

                if (isUserNumberValid)
                {
                    switch (userNumber)
                    {
                        case (int)MenuAction.AddFair:
                            //FairManager.AddFair();
                            break;

                        case (int)MenuAction.AddSeller:
                            //SellerManager.AddSeller();
                            break;

                        case (int)MenuAction.RegisterSeller:
                            //FairManager.RegisterSellerToFair();
                            break;

                        case (int)MenuAction.RemoveSeller:
                            //FairManager.RemoveSellerFromFair();
                            break;

                        case (int)MenuAction.ShowFairs:
                            //FairManager.ShowFairs();
                            break;

                        case (int)MenuAction.ShowSellers:
                            //SellerManager.ShowSellers();
                            break;

                        case (int)MenuAction.ShowAll:
                            //FairManager.ShowAllFairsAndSellers();
                            break;

                        case (int)MenuAction.Exit:
                            isProgramWorking = false;
                            break;

                        default:
                            Console.WriteLine("Некорректный выбор. Пожалуйста, выберите действие из списка.");
                            break;
                    }
                }
            }

            Console.WriteLine("Завершение работы приложения...");
            Console.ReadKey();
        }
    }
}