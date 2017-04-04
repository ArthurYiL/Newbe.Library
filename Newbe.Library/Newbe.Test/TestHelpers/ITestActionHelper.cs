using System;

namespace Newbe.Test.TestHelpers
{
    public interface ITestActionHelper<out TInterface>
    {
        ITestAssertion<TInterface> DoAction(Action<TInterface> doAction);

        ITestAssertion<TInterface, TResult> DoAction<TResult>(Func<TInterface, TResult> doAction);
    }
}