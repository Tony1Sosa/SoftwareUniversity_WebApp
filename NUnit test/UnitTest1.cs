using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace NUnit_test
{
    public class Tests
    {
        [SetUp]
        public async Task Setup()
        {
            dbContext = new DbContext();

            var serviceCollection = new ServiceCollection();

            //add all dependancies in the ctor that we test
            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IApplicationDbRepository, ApplicationDbRepository>()
                .AddSingleton<IUserService, UserService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IApplicationDbRepository>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}