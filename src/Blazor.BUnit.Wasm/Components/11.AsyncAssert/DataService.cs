using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.BUnit.Wasm
{
    public class DataService : IDataService
    {
        public async Task<string> Get(int id)
        {
            await Task.Delay(2000);

            return $"Data-{id}";
        }
    }
}
