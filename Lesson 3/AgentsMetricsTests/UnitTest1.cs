using MetricsAgent.Controllers;
using MetricsAgent.Models;
using Moq;
using System;
using MetricsAgent;
using MetricsAgent.Interface;
using Microsoft.Extensions.Logging;
using Xunit;

namespace MetricsAgentTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuController controller;
        private Mock<ICpuMetricsRepository> mock;
        private ILogger<CpuController> _logger;
        public CpuMetricsControllerUnitTests()
        {
            mock = new Mock<ICpuMetricsRepository>();

            controller = new CpuController(mock.Object,_logger);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� CpuMetric ������
            mock.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();

            // ��������� �������� �� �����������
            var result = controller.Create(new MetricsAgent.Requests.CpuMetricCreateRequest { Time = DateTime.Now, Value = 50 });

            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
    }

}
