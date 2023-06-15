using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace glasnost_back.Entities
{
    public class DueDiligenceAPI
    {

        public partial class Searches
        {
            public virtual Searches_Meta meta { get; set; }
            public virtual ICollection<Searches_Data> data { get; set; }
            public virtual ICollection<Searches_Link> links { get; set; }

        }

        public partial class Searches_Data
        {
            public int search_Id { get; set; }
            public string name { get; set; }
            public string document { get; set; }
            public string status { get; set; }
            public string progress { get; set; }
            public string report_url { get; set; }
            public string message { get; set; }

        }
        public partial class Searches_Link
        {
            public string first { get; set; }
            public string last { get; set; }
            public string prev { get; set; }
            public string next { get; set; }

        }
        public partial class Searches_Meta
        {
            public int current_page { get; set; }
            public int from { get; set; }
            public int last_page { get; set; }
            public string path { get; set; }
            public int per_page { get; set; }
            public int to { get; set; }
            public int total { get; set; }

        }

        public partial class Searches_Meta
        {
            public int source_id { get; set; }
            public string source_name { get; set; }
        }

        public partial class Searches_Resultado
        {
            public string name { get; set; }
            public string documento { get; set; }
            public ICollection<Searches_Resultado> data { get; set; }
        }

        public partial class Searches_Resultado
        { 
            public string Certidao { get; set; }
            public string Link { get; set; }
            public string Protocolo { get; set; }
            public string Data_de_Emissao { get; set; }
            public string Nada_Consta { get; set; }
        }
    }
}