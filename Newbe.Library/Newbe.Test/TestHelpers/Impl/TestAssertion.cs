using System;

namespace Newbe.Test.TestHelpers.Impl
{
    internal class TestAssertion : ITestAssertion
    {
        private readonly Action _doAction;

        public TestAssertion(Action doAction)
        {
            _doAction = doAction;
        }

        void ITestAssertion.Assert(Action assertAction)
        {
            _doAction();
            assertAction();
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