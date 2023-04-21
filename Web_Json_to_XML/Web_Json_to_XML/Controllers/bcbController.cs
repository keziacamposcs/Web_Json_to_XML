using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp.Serializers;
using Web_Json_to_XML.Models;

namespace Web_Json_to_XML.Controllers
{
    public class BcbController : Controller
    {
        // Botão para converter para XML
        public async Task<IActionResult> GetXML()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/Moedas?$top=100&$format=json&$select=simbolo,nomeFormatado,tipoMoeda"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    // Deserializa a resposta da API JSON para objeto MoedasViewModel
                    var moedasViewModel = JsonConvert.DeserializeObject<MoedasViewModel>(apiResponse);

                    // Serializa o objeto MoedasViewModel para XML
                    var serializer = new XmlSerializer(typeof(MoedasViewModel));
                    var ms = new MemoryStream();
                    using (var xmlWriter = XmlWriter.Create(ms, new XmlWriterSettings { Encoding = System.Text.Encoding.UTF8 }))
                    {
                        serializer.Serialize(xmlWriter, moedasViewModel);
                    }

                    ms.Seek(0, SeekOrigin.Begin);

                    // retorna o XML como um arquivo
                    return File(ms, "application/xml", "arquivo.xml");
                }
            }
        }

        // Botão para visualizar conversão XML
        public async Task<IActionResult> Get2XML()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/Moedas?$top=100&$format=json&$select=simbolo,nomeFormatado,tipoMoeda"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    // Deserializa a resposta da API JSON para objeto MoedasViewModel
                    var moedasViewModel = JsonConvert.DeserializeObject<MoedasViewModel>(apiResponse);

                    // Serializa o objeto MoedasViewModel para XML
                    var serializer = new XmlSerializer(typeof(MoedasViewModel));
                    var ms = new MemoryStream();
                    using (var xmlWriter = XmlWriter.Create(ms, new XmlWriterSettings { Encoding = System.Text.Encoding.UTF8 }))
                    {
                        serializer.Serialize(xmlWriter, moedasViewModel);
                    }

                    ms.Seek(0, SeekOrigin.Begin);
                    var sr = new StreamReader(ms);
                    var xmlString = sr.ReadToEnd();

                    // retorna o XML dentro de uma tag <code>
                    return Content(xmlString, "text/plain");
                }
            }
        }



        //JSON
        public async Task<IActionResult> GetJson()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/Moedas?$top=100&$format=json&$select=simbolo,nomeFormatado,tipoMoeda"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    // Retorna o resultado da API em formato JSON
                    return Content(apiResponse, "application/json");
                }
            }
        }

    }
}
