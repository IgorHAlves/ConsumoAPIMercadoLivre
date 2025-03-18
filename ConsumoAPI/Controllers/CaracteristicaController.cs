using System.Text.Json;
using ConsumoAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ConsumoAPI.Controllers
{
    [ApiController]
    [Route("caracteristica")]
    public class CaracteristicaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Caracteristicas()
        {
            using var httpClient = new HttpClient();
            const string endPoint = "https://api.mercadolibre.com/sites/MLB/categories";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(endPoint);
                if (response.IsSuccessStatusCode)
                {
                    string retornoApi = await response.Content.ReadAsStringAsync();

                    var json = JsonDocument.Parse(retornoApi);

                    var result = json.RootElement.EnumerateArray().ToArray();

                    List<Caracteristica> caracteristicas = new List<Caracteristica>();

                    int incrementoId = 0;

                    foreach (var item in result)
                    {
                        caracteristicas.Add(new Caracteristica
                        {
                            Id = incrementoId++,
                            IdMercadoLivre = item.GetProperty("id").GetString(),
                            Name = item.GetProperty("name").GetString()

                        });
                    }

                    string stop = "a";
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Ok();
        }
    }
}
