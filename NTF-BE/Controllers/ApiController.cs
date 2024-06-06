using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NTF_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("TargetData")]
        public async Task<IActionResult> GetTargetData()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("TLG-API-Key", "1ugi1ri71san1ri71uh81c3j1ugi1ri71san1ri71uh8");

                var response = await client.GetAsync("https://dev.talgil.com/api/targets/6051");
                response.EnsureSuccessStatusCode(); // Throw an exception if the status code is not a success code

                var content = await response.Content.ReadAsStringAsync();
                // Parse the content if necessary and return it
                return Ok(content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("targets/{id}")]
        public async Task<IActionResult> GetControllerStates(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("TLG-API-Key", "1ugi1ri71san1ri71uh81c3j1ugi1ri71san1ri71uh8");

                var response = await client.GetAsync($"https://dev.talgil.com/api/targets/{id}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("mytargets")]
        public async Task<IActionResult> GetMyTargets()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("TLG-API-Key", "1ugi1ri71san1ri71uh81c3j1ugi1ri71san1ri71uh8");

                var response = await client.GetAsync("https://dev.talgil.com/api/mytargets");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{targetId}/mainvalves")]
        public async Task<IActionResult> GetMainValvesForTarget(int targetId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("TLG-API-Key", "1ugi1ri71san1ri71uh81c3j1ugi1ri71san1ri71uh8");

                var response = await client.GetAsync($"https://dev.talgil.com/api/targets/{targetId}/mainvalves");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{targetId}/mainvalves/{valveId}")]
        public async Task<IActionResult> GetMainValve(int targetId, string valveId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("TLG-API-Key", "1ugi1ri71san1ri71uh81c3j1ugi1ri71san1ri71uh8");

                var response = await client.GetAsync($"https://dev.talgil.com/api/targets/{targetId}/mainvalves/{valveId}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/valves")]
        public async Task<IActionResult> GetValvesForTarget(int id)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("TLG-API-Key", "1ugi1ri71san1ri71uh81c3j1ugi1ri71san1ri71uh8");

                var response = await client.GetAsync($"https://dev.talgil.com/api/targets/{id}/valves");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("targets/{targetId}/lines/{lineId}/valves/{valveId}")]
        public async Task<IActionResult> GetValveForLineInTarget(int targetId, int valveId, int lineId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("TLG-API-Key", "1ugi1ri71san1ri71uh81c3j1ugi1ri71san1ri71uh8");

                var response = await client.GetAsync($"https://dev.talgil.com/api/targets/{targetId}/lines/{lineId}/valves/{valveId}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("targets/{targetId}/valves/{valveId}/open")]
        public async Task<IActionResult> OpenValve(int targetId, int valveId, [FromQuery] string command)
        {
            // Verifica si el comando es 'open'
            if (command != "open")
            {
                return BadRequest("Comando inválido. El comando debe ser 'open'.");
            }

            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("TLG-API-Key", "1ugi1ri71san1ri71uh81c3j1ugi1ri71san1ri71uh8");

                var response = await client.PostAsync($"https://dev.talgil.com/api/targets/{targetId}/valves/{valveId}?command={command}", null);
                response.EnsureSuccessStatusCode();

                return Ok($"Válvula {valveId} del objetivo {targetId} abierta con éxito.");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error al conectar con el API: {ex.Message}");
            }
        }

        [HttpPost("targets/{targetId}/valves/{valveId}/close")]
        public async Task<IActionResult> CloseValve(int targetId, int valveId, [FromQuery] string command)
        {
            // Verifica si el comando es 'close'
            if (command != "close")
            {
                return BadRequest("Comando inválido. El comando debe ser 'close'.");
            }

            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("TLG-API-Key", "1ugi1ri71san1ri71uh81c3j1ugi1ri71san1ri71uh8");

                var response = await client.PostAsync($"https://dev.talgil.com/api/targets/{targetId}/valves/{valveId}?command={command}", null);
                response.EnsureSuccessStatusCode();

                return Ok($"Válvula {valveId} del objetivo {targetId} cerrada con éxito.");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error al conectar con el API: {ex.Message}");
            }
        }

    }
}
