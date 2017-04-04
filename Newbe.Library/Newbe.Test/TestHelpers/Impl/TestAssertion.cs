using System;

namespace Newbe.Test.TestHelpers.Impl
{
    internal class TestAssertion<TService> : ITestAssertion<TService>
    {
        private readonly Action _doAction;
        private readonly TService _service;

        public TestAssertion(Action doAction, TService service)
        {
            _doAction = doAction;
            _service = service;
        }

        void ITestAssertion<TService>.Assert(Action assertAction)
        {
            _doAction();
            assertAction();
        }

        void ITestAssertion<TService>.Assert(Action<TService> assertAction)
        {
            _doAction();
            assertAction(_service);
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

    internal class TestAssertion<TService, TResult> : ITestAssertion<TService, TResult>
    {
        private readonly Func<TResult> _doAction;
        private readonly TService _service;

        public TestAssertion(Func<TResult> doAction, TService service)
        {
            _doAction = doAction;
            _service = service;
        }

        void ITestAssertion<TService, TResult>.Assert(Action<TResult> assertAction)
        {
            var result = _doAction();
            assertAction(result);
        }

        void ITestAssertion<TService, TResult>.Assert(Action<TResult, TService> assertAction)
        {
            var result = _doAction();
            assertAction(result, _service);
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