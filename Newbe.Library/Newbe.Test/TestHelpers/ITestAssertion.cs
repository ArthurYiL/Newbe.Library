using System;

namespace Newbe.Test.TestHelpers
{
    public interface ITestAssertion : IExceptionAssertion
    {
        void Assert(Action assertAction);
    }
}