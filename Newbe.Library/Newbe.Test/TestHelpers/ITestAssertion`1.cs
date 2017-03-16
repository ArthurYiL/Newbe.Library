using System;

namespace Newbe.Test.TestHelpers
{
    public interface ITestAssertion<out TResult> : IExceptionAssertion
    {
        void Assert(Action<TResult> assertAction);
    }
}