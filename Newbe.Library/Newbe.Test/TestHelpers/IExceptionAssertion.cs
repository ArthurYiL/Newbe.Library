using System;

namespace Newbe.Test.TestHelpers
{
    public interface IExceptionAssertion
    {
        void Throw<TException>() where TException : Exception;
        void Throw<TException>(Action<TException> exceptionAssertion) where TException : Exception;
    }
}