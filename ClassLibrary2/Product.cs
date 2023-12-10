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
        public double UnitPrice { get; set; }

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
        public Product(string name, double unitPrice, int quantity)
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
            if (p1 == null || p2 == null) 
            {
                throw new ProductException("Вы не указали информацию об изделиях.", p1, p2);
            }

            // Проверяем, имеют ли товары одинаковое название
            if (p1.Name != p2.Name)
            {
                throw new ProductException("Невозможно добавить товары с разными названиями.", p1.Name, p2.Name);
            }

            // Проверяем, если количество отрицательное, выбрасываем исключение
            if (p1.Quantity < 0 || p2.Quantity < 0)
            {
                throw new ProductException("Количество не может быть отрицательным.", p1.Quantity, p2.Quantity);
            }

            // Проверяем, если стоимость отрицательная, выбрасываем исключение
            if (p1.UnitPrice < 0 || p2.UnitPrice < 0)
            {
                throw new ProductException("Cтоимость не может быть отрицательной.", p1.UnitPrice, p2.UnitPrice);
            }
            // Вычисляем общую стоимость для двух продуктов
            double totalPrice = (p1.UnitPrice * p1.Quantity) + (p2.UnitPrice * p2.Quantity);

            // Вычисляем общее количество
            int totalQuantity = p1.Quantity + p2.Quantity;
            double unitPrice = totalPrice / totalQuantity;    

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
            double unitPrice;

            if (p == null)
            {
                throw new ProductException("Вы не указали информацию об изделиях.", p);
            }

            if (multiplier <= 0)
            {
                throw new ProductException("Множитель не может быть отрицательным или равен 0.", multiplier);
            }

            // Проверяем, если количество отрицательное, выбрасываем исключение
            if (p.Quantity < 0)
            {
                throw new ProductException("Количество не может быть отрицательным.", p.Quantity);
            }

            // Проверяем, если стоимость отрицательная, выбрасываем исключение
            if (p.UnitPrice < 0)
            {
                throw new ProductException("Cтоимость не может быть отрицательной.", p.UnitPrice);
            }
            
            double totalPrice = p.UnitPrice * p.Quantity * multiplier;
            totalQuantity = p.Quantity * multiplier;

            // Вычисляем цену за единицу
            unitPrice = totalPrice / totalQuantity;
            
            return new Product(p.Name, unitPrice, totalQuantity);
        }
    }
}
