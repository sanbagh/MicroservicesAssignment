using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Data
{
    public interface IDbIntializer
    {
        Task InitializeAsync();
    }
}
