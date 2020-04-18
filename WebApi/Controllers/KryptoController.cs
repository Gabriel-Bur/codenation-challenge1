using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.Models;
using WebApi.Services;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KryptoController : ControllerBase
    {

        private readonly JsonFileService _jsonService;
        private readonly Cypher _cypherService;
        private readonly CodeNationClient _client;

        public KryptoController()
        {
            _client = new CodeNationClient();
            _jsonService = new JsonFileService();
            _cypherService = new Cypher();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var jsonContent = await _client.GetData();

                CypherViewModel cypherData = JsonConvert
                    .DeserializeObject<CypherViewModel>(jsonContent);

                cypherData.decifrado = _cypherService
                    .Decode(cypherData.numero_casas , cypherData.cifrado.ToLower());

                cypherData.resumo_criptografico = Hasher
                    .Hash(cypherData.decifrado);

                _jsonService.SaveOnFile(cypherData);

                await _client.PostData(_jsonService.ReadOfFile());

                return Ok();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}