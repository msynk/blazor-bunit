using System;

namespace Blazor.BUnit.Tests
{
    public class FallbackServiceProvider : IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            return new DummyService();
        }
    }

    public class DummyService { }
}
