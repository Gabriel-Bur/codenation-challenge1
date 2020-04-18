using System.IO;
using System.Threading.Tasks;

namespace WebApi.Services.Interfaces
{
    public interface IJsonFileService
    {
        void SaveOnFile(object Content);

        byte[] ReadOfFile();

    }
}
