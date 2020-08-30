using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wingtiptoys.client.Repository;
using Wingtiptoys.DB.Models;

namespace Wingtiptoys.client.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerProductTest
    {
        // Method to test the All Products will return a value
        // Only Postive Test
        [TestMethod()]
        public void IndexTestAllProducts()
        {

            // Arrange
            bool expectedProduct = true;
            int count = 0;
            ProductRepository productRepo = new ProductRepository();

            //Act
            count = productRepo.GetAll().ToList<Products>().Count();

            // Assert
            Assert.AreEqual(expectedProduct, (count > 0));
        }


        // Method to test the Product Search is working As Expected
        // Only Postive Test
        [TestMethod()]
        public void IndexTestFastCarSearch()
        {

            // Arrange
            string searchstring = "FAST CAR";
            bool expectedProduct = true;
            int count = 0;
            ProductRepository productRepo = new ProductRepository();

            //Act
            count = productRepo.GetProductsBySearch(searchstring).ToList<Products>().Count();

            // Assert
            Assert.AreEqual(expectedProduct, (count > 0));
        }
    }
}