using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class CodeNationClient : ICodeNationClient
    {
        private const string TOKEN = "7b4b3450552c7061a793807827e623bbdae5dba4";
        private readonly string generateEndPoint = $"https://api.codenation.dev/v1/challenge/dev-ps/generate-data?token={TOKEN}";
        private readonly string submitEndPoint = $"https://api.codenation.dev/v1/challenge/dev-ps/submit-solution?token={TOKEN}";

        public async Task<string> GetData()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(generateEndPoint);
               return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task PostData(byte[] file)
        {
            var fileContent = new ByteArrayContent(file);

            using (var client = new HttpClient())
            {
                var form = new MultipartFormDataContent();
                form.Add(fileContent, "answer", "answer");

                var response = await client.PostAsync(submitEndPoint, form);

                var nota = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
