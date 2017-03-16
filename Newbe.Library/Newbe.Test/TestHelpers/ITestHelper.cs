using System;
using Autofac.Extras.Moq;

namespace Newbe.Test.TestHelpers
{
    public interface ITestHelper
    {
        ITestHelper Setup(Action<AutoMock> setupAction);
        ITestHelper Setup();

        ITestServiceBuilder<TService, TInterface> GetServiceBuilder<TService, TInterface>()
            where TService : TInterface;
    }
}