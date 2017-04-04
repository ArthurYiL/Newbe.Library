using System;

namespace Newbe.Test.TestHelpers
{
    public interface ITestAssertion<out TService> : IExceptionAssertion
    {
        void Assert(Action assertAction);
        void Assert(Action<TService> assertAction);
    }

    public interface ITestAssertion<out TService, out TResult> : IExceptionAssertion
    {
        void Assert(Action<TResult> assertAction);
        void Assert(Action<TResult, TService> assertAction);
    }
}