using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// new references
using System.Web.Mvc;
using TheIcecreamParlour.Controllers;
using Moq;
using TheIcecreamParlour.Models;
using System.Linq;
using System.Collections.Generic;

namespace TheIcecreamParlour.Tests.Controllers
{

    [TestClass]
    public class IcecreamsControllerTest
    {
        // moq data 
        icecreamsController controller;
        List<icecream> icecreams;
        Mock<IMockIcecreams> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            icecreams = new List<icecream>
            {
                new icecream  { FlavourID = 100, Flavour = "Sample Flavour A", Calories = 111, Dairy_Free = false, Gluten_Free = false},
                new icecream  { FlavourID = 101, Flavour = "Sample Flavour B", Calories = 222, Dairy_Free = false, Gluten_Free = false},
                new icecream  { FlavourID = 102, Flavour = "Sample Flavour C", Calories = 333, Dairy_Free = false, Gluten_Free = false}
            };

            mock = new Mock<IMockIcecreams>();
            mock.Setup(i => i.icecreams).Returns(icecreams.AsQueryable());

            controller = new icecreamsController(mock.Object);
        }

    // Index
        [TestMethod]
        public void IndexViewLoads()
        {
            // Arrange
            // handled in TestInitialize

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);

        }

    // Details GET
        [TestMethod]
        public void DetailsIdIsNull()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            HttpStatusCodeResult result = controller.Details(null) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public void DetailsIcecreamNotFound()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            HttpNotFoundResult result = controller.Details(500) as HttpNotFoundResult;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void DetailsViewIcecream()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            var result = ((ViewResult)controller.Details(101)).Model;
            
            // Assert
            Assert.AreEqual(icecreams.SingleOrDefault(i => i.FlavourID == 101), result);
        }

        [TestMethod]
        public void DetailsViewLoads()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            ViewResult result = controller.Details(101) as ViewResult;

            // Assert
            Assert.AreEqual("Details", result.ViewName);
        }

    // Create GET
        [TestMethod]
        public void CreateViewLoads()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

    // Create POST
        [TestMethod]
        public void CreatePostRedirectView()
        {
            icecream icecream = new icecream { FlavourID = 111, Flavour = "Flavour 111", Calories = 222, Dairy_Free = false, Gluten_Free = false };
           
            // Arrange 
            // handled in TestInitialize

            // Act
            RedirectToRouteResult result = controller.Create(icecream) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void CreatePostViewLoads()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.AreEqual("Create", result.ViewName);
        }

    // Edit GET
        [TestMethod]
        public void EditIdIsNull()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            HttpStatusCodeResult result = controller.Edit(111) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void EditIcecreamNotFound()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            HttpNotFoundResult result = controller.Edit(500) as HttpNotFoundResult;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void EditViewIcecream()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            var result = ((ViewResult)controller.Edit(101)).Model;

            // Assert
            Assert.AreEqual(icecreams.SingleOrDefault(i => i.FlavourID == 101), result);
        }

        [TestMethod]
        public void EditViewLoads()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            ViewResult result = controller.Edit(101) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

    // Edit POST
        [TestMethod]
        public void EditPostRedirectView()
        {
            icecream icecream = new icecream { FlavourID = 111, Flavour = "Flavour 111", Calories = 222, Dairy_Free = false, Gluten_Free = false };

            // Arrange 
            // handled in TestInitialize

            // Act
            RedirectToRouteResult result = controller.Edit(icecream) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void EditPostViewLoads()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            ViewResult result = controller.Edit(101) as ViewResult;

            // Assert
            Assert.AreEqual("Edit", result.ViewName);
        }

    // Delete GET
        [TestMethod]
        public void DeleteIdIsNull()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            HttpStatusCodeResult result = controller.Delete(111) as HttpStatusCodeResult;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void DeleteIcecreamNotFound()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            HttpNotFoundResult result = controller.Delete(500) as HttpNotFoundResult;

            // Assert
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void DeleteViewIcecream()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            var result = ((ViewResult)controller.Delete(101)).Model;

            // Assert
            Assert.AreEqual(icecreams.SingleOrDefault(i => i.FlavourID == 101), result);
        }

        [TestMethod]
        public void DeleteViewLoads()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            ViewResult result = controller.Delete(101) as ViewResult;

            // Assert
            Assert.AreEqual("Delete", result.ViewName);
        }

    // Delete Confirmed POST
    [TestMethod]
    public void DeleteConfirmedValidIdCheck()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            var result = ((ViewResult)controller.Delete(101)).Model;
            
            // Assert
            Assert.AreEqual(icecreams.SingleOrDefault(i => i.FlavourID == 101), result);
        }

        [TestMethod]
        public void DeleteConfirmedInValidIdCheck()
        {
            // Arrange 
            // handled in TestInitialize

            // Act
            RedirectToRouteResult result = controller.DeleteConfirmed(999) as RedirectToRouteResult;
            var resultlist = result.RouteValues.ToArray();
           
            // Assert

            Assert.AreEqual("Index", resultlist[0].Value);
        }
    }
}
