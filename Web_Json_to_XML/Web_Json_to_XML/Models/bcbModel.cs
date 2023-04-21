using System.Collections.Generic;

namespace Web_Json_to_XML.Models
{
    public class MoedasViewModel
    {
        public List<Moeda> value { get; set; }
    }

    public class Moeda
    {
        public string simbolo { get; set; }
        public string nomeFormatado { get; set; }
        public string tipoMoeda { get; set; }
    }
}
