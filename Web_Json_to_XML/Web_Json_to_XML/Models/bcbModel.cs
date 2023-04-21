using System.Collections.Generic;

namespace Web_Json_to_XML.Models
{
    public class Moeda
    {
        public string simbolo { get; set; }
        public string nomeFormatado { get; set; }
        public string tipoMoeda { get; set; }
    }

    public class MoedasViewModel
    {
        public List<Moeda> moedas { get; set; }
    }
}
