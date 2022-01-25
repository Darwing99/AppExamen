using AppExamen.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppExamen.services
{
    public class RestAlumnos
    {
        HttpClient cliente;

        public RestAlumnos()
        {
            cliente = new HttpClient();
        }
        public async Task<List<AlumnosModel>> GetRepositoriesAsync(string url)
        {
            List<AlumnosModel> lista = null;
            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (respuesta.IsSuccessStatusCode)
                {
                    string informacion = await respuesta.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<AlumnosModel>>(informacion);

                }
            }
            catch (Exception ex)
            {
               
            }

            return lista;
        }

        //METODO PARA OBTENER GRADOS
        public async Task<List<ModelGrados>> GetRepositoriesGradoAsync(string url)
        {
            List<ModelGrados> lista = null;
            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (respuesta.IsSuccessStatusCode)
                {
                    string informacion = await respuesta.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<ModelGrados>>(informacion);

                }
            }
            catch (Exception ex)
            {

            }

            return lista;
        }
        //METODO PARA OBTENER HISTORIAL DE ALUMNOS


        public async Task<List<ModelHistorialAlumnos>> GetRepositoriesHistorialAlumnosAsync(string url)
        {
            List<ModelHistorialAlumnos> lista = null;
            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (respuesta.IsSuccessStatusCode)
                {
                    string informacion = await respuesta.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<ModelHistorialAlumnos>>(informacion);

                }
            }
            catch (Exception ex)
            {

            }

            return lista;
        }
    }



}