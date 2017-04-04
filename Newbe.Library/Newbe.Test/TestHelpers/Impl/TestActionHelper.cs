using System;

namespace Newbe.Test.TestHelpers.Impl
{
    internal class TestActionHelper<TInterface> : ITestActionHelper<TInterface>
    {
        private readonly TInterface _service;

        public TestActionHelper(TInterface service)
        {
            _service = service;
        }

        ITestAssertion<TInterface> ITestActionHelper<TInterface>.DoAction(Action<TInterface> doAction)
        {
            return new TestAssertion<TInterface>(() => doAction(_service), _service);
        }

        ITestAssertion<TInterface, TResult> ITestActionHelper<TInterface>.DoAction<TResult>(
            Func<TInterface, TResult> doAction)
        {
            return new TestAssertion<TInterface, TResult>(() => doAction(_service), _service);
        }
    }
}