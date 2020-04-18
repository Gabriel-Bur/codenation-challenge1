using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services.Interfaces
{
    public interface ICodeNationClient
    {
        Task<string> GetData();
        Task PostData(byte[] file);
    }
}
