using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Security.Cryptography;

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

                if (isUserNumberValid)
                {
                    switch (userNumber)
                    {
                        case (int)MenuAction.ShowFairs:
                            ShowFair(fairs);
                            break;

                        case (int)MenuAction.ShowPoints:
                            ShowPoints(fairs);
                            break;

                        case (int)MenuAction.AddPoint:
                            AddPoint(fairs);
                            break;

                        case (int)MenuAction.ShowSellers:
                            ShowSellers(sellers);
                            break;

                        case (int)MenuAction.AddSeller:
                            AddSeller(sellers);
                            break;

                        case (int)MenuAction.RegisterSeller:
                            RegisterSeller(fairs, sellers);
                            break;

                        case (int)MenuAction.RemoveSeller:
                            RemoveSeller(fairs);
                            break;

                        case (int)MenuAction.ShowAll:
                            ShowAll(fairs);
                            break;

                        case (int)MenuAction.Exit:
                            isProgramWorking = false;
                            break;

                        default:
                            Console.WriteLine("Действия под таким номером нет!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Номер вашего действия не распознан! Попробуйте еще раз!");
                }
            }

            Console.WriteLine("Спасибо за использование программы!");
            Console.ReadKey();
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

        public static void ShowFair(List<Fair> fairs)
        {
            Console.WriteLine("Действующие ярмарки: ");

            foreach (Fair fair in fairs)
            {
                Console.WriteLine(fair.GetName());
            }
        }

        public static void ShowPoints(List<Fair> fairs)
        {
            string fairName = RequestNameFair();

            Fair activeFair = null;

            foreach (Fair fair in fairs)
            {
                if (fair == activeFair)
                {
                    activeFair = fair;
                    return;
                }
            }

            if (activeFair != null)
            {
                Console.WriteLine($"Список торговых точек на ярмарке - {activeFair.GetName()}");

                foreach (PointSale point in activeFair.GetPoints())
                {
                    Console.WriteLine(point.GetName());
                }
            }
            else
            {
                Console.WriteLine("Такой ярмарки нет, невозможно выполнить действие!");
            }
        }

        public static void AddPoint(List<Fair> fairs)
        {
            string fairName = RequestNameFair();

            Fair activeFair = null;

            foreach (Fair fair in fairs)
            {
                if (fair == activeFair)
                {
                    activeFair = fair;
                    return;
                }
            }

            if (activeFair != null)
            {
                string namePointSale = RequestNamePointSale();

                bool hasActionCompleted = activeFair.AddPointSale(namePointSale);

                if (hasActionCompleted)
                {
                    Console.WriteLine("Торговая точка создана!");
                }
                else
                {
                    Console.WriteLine("Подобное название торговой точки недоступно!");
                }
            }
            else
            {
                Console.WriteLine("Такой ярмарки нет! Действие отменено!");
            }
        }

        public static void ShowSellers(List<Seller> sellers)
        {
            if (sellers.Count > 0)
            {
                Console.WriteLine("Список продавцов: ");

                foreach (Seller seller in sellers)
                {
                    Console.WriteLine(seller.GetName());
                }
            }
            else
            {
                Console.WriteLine("Нет доступных продавцов!");
            }
        }

        public static void AddSeller(List<Seller> sellers)
        {
            string nameSeller = RequestNameSeller();

            if (string.IsNullOrEmpty(nameSeller))
            {
                sellers.Add(new Seller(nameSeller));

                Console.WriteLine("Действие выполнено!");
            }
            else
            {
                Console.WriteLine("Вы ввели некорректные значения! Действие отменено!");
            }
        }

        public static void RegisterSeller(List<Fair> fairs, List<Seller> sellers)
        {
            string fairName = RequestNameFair();

            Fair activeFair = null;

            foreach (Fair fair in fairs)
            {
                if (fair == activeFair)
                {
                    activeFair = fair;
                    return;
                }
            }

            if (activeFair != null)
            {
                string namePointSale = RequestNamePointSale();

                PointSale activePoint = null;

                if (string.IsNullOrEmpty(namePointSale))
                {
                    foreach (PointSale pointSale in activeFair.GetPoints())
                    {
                        if (pointSale.GetName() == namePointSale)
                        {
                            activePoint = pointSale;
                            break;
                        }
                    }

                    if (activePoint != null)
                    {
                        string nameSeller = RequestNameSeller();

                        Seller activeSeller = null;

                        if (string.IsNullOrEmpty(nameSeller))
                        {
                            foreach (Seller seller in sellers)
                            {
                                if (seller.GetName() == nameSeller)
                                {
                                    activeSeller = seller;
                                }
                            }

                            if (activeSeller != null)
                            {
                                bool hasActionCompleted = activePoint.AddSeller(activeSeller);

                                if (hasActionCompleted)
                                {
                                    Console.WriteLine("Действие выполнено!");
                                }
                                else
                                {
                                    Console.WriteLine("Такого продавца не существует. Действие отменено!");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Такой торговой точки нет! Действие отменено!");
                }
            }
            else
            {
                Console.WriteLine("Такой ярмарки нет! Действие отменено!");
            }
        }

        public static void RemoveSeller(List<Fair> fairs)
        {
            string fairName = RequestNameFair();

            Fair activeFair = null;

            foreach (Fair fair in fairs)
            {
                if (fair == activeFair)
                {
                    activeFair = fair;
                    return;
                }
            }

            if (activeFair != null)
            {
                string namePointSale = RequestNamePointSale();

                PointSale activePoint = null;

                if (string.IsNullOrEmpty(namePointSale))
                {
                    foreach (PointSale pointSale in activeFair.GetPoints())
                    {
                        if (pointSale.GetName() == namePointSale)
                        {
                            activePoint = pointSale;
                            break;
                        }
                    }

                    if (activePoint != null)
                    {
                        bool hasActionCompleted = activePoint.DeleteSeller();

                        if (hasActionCompleted)
                        {
                            Console.WriteLine("Действие выполнено!");
                        }
                        else
                        {
                            Console.WriteLine("На данной точке нет зарегистрированных продавцов!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Такой торговой точки нет! Действие отменено!");
                }
            }
            else
            {
                Console.WriteLine("Такой ярмарки нет! Действие отменено!");
            }
        }

        public static void ShowAll(List<Fair> fairs)
        {
            foreach (Fair fair in fairs)
            {
                Console.WriteLine($"--- {fair.GetName()} ---");

                if (fair.GetPoints().Count > 0)
                {
                    foreach (PointSale pointSale in fair.GetPoints())
                    {
                        Console.WriteLine($"Торговая точка: {pointSale.GetName()}");

                        pointSale.GetSeller()
                    }
                }
                else
                {
                    Console.WriteLine("Нет зарегистрированных торговых точек!");
                }
            }
        }

        public static string RequestNameFair()
        {
            Console.Write("Введите название ярмарки: ");
            string name = Console.ReadLine()?.Trim();

            return name;
        }

        public static string RequestNamePointSale()
        {
            Console.Write("Введите название ярмарки: ");
            string name = Console.ReadLine()?.Trim();

            return name;
        }

        public static string RequestNameSeller()
        {
            Console.Write("Введите название ярмарки: ");
            string name = Console.ReadLine()?.Trim();

            return name;
        }
    }
}