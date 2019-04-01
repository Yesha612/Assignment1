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

        [TestInitialize]
        public void TestInitialize()
        {
            icecreams = new List<icecream>
            {
                new icecream  { FlavourID = 100, Flavour = "Sample Flavour A"},
                new icecream  { FlavourID = 101, Flavour = "Sample Flavour B"},
                new icecream  { FlavourID = 102, Flavour = "Sample Flavour C"}
            };
        }

        [TestMethod]
        public void IndexViewLoads()
        {
            // Arrange
            icecreamsController controller = new icecreamsController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName); 

        }
    }
}
