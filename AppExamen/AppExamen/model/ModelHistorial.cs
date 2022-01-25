using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppExamen.model
{
   public class ModelHistorial
    {
        [JsonProperty("alumno_rne")]
        public string alumno_rne { get; set; }

        [JsonProperty("aniol_anio")]
        public string aniol_anio { get; set; }
        
        [JsonProperty("grado_codigo")]
        public string grado_codigo { get; set; }
        
        [JsonProperty("hist_fecham")]
        public string hist_fecham { get; set; }
        
        [JsonProperty("hist_estado")]
        public string hist_estado { get; set; }
        [JsonProperty("hist_enum")]
        public string hist_enum { get; set; }

    }
}
