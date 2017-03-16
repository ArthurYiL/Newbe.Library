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

        ITestAssertion ITestActionHelper<TInterface>.DoAction(Action<TInterface> doAction)
        {
            return new TestAssertion(() => doAction(_service));
        }

        ITestAssertion<TResult> ITestActionHelper<TInterface>.DoAction<TResult>(Func<TInterface, TResult> doAction)
        {
            return new TestAssertion<TResult>(() => doAction(_service));
        }
    }
}