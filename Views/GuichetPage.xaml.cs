using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace SimulateurATM.Views
{
    public partial class GuichetPage : ContentPage
    {
        public ICommand AddCharCommand { get; private set; }

        public GuichetPage()
        {
            InitializeComponent();
           // BindingContext = new GuichetPage();
            AddCharCommand = new Command<string>(ExecuteAddCharCommand);
        }

        private void ExecuteAddCharCommand(string param)
        {
            textInput.Text += param;
        }

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmation", "Voulez vous quitter votre session?", "Oui", "Non"))
            {
                SecureStorage.RemoveAll();
                await Shell.Current.GoToAsync("///login");
            }
        }
    }
}
