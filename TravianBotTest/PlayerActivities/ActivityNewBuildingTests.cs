using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TravianBot;
using TravianBot.Enums;

namespace TravianBotTest
{
    [TestClass]
    public class ActivityNewBuildingTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = new ActivityNewBuilding(1, BuildingType.ACADEMY);

            var mock = new Mock<IClient>();
            mock.Setup(m => m.Send(Page.LOGIN, null, null)).Throws(new ArgumentOutOfRangeException());

            a.ActWith(mock.Object).Wait();
        }
    }
}