using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppULA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Conversoes.PaginaInicial();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
