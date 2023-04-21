using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web_Json_to_XML.Models;

namespace Web_Json_to_XML.Controllers
{
    public class BcbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/Moedas?$top=100&$format=json&$select=simbolo,nomeFormatado,tipoMoeda"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    // Deserializa a resposta da API JSON para objeto MoedasViewModel
                    var moedasViewModel = JsonConvert.DeserializeObject<MoedasViewModel>(apiResponse);

                    // Serializa o objeto MoedasViewModel para XML
                    XmlSerializer serializer = new XmlSerializer(typeof(MoedasViewModel));
                    var stringWriter = new StringWriter();
                    serializer.Serialize(stringWriter, moedasViewModel);

                    // Retorna o resultado da serialização em formato XML para a View
                    ViewBag.Xml = stringWriter.ToString();
                }
            }
            return View("bcbView");

        }
    }
}
