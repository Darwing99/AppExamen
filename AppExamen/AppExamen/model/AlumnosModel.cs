using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppExamen.model
{
    public class AlumnosModel
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
        public string alumno_genero{ get; set; }
        [JsonProperty("alumno_fnac")]
        public string alumno_fnac { get; set; }
       


    }

}
