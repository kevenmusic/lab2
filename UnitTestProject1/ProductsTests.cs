using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary3;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class ProductsTests
    {
        [TestMethod]
        public void AddOperator_ProductsWithSameName_ReturnsCombinedProduct()
        {
            // Arrange
            var p1 = new Product("Product A", 10.0m, 3);
            var p2 = new Product("Product A", 15.0m, 2);

            // Act
            var result = p1 + p2;

            // Assert
            Assert.AreEqual("Product A", result.Name);
            Assert.AreEqual(12.0m, result.UnitPrice);
            Assert.AreEqual(5, result.Quantity);
        }


        [TestMethod]
        public void AddOperator_ProductsWithDifferentNames_ThrowsArgumentException()
        {
            // Arrange
            var p1 = new Product("Product A", 10.0m, 3);
            var p2 = new Product("Product B", 15.0m, 2);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => p1 + p2);
        }

        [TestMethod]
        public void MultiplyOperator_PositiveMultiplier_ReturnsMultipliedProduct()
        {
            // Arrange
            var p = new Product("Product A", 10.0m, 3);
            int multiplier = 2;

            // Act
            var result = p * multiplier;

            // Assert
            Assert.AreEqual("Product A", result.Name);
            Assert.AreEqual(10.0m, result.UnitPrice);
            Assert.AreEqual(6, result.Quantity);
        }

        [TestMethod]
        public void MultiplyOperator_ZeroMultiplier_ReturnsProductWithZeroPriceAndQuantity()
        {
            // Arrange
            var p = new Product("Product A", 10.0m, 3);
            int multiplier = 0;

            // Act
            var result = p * multiplier;

            // Assert
            Assert.AreEqual("Product A", result.Name);
            Assert.AreEqual(0.0m, result.UnitPrice);
            Assert.AreEqual(0, result.Quantity);
        }
        
        [TestMethod]
        public void MultiplyOperator_NegativeMultiplier_ThrowsException()
        {
            // Arrange
            var p = new Product("Product A", 10.0m, 3);
            int multiplier = -2;

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => p * multiplier);
        }

        [TestMethod]
        public void AddOperator_ProductsWithZeroQuantity_ReturnsCombinedProductWithZeroQuantity()
        {
            // Arrange
            var p1 = new Product("Product A", 10.0m, 0);
            var p2 = new Product("Product A", 15.0m, 0);

            // Act
            var result = p1 + p2;

            // Assert
            Assert.AreEqual("Product A", result.Name);
            Assert.AreEqual(0.0m, result.UnitPrice);
            Assert.AreEqual(0, result.Quantity);
        }

        [TestMethod]
        public void AddOperator_ProductsWithNegativeQuantity_ReturnsCombinedProductWithNegativeQuantity()
        {
            // Arrange
            var p1 = new Product("Product A", 10.0m, -3);
            var p2 = new Product("Product A", 15.0m, -2);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => p1 + p2);
        }

        [TestMethod]
        public void AddOperator_ProductsWithNegativeQuantity_ThrowsException()
        {
            // Arrange
            var p1 = new Product("Product A", 10.0m, -3);
            var p2 = new Product("Product A", 15.0m, 2); // Второй продукт с положительным количеством

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => p1 + p2);
        }

        [TestMethod]
        public void Addition_OneProductWithZeroQuantity_ReturnsOtherProduct()
        {
            // Arrange
            var p1 = new Product("Product A", 10, 0);
            var p2 = new Product("Product A", 15, 3);

            // Act
            var result = p1 + p2;

            // Assert
            Assert.AreEqual("Product A", result.Name);
            Assert.AreEqual(15, result.UnitPrice);
            Assert.AreEqual(3, result.Quantity);
        }
        [TestMethod]
        public void Multiplication_WithNegativeMultiplierAndZeroQuantity_ReturnsNewProductWithZeroUnitPrice()
        {
            // Arrange
            var p = new Product("Product 1", 0, 0);
            int multiplier = -2;

            // Act
            var result = p * multiplier;

            // Assert
            Assert.AreEqual("Product 1", result.Name);
            Assert.AreEqual(0, result.Quantity);
            Assert.AreEqual(0, result.UnitPrice);
        }
    }
}
