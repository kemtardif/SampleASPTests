using System;
using SimpleApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.Models;
using Xunit;
using Moq;
using System.Collections.Generic;

namespace SimpleApp.Tests
{
    public class HomeControllerTests
    {

        [Fact]
        public void IndexActionModelIsComplete()
        {
            //Arrange
            Product[] testData = new Product[] {
                 new Product { Name = "Kayak", Price = 275M },
                 new Product { Name = "Lifejacket", Price = 48.95M}
                 };
            var mock = new Mock<IDataSource>();

            var controller = new HomeController();
            mock.SetupGet(m => m.Products).Returns(testData);
            controller.dataSource = mock.Object;

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model
                as IEnumerable<Product>;

            // Assert
            Assert.Equal(testData, model,
                Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name
                    && p1.Price == p2.Price));
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}
