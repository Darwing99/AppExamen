using AppExamen.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppExamen.services
{
    class RestParentesco
    {
        HttpClient cliente;

        public RestParentesco()
        {
            cliente = new HttpClient();
        }
        public async Task<List<ParentescoModel>> GetRepositoriesAsync(string url)
        {
            List<ParentescoModel> lista = null;
            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (respuesta.IsSuccessStatusCode)
                {
                    string informacion = await respuesta.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<ParentescoModel>>(informacion);

                }
            }
            catch (Exception ex)
            {

            }

            return lista;
        }



        public async Task<List<ParentescoModel>> DeleteTodoItemAsync(string url)
        {
            List<ParentescoModel> lista = null;


            HttpResponseMessage response = await cliente.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {

            }
            return lista;
        }



    }



}