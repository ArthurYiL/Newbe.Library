// ReSharper disable once CheckNamespace

namespace Newbe.Test.TestHelpers
{
    public static class TestHelperExtensions
    {
        public static ITestServiceBuilder<TService, TService> GetServiceBuilder<TService>(this ITestHelper helper)
        {
            return helper.GetServiceBuilder<TService, TService>();
        }
    }
}