using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppExamen.model
{
   public class ModelGrados
    {

        [JsonProperty("grado_codigo")]
        public string grado_codigo { get; set; }

        [JsonProperty("grado_nombre")]
        public string grado_nombre { get; set; }

        [JsonProperty("grado_orden")]
        public string grado_orden { get; set; }
        
    }
}
