using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
