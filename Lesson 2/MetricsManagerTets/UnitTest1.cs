using WebApplication1.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace MetricsManagerTests
{
    public class CpuMetricsControllerUnitTests
    {
        private MetricsController controller;

        public CpuMetricsControllerUnitTests()
        {
            controller = new MetricsController();
        }

        [Fact]
        public void GetMetricsFromAgentCPU_ReturnsOk()
        {
            //Arrange
            var agentId = 1;
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddDays(2);

            //Act
            var result = controller.GetMetricsFromAgentCPU(agentId, fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetMetricsFromAgentDotnet_ReturnsOK()
        {
            //Arrange
            var agentId = 1;
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddDays(2);

            //Act
            var result = controller.GetMetricsFromAgentDotnet(agentId, fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetMetricsFromAgentNetwork_ReturnsOK()
        {
            //Arrange
            var agentId = 1;
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddDays(2);

            //Act
            var result = controller.GetMetricsFromAgentNetwork(agentId, fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetMetricsFromAgentHDD_ReturnsOK()
        {
            //Arrange
            var agentId = 1;
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddDays(2);

            //Act
            var result = controller.GetMetricsFromAgentHDD(agentId, fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
        [Fact]
        public void GetMetricsFromAgentRAM_ReturnsOK()
        {
            //Arrange
            var agentId = 1;
            var fromTime = DateTime.Now;
            var toTime = DateTime.Now.AddDays(2);

            //Act
            var result = controller.GetMetricsFromAgentRAM(agentId, fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}