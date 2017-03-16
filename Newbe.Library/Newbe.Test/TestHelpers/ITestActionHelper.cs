using System;

namespace Newbe.Test.TestHelpers
{
    public interface ITestActionHelper<out TInterface>
    {
        ITestAssertion DoAction(Action<TInterface> doAction);

        ITestAssertion<TResult> DoAction<TResult>(Func<TInterface, TResult> doAction);
    }
}