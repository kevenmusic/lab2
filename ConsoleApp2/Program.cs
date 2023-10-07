using System;
using ClassLibrary3;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            Console.Write("Введите количество изделий: ");
            int count = Convert.ToInt32(Console.ReadLine());

            Product[] products = new Product[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите данные для изделия {i + 1}:");

                Console.Write("Название: ");
                string name = Console.ReadLine();

                Console.Write("Цена за единицу: ");
                decimal unitPrice = Convert.ToDecimal(Console.ReadLine());

                if (unitPrice <= 0)
                {
                    throw new ArgumentException("Общая стоимость не может быть отрицательной.");
                }

                Console.Write("Количество: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                if (quantity <= 0)
                {
                    throw new ArgumentException("Количество не может быть отрицательным значением.");
                }

                products[i] = new Product(name, unitPrice, quantity);
            }

            while (!exit)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Поиск суммы");
                Console.WriteLine("2. Произведение на число");
                Console.WriteLine("3. Вывести данные об изделиях");
                Console.WriteLine("4. Выход");
                Console.WriteLine("------------------------");
                Console.Write("Введите номер операции: ");
                int operation = Convert.ToInt32(Console.ReadLine());

                switch (operation)
                {
                    case 1:
                        try
                        {
                            Product sumProduct = SumProducts(products);
                            Console.WriteLine($"Результат сложения:");
                            Console.WriteLine($"Имя: {sumProduct.Name}");
                            Console.WriteLine($"Стоимость единицы изделия: {sumProduct.UnitPrice}");
                            Console.WriteLine($"Количество произведенных единиц изделия: {sumProduct.Quantity}");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                        break;

                    case 2:
                        Console.Write("Введите множитель: ");
                        int multiplier = Convert.ToInt32(Console.ReadLine());

                        MultiplyProducts(products, multiplier);
                        break;

                    case 3:
                        ShowProductData(products);
                        break;

                    case 4:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Неверный номер операции.");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Программа завершена.");
            Console.ReadLine();
        }

        static Product SumProducts(Product[] products)
        {
            if (products.Length == 0)
            {
                throw new ArgumentException("Нет изделий для сложения.");
            }

            Product sumProduct = products[0];

            for (int i = 1; i < products.Length; i++)
            {
                sumProduct += products[i];
            }

            return sumProduct;
        }

        static void MultiplyProducts(Product[] products, int multiplier)
        {
            if (products.Length == 0)
            {
                Console.WriteLine("Нет изделий для умножения.");
                return;
            }

            for (int i = 0; i < products.Length; i++)
            {
                Product multipliedProduct = products[i] * multiplier;
                Console.WriteLine(" ");
                Console.WriteLine($"Результат умножения на число для изделия {i + 1}:");
                Console.WriteLine($"Имя: {multipliedProduct.Name}");
                Console.WriteLine($"Стоимость единицы изделия: {multipliedProduct.UnitPrice}");
                Console.WriteLine($"Количество произведенных единиц изделия: {multipliedProduct.Quantity}");
            }
        }

        static void ShowProductData(Product[] products)
        {
            Console.WriteLine("Данные об изделиях:");
            Console.WriteLine("------------------------");

            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine($"Изделие {i + 1}:");
                Console.WriteLine($"Название: {products[i].Name}");
                Console.WriteLine($"Цена за единицу: {products[i].UnitPrice}");
                Console.WriteLine($"Количество: {products[i].Quantity}");
                Console.WriteLine("------------------------");
            }
        }
    }
}