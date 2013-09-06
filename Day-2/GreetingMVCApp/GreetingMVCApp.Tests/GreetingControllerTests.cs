using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreetingMVCApp;

namespace GreetingMVCAppTests
{
    [TestClass]
    public class GreetingControllerTests
    {
        [TestMethod]
        public void When_Greeted_During_Day_GreetDayView_Is_Returned()
        {
            //Arrange
            var mockFactory = new Moq.Mock<ITimeService>();
            mockFactory.Setup(ts => ts.GetCurrentTime()).Returns(new DateTime(2013, 9, 6, 9, 0, 0));
            var timeService = mockFactory.Object;
            var testFirstName = "Magesh";
            var testLastName = "K";
            var controller = new GreetingController(timeService);

            //Act
            var result = controller.Greet(testFirstName,testLastName);

            //Assert
            Assert.AreEqual("GreetDayView",result.ViewName);
            Assert.AreEqual("Good Day " + testLastName + ", " + testFirstName,result.ViewData["greetMsg"]);
        }

        [TestMethod]
        public void When_Greeted_During_Night_GreetNightView_Is_Returned()
        {
            //Arrange
            var mockFactory = new Moq.Mock<ITimeService>();
            mockFactory.Setup(ts => ts.GetCurrentTime()).Returns(new DateTime(2013, 9, 6, 21, 0, 0));
            var timeService = mockFactory.Object;
            var testFirstName = "Magesh";
            var testLastName = "K";
            var controller = new GreetingController(timeService);

            //Act
            var result = controller.Greet(testFirstName, testLastName);

            //Assert
            Assert.AreEqual("GreetNightView", result.ViewName);
            Assert.AreEqual("Good Night " + testLastName + ", " + testFirstName, result.ViewData["greetMsg"]);
        }
    }
}
