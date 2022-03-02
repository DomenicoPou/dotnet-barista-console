using dotnet_barista_console.Handlers;
using dotnet_barista_console.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace dotnet_barista_unittest
{
    [TestClass]
    public class MenuHandlerTest
    {
        public MenuHandler menuHandler = new MenuHandler();

        /// <summary>
        /// Test a succesull value
        /// </summary>
        public const float expected = 3.5f;
        [TestMethod]
        public void TestReadSuccess()
        {
            Order fakeOrder = new Order()
            {
                user = "faker",
                drink = "flat white",
                size = "small"
            };

            float amount = menuHandler.ObtainPrice(fakeOrder);

            Assert.AreEqual(amount, expected);
        }

        /// <summary>
        /// Test when a drink doesn't exist
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Unkown drink was ordered: TestingFizz")]
        public void TestOrderDrinkNotExist()
        {
            Order fakeOrder = new Order()
            {
                user = "faker",
                drink = "TestingFizz",
                size = "small"
            };
            float amount =menuHandler.ObtainPrice(fakeOrder);
        }

        /// <summary>
        /// Test when a size doesn't exist
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Unkown drink was ordered: TestingFizz")]
        public void TestOrderDrinkSizeNotExist()
        {
            Order fakeOrder = new Order()
            {
                user = "faker",
                drink = "short espresso",
                size = "large"
            };
            float amount = menuHandler.ObtainPrice(fakeOrder);
        }
    }
}
