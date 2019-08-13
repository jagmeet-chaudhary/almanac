using System;
using Almanac.Service.Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Almanac.Service.Tests
{
    [TestClass]
    public class EventProcessorTests
    {
        [TestMethod]
        public void WhenEventDateIsMoreThan2DaysAway_ThenDontSelectTheEvent()
        {
            
            var eventProcessorMock = new Mock<IEventsProcessor>();
            eventProcessorMock.Object.ProcessEvents();
        }
    }
}
