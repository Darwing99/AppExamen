using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppExamen.model
{
    public class ParentescoModel
    {

        [JsonProperty("parentesco_cedula")]
        public string parentesco_cedula { get; set; }
        [JsonProperty("parentesco_nombre")]
        public string parentesco_nombre { get; set; }
        [JsonProperty("parentesco_numero")]
        public string parentesco_numero { get; set; }
        [JsonProperty("parentesco_direccion")]
        public string parentesco_direccion { get; set; }
        [JsonProperty("rne_alumno")]
        public string rne_alumno { get; set; }
        [JsonProperty("codigo_parentescos")]
        public string codigo_parentescos { get; set; }
 
    }
}
