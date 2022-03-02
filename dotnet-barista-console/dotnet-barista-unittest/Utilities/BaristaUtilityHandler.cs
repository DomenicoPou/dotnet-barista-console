using dotnet_barista_console.Models;
using dotnet_barista_console.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;


namespace dotnet_barista_unittest.Utilities
{
    [TestClass]
    public class BaristaUtilityHandler
    {
        /// <summary>
        /// Test a succesull response from the barista utility.
        /// </summary>
        [TestMethod]
        public void TestReadSuccess()
        {
            BaristaUtilities baristaUtilities = new BaristaUtilities();
            List<BaristaResponse> Result = baristaUtilities.ObtainBaristaTotals();
            Assert.IsNotNull(Result);
        }
    }
}
