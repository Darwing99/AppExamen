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
    public partial class Update_Alumno : ContentPage
    {
        List<AlumnosModel> servicio;
        RestAlumnos restAlumnos;
        public Update_Alumno()
        {
            InitializeComponent(); 
            restAlumnos = new RestAlumnos();
        }

        string _alumno_rne, _alumno_nombre1, _alumno_nombre2, _alumno_ape1, _alumno_ape2, _alumno_genero, _alumno_fnac;

        private void UpdateAlumno(object sender, EventArgs e)
        {
            putInfo();
        }

        private async void ButtonUpdateParentesco(object sender, EventArgs e)
        {

            var lista = new AlumnosModel
            {
                alumno_rne = _alumno_rne,
                alumno_nombre1 = _alumno_nombre1,
                alumno_nombre2 = _alumno_nombre2,
                alumno_ape1 = _alumno_ape1,
                alumno_ape2 = _alumno_ape2,
                alumno_genero = _alumno_genero,
                alumno_fnac = _alumno_fnac
            };
            Boolean accept = await DisplayAlert("Navegacion", "Editar parentescos de: " + _alumno_nombre1, "Si", "No");
            if (accept == true)
            {
                var datosalumnos = new ActualizarParentesco();
                datosalumnos.BindingContext = lista;
                await Navigation.PushAsync(datosalumnos);
            }
            else
            {
                return;
            }
        }


        async void ObtenerAlumnos()
        {

            indicador.IsRunning = true;
            indicador.IsVisible = true;

            servicio = await restAlumnos.GetRepositoriesAsync(Constantes.URLAlumnos);
            if (servicio == null)
            {
                await DisplayAlert("Alerta", "No se encontraron registros", "Ok");
                return;
            }
            else
            {
                var data = servicio.Where(c => c.alumno_rne.Equals(buscar_rne.Text));
                if (data != null)
                {
                    visible.IsVisible = true;
                    codigo.Text = data.FirstOrDefault().alumno_rne;
                    nombre1.Text = data.FirstOrDefault().alumno_nombre1;
                    nombre2.Text = data.FirstOrDefault().alumno_nombre2;
                    apellido1.Text = data.FirstOrDefault().alumno_ape1;
                    apellido2.Text = data.FirstOrDefault().alumno_ape2;
                    genero.Text = data.FirstOrDefault().alumno_genero;
                    string fechan= data.FirstOrDefault().alumno_fnac;
                    fecha.Date = DateTime.Parse(fechan);

                }
                else
                {
                    await DisplayAlert("Alerta", "No existe este alumno", "Ok");
                    visible.IsVisible = false;
                    codigo.Text ="";
                    nombre1.Text = "";
                    nombre2.Text = "";
                    apellido1.Text = "";
                    apellido2.Text ="";
                    genero.Text ="";
                   
                    
                }
                indicador.IsRunning = false;
                indicador.IsVisible = false;

            }

        }
        public async void putInfo()
        {
            if (string.IsNullOrEmpty(nombre1.Text))
            {
                await DisplayAlert("Datos", "Campo de nombre vacio", "OK");
                return;

            }
            if (string.IsNullOrEmpty(nombre2.Text))
            {
                await DisplayAlert("Datos", "Campo de nombre vacio", "OK");
                return;
            }
            if (string.IsNullOrEmpty(apellido1.Text))
            {
                await DisplayAlert("Datos", "Campo de apellido vacio", "OK");
                return;
            }
            if (string.IsNullOrEmpty(apellido2.Text))
            {
                await DisplayAlert("Datos", "Campo de apellido vacio", "OK");
                return;
            }
            if (string.IsNullOrEmpty(genero.Text))
            {
                await DisplayAlert("Datos", "Campo de genero vacio", "OK");
                return;
            }
            indicadorUpdate.IsRunning = true;

            var user = new AlumnosModel
            {
                alumno_nombre1 = nombre1.Text,
                alumno_nombre2 = nombre2.Text,
                alumno_ape1 = apellido1.Text,
                alumno_ape2 = apellido2.Text,
                alumno_genero = genero.Text,
                alumno_fnac = fecha.Date.ToString()

            };


            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(user);
            var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(Constantes.URLUPDATEALUMNOS+codigo.Text, contentJSON);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                await DisplayAlert("Datos", "Se Actualizo El Perfil", "OK");
                indicadorUpdate.IsRunning = false;
              
            }
        }


        async private void BuscarRNE(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(buscar_rne.Text))
            {
                await DisplayAlert("Alerta", "Escriba un RNE para buscar", "Ok");
                return;
            }

            ObtenerAlumnos();
        }

       
        }
    }