﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.BUnit.Wasm
{
    public interface IDataService
    {
        Task<string> Get(int id);
    }
}