using AppExamen.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppExamen.services
{
    class RestTipoParentesco
    {
        HttpClient cliente;

        public RestTipoParentesco()
        {
            cliente = new HttpClient();
        }
        public async Task<List<TipoParentescoModel>> GetRepositoriesAsync(string url)
        {
            List<TipoParentescoModel> lista = null;
            try
            {
                HttpResponseMessage respuesta = await cliente.GetAsync(url);
                if (respuesta.IsSuccessStatusCode)
                {
                    string informacion = await respuesta.Content.ReadAsStringAsync();
                    lista = JsonConvert.DeserializeObject<List<TipoParentescoModel>>(informacion);

                }
            }
            catch (Exception ex)
            {

            }

            return lista;
        }


    }



}