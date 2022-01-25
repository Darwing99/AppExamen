using AppExamen.clases;
using AppExamen.model;
using AppExamen.services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizarParentesco : ContentPage
    {
        List<TipoParentescoModel> servicio;
        RestTipoParentesco restModel;
        string codigo_parent,rne_alumno;
        public ActualizarParentesco()
        {
            InitializeComponent();

            restModel = new RestTipoParentesco();
            listaParentesco();
            rne_alumno = codigo_alumno.Text;
        }


        public async void guardarParentesco()
        {

            if (picker_parentesco.SelectedItem == null)
            {
                await DisplayAlert("Alerta", "Seleccione tipo de parentesco", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(nombre.Text))
            {
                await DisplayAlert("Alerta", "Ingrese nombre", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(cedula.Text))
            {
                await DisplayAlert("Alerta","Ingrese cedula","Ok");
                return;
            }

           
            if (string.IsNullOrEmpty(numero.Text))
            {
                await DisplayAlert("Alerta", "Ingrese numero de telefono", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(direccion.Text))
            {
                await DisplayAlert("Alerta", "Ingrese direccion", "Ok");
                return;
            }
            else
            {
                indicador.IsRunning = true;
               
                var item = await restModel.GetRepositoriesAsync(Constantes.URLTipo);
                var pickerid = item.Where(c => c.tipo.Contains(picker_parentesco.SelectedItem.ToString()));
                codigo_parent = pickerid.FirstOrDefault().parentesco_codigo;

                var datosParentesco = new ParentescoModel
                {
                    codigo_parentescos = codigo_parent,
                    parentesco_cedula = cedula.Text,
                    parentesco_nombre = nombre.Text,
                    parentesco_numero = numero.Text,
                    parentesco_direccion = direccion.Text,
                    rne_alumno = rne_alumno

                };

              

                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(datosParentesco);
                var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(

                    Constantes.URLPostParentesco, contentJSON);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    await App.Current.MainPage.DisplayAlert("Registro", "Se agrego parentesco", "OK");
                    indicador.IsRunning = false;
                }
                

            }
           




        }


        async void listaParentesco()
        {
            servicio = await restModel.GetRepositoriesAsync(Constantes.URLTipo);
            foreach (var parentesco in servicio)
            {
                picker_parentesco.Items.Add(parentesco.tipo);

                
            }
        }

       

        private async void Button_Guardar(object sender, EventArgs e)
        {
            guardarParentesco();
        }
    }
}