using System;
using Xunit;

namespace EzyRates.Tests
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ObservationAttribute : FactAttribute
    {
    }
    
    public abstract class Specification: IDisposable
    {
        protected Specification()
        {
            Execute();
        }

        protected abstract void EstablishContext();
        protected abstract void BecauseOf();
        protected virtual void AfterEach()
        {
        }

        protected bool ScenarioExceptionsExpected;
        protected Exception ScenarioException;

        private void Execute()
        {
            try
            {
                EstablishContext();
                BecauseOf();
            }
            catch(Exception exception)
            {
                if (!ScenarioExceptionsExpected)
                    throw;

                ScenarioException = exception;
            }
        }

        public void Dispose()
        {
            AfterEach();
        }
    }
}