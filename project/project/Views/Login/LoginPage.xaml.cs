using project.Models.Login.Interfaces;
using project.Services;
using project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            ILogin login = new LoginPageViewModel(new LoginValidatorService());
            BindingContext = login;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            AppShell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            AppShell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        }
    }
}