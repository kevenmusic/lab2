using System;

namespace ClassLibrary3
{
    public class ProductExceptions
    {
        public static void ThrowProductNameMismatchException()
        {
            throw new ArgumentException("Невозможно добавить товары с разными названиями.");
        }

        public static void ThrowNegativeQuantityException()
        {
            throw new InvalidOperationException("Количество не может быть отрицательным.");
        }

        public static void ThrowInvalidOperationForMoreThanTwoProductsException()
        {
            throw new InvalidOperationException("Можно складывать только два продукта.");
        }

        public static void ThrowNegativeTotalPriceException()
        {
            throw new ArgumentException("Общая стоимость не может быть отрицательной.");
        }

        public static void ThrowNegativeTotalQuantityException()
        {
            throw new InvalidOperationException("Общее количество не может быть отрицательным.");
        }

        public static void ThrowNegativeMultiplierException()
        {
            throw new ArgumentException("Множитель не может быть отрицательным или равен 0.");
        }
        
        public static void ThrowNoProductsForMultiplication()
        {
            throw new ArgumentException("Нет изделий для умножения.");
        }

        public static void NullObject()
        {
            throw new NullReferenceException("Вы не указали информацию об изделиях");
        }
    }
}
