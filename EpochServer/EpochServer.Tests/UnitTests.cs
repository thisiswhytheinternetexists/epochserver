using System;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;
using EpochServer.ServiceModel;
using EpochServer.ServiceInterface;

namespace EpochServer.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private readonly ServiceStackHost appHost;

        public UnitTests()
        {
            appHost = new BasicAppHost(typeof(EpochService).Assembly)
            {
                ConfigureContainer = container =>
                {
                    //Add your IoC dependencies here
                }
            }
            .Init();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            appHost.Dispose();
        }

        [Test]
        public void TestMethod1()
        {
            var service = appHost.Container.Resolve<EpochService>();

            var response = service.Get(new EpochRequest());

            Assert.That(response, Is.InRange(1457880646, 1507880646));
        }
    }
}
