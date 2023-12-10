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
            
            while (count > 2)
            {
                Console.Clear();

                Console.WriteLine("Неверное количество изделий. Должно быть до двух");

                Console.Write("Введите количество изделий: ");
                count = Convert.ToInt32(Console.ReadLine());
            }

            Product[] products = new Product[count];

            while (!exit)
            {
                Console.Clear();

                Console.WriteLine("|--------------------------------------|");
                Console.WriteLine("|           Выберите операцию:         |");
                Console.WriteLine("|            1. Поиск суммы            |");
                Console.WriteLine("|       2. Произведение на число       |");
                Console.WriteLine("|           3. Вывод данных            |");
                Console.WriteLine("|            4. Ввод данных            |");
                Console.WriteLine("|               5. Выход               |");
                Console.WriteLine("|--------------------------------------|");
                Console.Write("Введите номер операции: ");
                int operation;

                try
                {
                    operation = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Нажмите Enter для продолжения...");
                    Console.ReadLine();
                    continue;
                }

                switch (operation)
                {
                    case 1:
                        try
                        {   
                            Product sumProduct = SumProducts(products);
                            ShowProductData(products);
                            Console.WriteLine();
                            Console.WriteLine("|--------------------------------------------------|");
                            Console.WriteLine($"| Результат сложения                               |");
                            Console.WriteLine($"| Имя: {sumProduct.Name, -43} |");
                            Console.WriteLine($"| Стоимость единицы изделия: {sumProduct.UnitPrice, -21} |");
                            Console.WriteLine($"| Количество произведенных единиц изделия: {sumProduct.Quantity, -7} |");
                            Console.WriteLine("|--------------------------------------------------|");

                        }
                        catch (ProductException ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}. Дополнительная информация: {ex.Value}.");
                        }

                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        try
                        {
                            Console.Write("Введите множитель: ");
                            int multiplier = Convert.ToInt32(Console.ReadLine());
                            
                            MultiplyProducts(products, multiplier);
                            Console.WriteLine();
                            ShowProductData(products);

                        }
                        catch (ProductException ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}. Дополнительная информация: {ex.Value}.");
                        }

                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        try
                        {
                            ShowProductData(products);
                        }
                        catch (ProductException ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }

                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4:
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"Введите данные для изделия {i + 1}:");

                            Console.Write("Название: ");
                            string name = Console.ReadLine();

                            Console.Write("Цена за единицу: ");
                            float unitPrice = Convert.ToSingle(Console.ReadLine());

                            Console.Write("Количество: ");
                            int quantity = Convert.ToInt32(Console.ReadLine());
                            products[i] = new Product(name, unitPrice, quantity);
                        }

                        Console.WriteLine("Данные введены успешно.");
                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 5:
                        return;

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
            if (products.Length < 2)
            {
                throw new ProductException("Можно складывать только два продукта.");
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
                throw new ProductException("Нет изделий для умножения.");
            }

            for (int i = 0; i < products.Length; i++)
            {
                Product multipliedProduct = products[i] * multiplier;
                Console.WriteLine("|--------------------------------------------------|");
                Console.WriteLine($"| Результат умножения на число для изделия {i + 1, -7} |");
                Console.WriteLine($"| Название: {multipliedProduct.Name, -38} |");
                Console.WriteLine($"| Стоимость единицы изделия: {multipliedProduct.UnitPrice, -21} |");
                Console.WriteLine($"| Количество произведенных единиц изделия: {multipliedProduct.Quantity,-7} |");
                Console.WriteLine("|--------------------------------------------------|");
            }
        }

        static void ShowProductData(Product[] products)
        {
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] == null)
                {
                    throw new ProductException("Вы не указали информацию об изделиях");
                }
                Console.WriteLine("|----------------------|");
                Console.WriteLine($"| Изделие {i + 1, -12} |");
                Console.WriteLine($"| Название: {products[i].Name, -10} |");
                Console.WriteLine($"| Цена за единицу: {products[i].UnitPrice, -3} |");
                Console.WriteLine($"| Количество: {products[i].Quantity,-8} |");
                Console.WriteLine("|----------------------|");
            }
        }
    }
}
