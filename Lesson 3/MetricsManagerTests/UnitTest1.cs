using global::System;
using global::MetricsManager.Controllers;
using global::Microsoft.AspNetCore.Mvc;
using global::Microsoft.Extensions.Logging;
using global::Xunit;
using Moq;

namespace MetricsManagerTests
{
    public class MetricsManagerTests
    {
        private MetricsController controller;
        private Mock<ILogger<MetricsController>> mock;

        public MetricsManagerTests()
        {
            mock = new Mock<ILogger<MetricsController>> ();

            controller = new MetricsController(mock.Object);
        }

        [Fact]
        public void GetMetricsFromAgentCPU_returnsOK()
        {
 
            var id = 1;
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddDays(2);
            var result = controller.GetMetricsFromAgentCPU(id, fromTime, toTime);
            _ = Assert.IsAssignableFrom<global::Microsoft.AspNetCore.Mvc.IActionResult>(result);
        }
    }
}
