using System;

namespace Newbe.Test.TestHelpers
{
    public interface ITestServiceBuilder<in TService, out TInterface> where TService : TInterface
    {
        ITestActionHelper<TInterface> Build();
        ITestActionHelper<TInterface> Build(Func<TService> serviceFactory);
    }
}