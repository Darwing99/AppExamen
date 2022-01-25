using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppExamen.model
{
    public class ModelHistorialAlumnos
    {
        [JsonProperty("alumno_rne")]
        public string alumno_rne { get; set; }
        [JsonProperty("alumno_nombre1")]
        public string alumno_nombre1 { get; set; }
        [JsonProperty("alumno_nombre2")]
        public string alumno_nombre2 { get; set; }
        [JsonProperty("alumno_ape1")]
        public string alumno_ape1 { get; set; }
        [JsonProperty("alumno_ape2")]
        public string alumno_ape2 { get; set; }
        [JsonProperty("alumno_genero")]
        public string alumno_genero { get; set; }
        [JsonProperty("alumno_fnac")]
        public string alumno_fnac { get; set; }

        [JsonProperty("grado_codigo")]
        public string grado_codigo { get; set; }

        [JsonProperty("grado_nombre")]
        public string grado_nombre { get; set; }

        [JsonProperty("grado_orden")]
        public string grado_orden { get; set; }


        [JsonProperty("aniol_anio")]
        public string aniol_anio { get; set; }

        [JsonProperty("hist_fecham")]
        public string hist_fecham { get; set; }

        [JsonProperty("hist_estado")]
        public string hist_estado { get; set; }
        [JsonProperty("hist_enum")]
        public string hist_enum { get; set; }
    }
}
