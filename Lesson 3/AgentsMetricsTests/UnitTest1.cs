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
            // устанавливаем параметр заглушки
            // в заглушке прописываем что в репозиторий прилетит CpuMetric объект
            mock.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();

            // выполняем действие на контроллере
            var result = controller.Create(new MetricsAgent.Requests.CpuMetricCreateRequest { Time = DateTime.Now, Value = 50 });

            // проверяем заглушку на то, что пока работал контроллер
            // действительно вызвался метод Create репозитория с нужным типом объекта в параметре
            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
    }

}
