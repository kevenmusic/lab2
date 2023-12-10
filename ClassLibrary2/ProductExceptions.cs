using System;

namespace ClassLibrary3
{
    public class ProductException : Exception
    {
        public object Value;

        public ProductException()
        {
        }

        public ProductException(string message): base(message)
        {
        }

        public ProductException(string message, object value1, object value2) : base(message)
        {
            Value = new { Значение1 = value1, Значение2 = value2 };
        }

        public ProductException(string message, object value) : base(message)
        {
            Value = new { Значение = value};
        }
    }
}