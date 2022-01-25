using AppExamen.clases;
using AppExamen.model;
using AppExamen.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExamen
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListadoAlumnos : ContentPage
    {
        List<AlumnosModel> servicio;
        List<ModelHistorial> historials;
        List<ModelGrados> grados;


        RestAlumnos restAlumnos;
        public ListadoAlumnos()
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




        async private void BuscarRNE(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(anio.Text))
            {
                await DisplayAlert("Alerta", "Escriba un anio para buscar", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(grado.Text))
            {
                await DisplayAlert("Alerta", "Escriba un grado para buscar", "Ok");
                return;
            }
            else
            {
                getAlumnosGradoHistorial();
            }
           
        }

        private async void listaAlumnos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /*
            var Datos = new AlumnosModel();
            var obj = (AlumnosModel)e.SelectedItem;
            if (!string.IsNullOrEmpty(obj.alumno_rne.ToString()))
            {
                var dataAlumno = await restAlumnos.GetRepositoriesAsync(Constantes.URLAlumnos);
                var listaSeleccionada = dataAlumno.Where(c => c.alumno_rne.Contains(obj.alumno_rne));
                if (listaSeleccionada != null)
                {

                    _alumno_rne = listaSeleccionada.FirstOrDefault().alumno_rne;
                    _alumno_nombre1 = listaSeleccionada.FirstOrDefault().alumno_nombre1;
                    _alumno_nombre2 = listaSeleccionada.FirstOrDefault().alumno_nombre2;
                    _alumno_ape1 = listaSeleccionada.FirstOrDefault().alumno_ape1;
                    _alumno_ape2 = listaSeleccionada.FirstOrDefault().alumno_ape2;
                    _alumno_genero = listaSeleccionada.FirstOrDefault().alumno_genero;
                    _alumno_fnac = listaSeleccionada.FirstOrDefault().alumno_fnac;

                }
            }*/
        }

       async public void getAlumnosGradoHistorial()
        {
            indicador.IsRunning = true;
            indicador.IsVisible = true;
            var lista_alumnos = await restAlumnos.GetRepositoriesHistorialAlumnosAsync(Constantes.URLGETALUMNOS_GRADOS_HISTORIAL);

            if (lista_alumnos != null)
            {

                var _lista = lista_alumnos.Where(v => v.aniol_anio.Contains(anio.Text));
                if (_lista != null)
                {
             
                     var _listagrado = _lista.Where(c => c.grado_nombre.ToLower().Contains(grado.Text.ToLower()));
                       if (_listagrado != null)
                       {
                           listaAlumnos.ItemsSource = _listagrado;
                           indicador.IsRunning = false;
                           indicador.IsVisible = false;
                       }
                       else
                       {
                           await DisplayAlert("Alerta", "No se encontraron registros", "Ok");
                           return;
                       }
                    
                }
                else
                {
                    await DisplayAlert("Alerta", "No se encontraron registros", "Ok");
                    return;
                }

            }
            else
            {
                await DisplayAlert("Alerta", "No se encontraron registros", "Ok");
                return;
            }

         



        }

    }
}
