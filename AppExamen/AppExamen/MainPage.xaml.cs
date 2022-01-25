using AppExamen.clases;
using AppExamen.model;
using AppExamen.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppExamen
{
    public partial class MainPage : ContentPage
    {


        List<AlumnosModel> servicio;
        RestAlumnos restAlumnos;
        public MainPage()
        {
            InitializeComponent();
            restAlumnos = new RestAlumnos();
           
        }

        string _alumno_rne, _alumno_nombre1, _alumno_nombre2, _alumno_ape1, _alumno_ape2, _alumno_genero, _alumno_fnac;

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
            Boolean accept = await DisplayAlert("Navegacion", "Editar parentescos de: "+_alumno_nombre1, "Si", "No");
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
               await DisplayAlert("Alerta","No se encontraron registros","Ok");
                return;
            }
            else
            {
                var data = servicio.Where(c => c.alumno_rne.Equals(buscar_rne.Text));
                if (data != null)
                {
                    listaAlumnos.ItemsSource = data;
                }
                else
                {
                    await DisplayAlert("Alerta", "Ingrese un codigo valido", "Ok");
                    listaAlumnos.ItemsSource = "";
                }
               
                indicador.IsRunning = false;
                indicador.IsVisible = false;

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

        private async void listaAlumnos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Datos = new AlumnosModel();
            var obj = (AlumnosModel)e.SelectedItem;
            if (!string.IsNullOrEmpty(obj.alumno_rne.ToString()))
            {
                var dataAlumno= await restAlumnos.GetRepositoriesAsync(Constantes.URLAlumnos);
                var listaSeleccionada =  dataAlumno.Where(c=>c.alumno_rne.Contains(obj.alumno_rne));
                if (listaSeleccionada!=null)
                {

                    _alumno_rne = listaSeleccionada.FirstOrDefault().alumno_rne;
                    _alumno_nombre1 = listaSeleccionada.FirstOrDefault().alumno_nombre1;
                    _alumno_nombre2 = listaSeleccionada.FirstOrDefault().alumno_nombre2;
                    _alumno_ape1 = listaSeleccionada.FirstOrDefault().alumno_ape1;
                    _alumno_ape2 = listaSeleccionada.FirstOrDefault().alumno_ape2;
                    _alumno_genero = listaSeleccionada.FirstOrDefault().alumno_genero;
                    _alumno_fnac = listaSeleccionada.FirstOrDefault().alumno_fnac;

                }
            }
        }
    }
}
