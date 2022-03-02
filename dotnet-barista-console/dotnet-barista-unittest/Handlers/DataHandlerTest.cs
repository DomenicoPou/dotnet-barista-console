using dotnet_barista_console.Handlers;
using dotnet_barista_console.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace dotnet_barista_unittest
{
    [TestClass]
    public class DataHandlerTest
    {
        /// <summary>
        /// Test all successfui reads
        /// </summary>
        [TestMethod]
        public void TestReadSuccess()
        {
            List<Order> orders = DataHandler.ReadConfig<List<Order>>("orders");
            Assert.IsNotNull(orders);

            List<Payment> Payments = DataHandler.ReadConfig<List<Payment>>("payments");
            Assert.IsNotNull(Payments);


            List<MenuItem> MenuItems = DataHandler.ReadConfig<List<MenuItem>>("prices");
            Assert.IsNotNull(MenuItems);
        }

        /// <summary>
        /// Test when a filename is null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Filename is null or empty.")]
        public void TestReadNull()
        {
            List<Order> orders = DataHandler.ReadConfig<List<Order>>(null);
        }

        /// <summary>
        /// Test when a filename doesn't exist
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "File 'nopenopenope' doesn't exists.")]
        public void TestReadDoesntExist()
        {
            List<Order> orders = DataHandler.ReadConfig<List<Order>>("nopenopenope");
        }
    }
}
