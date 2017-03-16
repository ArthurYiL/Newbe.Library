using System;

namespace Newbe.Test.TestHelpers.Impl
{
    internal class TestAssertion<TResult> : ITestAssertion<TResult>
    {
        private readonly Func<TResult> _doAction;

        public TestAssertion(Func<TResult> doAction)
        {
            _doAction = doAction;
        }

        void ITestAssertion<TResult>.Assert(Action<TResult> assertAction)
        {
            var result = _doAction();
            assertAction(result);
        }

        void IExceptionAssertion.Throw<TException>()
        {
            try
            {
                _doAction();
            }
            catch (TException)
            {
                // catch is ok!
            }
        }

        void IExceptionAssertion.Throw<TException>(Action<TException> exceptionAssertion)
        {
            try
            {
                _doAction();
            }
            catch (TException exception)
            {
                exceptionAssertion(exception);
            }
        }
    }
}