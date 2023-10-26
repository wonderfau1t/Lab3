using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order_Class;
using System;

namespace Lab3.Tests
{
    [TestClass]
    public class OrderClassTests
    {
        [TestMethod]
        public void CalculateSum_CorrectCalculationWithoutPriority_ReturnsExpectedSum()
        {
            // Arrange
            float expectedSum = 1000.0f * (1.0f + 0.3f + 0.5f) * 2.0f;

            // Act
            Order order = new Order("Test", "Test", DateTime.Now, true, 0.3f, 0.5f);
            float actualSum = order.CalculateSum(0.3f, 0.5f, true);

            // Assert
            Assert.AreEqual(expectedSum, actualSum);

        }
        [TestMethod]
        public void Ready_StatusUpdated_ReturnsUpdatedStatus()
        {
            // Arrange
            Order order = new Order("Tablet", "Samsung", DateTime.Now, false, 0.15f, 0.25f);

            // Act
            order.Ready = true;

            // Assert
            Assert.IsTrue(order.Ready);
        }

        [TestMethod]
        public void RepairCost_ReturnsString()
        {
            // Arrange
            Order order = new Order("Tablet", "Samsung", DateTime.Now, false, 0.15f, 0.25f);

            // Act
            string actualCost = order.RepairCost;

            // Assert
            Assert.IsInstanceOfType(actualCost, typeof(string));
        }
    }
}
