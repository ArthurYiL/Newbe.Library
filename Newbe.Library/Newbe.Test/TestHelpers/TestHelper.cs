using System;
using Autofac.Extras.Moq;
using Newbe.Test.TestHelpers.Impl;

namespace Newbe.Test.TestHelpers
{
    public class TestHelper : ITestHelper
    {
        private readonly AutoMock _mock;

        public TestHelper()
        {
            _mock = AutoMock.GetStrict();
        }

        ITestServiceBuilder<TService, TInterface> ITestHelper.GetServiceBuilder<TService, TInterface>()
        {
            return new TestServiceBuilder<TService, TInterface>(_mock);
        }

        ITestHelper ITestHelper.Setup(Action<AutoMock> setupAction)
        {
            setupAction(_mock);
            return this;
        }

        ITestHelper ITestHelper.Setup()
        {
            return this;
        }

        public static ITestHelper Test()
        {
            return new TestHelper();
        }
    }
}