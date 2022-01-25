using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppExamen.model
{
   public  class TipoParentescoModel
    {
        [JsonProperty("parentesco_codigo")]
        public string parentesco_codigo { get; set; }
        [JsonProperty("tipo")]
        public string tipo { get; set; }
    }
}
