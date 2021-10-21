using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioIti.Core.Services.Interface
{
    public interface IHashService
    {
        ValueTask<bool> ValidateHash(string hashValue);
    }
}
