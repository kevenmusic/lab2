using System;

namespace ClassLibrary3
{
    public class Product
    {
        /// <summary>
        /// Наименование изделия.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Стоимость единицы изделия.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Количество произведенных единиц изделия.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Конструктор класса Product.
        /// </summary>
        /// <param name="name">Наименование изделия.</param>
        /// <param name="unitPrice">Стоимость единицы изделия.</param>
        /// <param name="quantity">Количество произведенных единиц изделия.</param>
        public Product(string name, decimal unitPrice, int quantity)
        {
            Name = name;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        /// <summary>
        /// Перегрузка оператора сложения (+) для класса Product.
        /// </summary>
        /// <param name="p1">Первый объект Product.</param>
        /// <param name="p2">Второй объект Product.</param>
        /// <returns>Новый объект Product, являющийся результатом сложения двух объектов.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если имена продуктов различаются.</exception>
        public static Product operator +(Product p1, Product p2)
        {
            // Проверяем, имеют ли товары одинаковое название
            if (p1.Name != p2.Name)
            {
                throw new ArgumentException("Невозможно добавить товары с разными названиями.");
            }

            // Проверяем, если количество отрицательное, выбрасываем исключение
            if (p1.Quantity < 0 || p2.Quantity < 0)
            {
                throw new InvalidOperationException("Количество единиц не может быть отрицательным.");
            }

            // Вычисляем общую стоимость для двух продуктов
            decimal totalPrice = (p1.UnitPrice * p1.Quantity) + (p2.UnitPrice * p2.Quantity);

            // Проверяем, если общая стоимость отрицательная, выбрасываем исключение
            if (totalPrice < 0)
            {
                throw new ArgumentException("Общая стоимость не может быть отрицательной.");
            }

            // Вычисляем общее количество
            int totalQuantity = p1.Quantity + p2.Quantity;

            decimal unitPrice;
            // Если общее количество равно нулю, устанавливаем цену за единицу в ноль
            if (totalQuantity == 0)
            {
                unitPrice = 0;
            }
            else
            {
                // Вычисляем цену за единицу
                unitPrice = totalPrice / totalQuantity;
            }

            // Создаем новый объект Product с обновленными значениями
            return new Product(p1.Name, unitPrice, totalQuantity);
        }

        /// <summary>
        /// Перегрузка оператора умножения (*) для класса Product.
        /// </summary>
        /// <param name="p">Объект Product.</param>
        /// <param name="multiplier">Множитель (целое число).</param>
        /// <returns>Новый объект Product, являющийся результатом умножения объекта на множитель.</returns>
        public static Product operator *(Product p, int multiplier)
        {
            int totalQuantity;
            decimal unitPrice;

            if (multiplier == 0 || p.Quantity == 0)
            {
                totalQuantity = 0;
                unitPrice = 0;
            }
            else if (multiplier > 0)
            {
                decimal totalPrice = p.UnitPrice * p.Quantity * multiplier;
                totalQuantity = p.Quantity * multiplier;

                // Проверяем, если общее количество отрицательное, выбрасываем исключение
                if (totalQuantity < 0)
                {
                    throw new InvalidOperationException("Общее количество не может быть отрицательным.");
                }

                // Вычисляем цену за единицу
                unitPrice = totalPrice / totalQuantity;
            }
            else
            {
                unitPrice = p.UnitPrice;
                totalQuantity = p.Quantity * multiplier;

                // Проверяем, если количество единиц отрицательное, выбрасываем исключение
                if (totalQuantity < 0)
                {
                    throw new InvalidOperationException("Общее количество не может быть отрицательным.");
                }
            }

            return new Product(p.Name, unitPrice, totalQuantity);
        }
    }
}
