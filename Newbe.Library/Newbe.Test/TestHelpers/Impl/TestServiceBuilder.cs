using System;
using Autofac.Extras.Moq;

namespace Newbe.Test.TestHelpers.Impl
{
    internal class TestServiceBuilder<TService, TInterface> : ITestServiceBuilder<TService, TInterface>
        where TService : TInterface
    {
        private readonly AutoMock _mock;

        public TestServiceBuilder(AutoMock mock)
        {
            _mock = mock;
        }

        ITestActionHelper<TInterface> ITestServiceBuilder<TService, TInterface>.Build()
        {
            var service = _mock.Create<TService>();
            return new TestActionHelper<TInterface>(service);
        }

        ITestActionHelper<TInterface> ITestServiceBuilder<TService, TInterface>.Build(
            Func<TService> serviceFactory)
        {
            var service = serviceFactory();
            return new TestActionHelper<TInterface>(service);
        }
    }
}