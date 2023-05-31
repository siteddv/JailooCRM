using JailooCRM.BLL;
using JailooCRM.Controllers;
using JailooCRM.DAL;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace JailooCRM.Tests1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task APlusB()
        {
            PgContext pgContext = new PgContext();
            IRepository<Department, int> repository = new Repository<Department, int>(pgContext);
            DepartmentService service = new DepartmentService(repository);
            var serviceProvider = new Mock<IServiceProvider>();

            var serviceScope = new Mock<IServiceScope>();
            serviceScope.Setup(x => x.ServiceProvider).Returns(serviceProvider.Object);

            var serviceScopeFactory = new Mock<IServiceScopeFactory>();
            serviceScopeFactory
            .Setup(x => x.CreateScope())
                .Returns(serviceScope.Object);

            serviceProvider
                .Setup(x => x.GetService(typeof(IServiceScopeFactory)))
                .Returns(serviceScopeFactory.Object);
            DbLoggerProvider provider = new DbLoggerProvider(null, serviceScopeFactory.Object);
            ILogger<DepartmentController> logger = new DbLogger<DepartmentController>(provider, serviceScopeFactory.Object);
            DepartmentController controller = new DepartmentController(repository, service, logger);
            // AAA

            // Arrange
            var a = (await controller.Search(null)).Departments;

            // Assert
            Assert.NotZero(a.Count);
        }
    }
}