using Microsoft.Maui.Controls;
using SimulateurATM.Controllers;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui;
using System.Threading;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;

namespace SimulateurATM.Views
{
    public partial class GuichetPage : ContentPage
    {
        public string Prenom { get; private set; }
        public ICommand AddCharCommand { get; private set; }
        public ICommand DeleteCharCommand { get; private set; }

        public GuichetPage()
        {
            InitializeComponent();
        }

        public GuichetPage(string username, string nip)
        {
            InitializeComponent();
            BindingContext = new Guichet();
            AddCharCommand = new Command<string>(ExecuteAddCharCommand);
            DeleteCharCommand = new Command(ExecuteDeleteCharCommand);
        }

        private void ExecuteAddCharCommand(string param)
        {
            textInput.Text += param;
        }

        private void ExecuteDeleteCharCommand()
        {
            textInput.Text = string.Empty;
        }

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmation", "Voulez-vous quitter votre session?", "Oui", "Non"))
            {
                await Navigation.PushAsync(new LoginPage());
            }
        }

        async private void EtatComptes_Clicked(object sender, EventArgs e)
        {
            foreach (var x in Guichet.ComptesCheque)
            {
                string message = $"Solde du compte chèque {x.NumeroCompte}: {x.SoldeCompte}$";
                ToastDuration duration = ToastDuration.Short;
                double fontSize = 14;
                var toast = Toast.Make(message, duration, fontSize);
                await toast.Show();
            }
        }
    }
}
