using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace GreetingApp.Tests
{
    /*public class FakeTimeServiceForDay : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2013,9,6,9,0,0);
        }
    }

    public class FakeTimeServiceForNight : ITimeService
    {
        public DateTime GetCurrentTime()
        {
            return new DateTime(2013, 9, 6, 21, 0, 0);
        }
    }*/

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void When_Greeted_During_Day_Good_Day_Is_Displayed()
        {
            //Arrange
            var mockFactory = new Moq.Mock<ITimeService>();
            mockFactory.Setup(ts => ts.GetCurrentTime()).Returns(new DateTime(2013, 9, 6, 9, 0, 0));
            var timeService = mockFactory.Object;
            var greeter = new Greeter(timeService);
            var userName = "Magesh";

            //Act
            var greetMsg = greeter.Greet(userName);

            //Assert
            Assert.IsTrue(greetMsg.Equals("Good Day Magesh"));
        }

        [TestMethod]
        public void When_Greeted_During_Night_Good_Night_Is_Displayed()
        {
            //Arrange
            var mockFactory = new Moq.Mock<ITimeService>();
            mockFactory.Setup(ts => ts.GetCurrentTime()).Returns(new DateTime(2013, 9, 6, 21, 0, 0));
            var timeService = mockFactory.Object;
            var greeter = new Greeter(timeService);
            var userName = "Magesh";

            //Act
            var greetMsg = greeter.Greet(userName);

            //Assert
            Assert.IsTrue(greetMsg.Equals("Good Night Magesh"));
        }
    }
}
