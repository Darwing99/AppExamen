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
    public partial class PageHome : ContentPage
    {
        public PageHome()
        {
            InitializeComponent();
        }

        private async void Button_perfilAlumnos(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void Button_listadoAlumnos(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListadoAlumnos());
        }

        private async void Button_Imprimir(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImprimirPerfil());
        }

        private async void Button_Update(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Update_Alumno());
        }
    }
}