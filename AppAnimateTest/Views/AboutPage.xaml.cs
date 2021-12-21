using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppAnimateTest.ViewModels;

namespace AppAnimateTest.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            //Initiate data download
            ((AboutViewModel)BindingContext).IsBusy = true;

            //Start loading animation...........
            LoadingIcon.Animate("Rotate", (dd) => { LoadingIcon.Rotation = dd; }, 0, 360, 32, 2000, Easing.Linear, null, () => { return true; });
        }
    }
}