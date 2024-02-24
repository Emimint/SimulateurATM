using Microsoft.Maui.Controls;
using SimulateurATM.Controllers;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui;
using System.Threading;
using CommunityToolkit.Maui.Core;


namespace SimulateurATM.Views
{
    public partial class GuichetPage : ContentPage
    {
        Client currentClient;
        Cheque currentCheckingAccount;
        Epargne currentSavingAccount;
        public string Prenom { get; private set; }

        public float SoldeCheque { get; private set; }

        public float SoldeEpargne { get; private set; }
        public ICommand AddCharCommand { get; private set; }

        public ICommand DeleteCharCommand { get; private set; }

        public GuichetPage() {
            InitializeComponent();
            Init();
        }
    

        public GuichetPage(string username, string nip)
        {
            InitializeComponent();
            Init();

            currentClient = Guichet.getClient(username, nip);
            currentCheckingAccount = Guichet.getCheque(nip);
            currentSavingAccount = Guichet.getEpargne(nip);
            SoldeCheque = currentCheckingAccount.getSoldeCompte();
            SoldeEpargne = currentSavingAccount.getSoldeCompte();

            Prenom = currentClient.getPrenom();

            AddCharCommand = new Command<string>(ExecuteAddCharCommand);
            DeleteCharCommand = new Command(ExecuteDeleteCharCommand);

            BindingContext = this;
        }

        private void ExecuteAddCharCommand(string param)
        {
            textInput.Text += param;
        }

        private void ExecuteDeleteCharCommand()
        {
            textInput.Text = string.Empty;
        }

        public static void Init()
        {
            // Création des clients et de leurs comptes :
            Guichet.clients = new List<Client>();
            Guichet.comptesCheque = new List<Cheque>();
            Guichet.comptesEpargne = new List<Epargne>();

            Client client1 = new Client("Naim", "Himrane", "Nhimrane", "1234");
            Guichet.clients.Add(client1);

            Cheque compteCheque1 = new Cheque("1234", "C1", 1000);
            Guichet.comptesCheque.Add(compteCheque1);

            Epargne compteEpargne1 = new Epargne("1234", "E1", 5000);
            Guichet.comptesEpargne.Add(compteEpargne1);

            Client client2 = new Client("John", "Doe", "Jdoe", "5678");
            Guichet.clients.Add(client2);

            Cheque compteCheque2 = new Cheque("5678", "C2", 2000);
            Guichet.comptesCheque.Add(compteCheque2);

            Epargne compteEpargne2 = new Epargne("5678", "E2", 8000);
            Guichet.comptesEpargne.Add(compteEpargne2);

            Client client3 = new Client("Alice", "Smith", "Asmith", "9012");
            Guichet.clients.Add(client3);

            Cheque compteCheque3 = new Cheque("9012", "C3", 1500);
            Guichet.comptesCheque.Add(compteCheque3);

            Epargne compteEpargne3 = new Epargne("9012", "E3", 7000);
            Guichet.comptesEpargne.Add(compteEpargne3);

            Client client4 = new Client("Emily", "Johnson", "Ejohnson", "3456");
            Guichet.clients.Add(client4);

            Cheque compteCheque4 = new Cheque("3456", "C4", 3000);
            Guichet.comptesCheque.Add(compteCheque4);

            Epargne compteEpargne4 = new Epargne("3456", "E4", 6000);
            Guichet.comptesEpargne.Add(compteEpargne4);

            Client client5 = new Client("Michael", "Williams", "Mwilliams", "7890");
            Guichet.clients.Add(client5);

            Cheque compteCheque5 = new Cheque("7890", "C5", 2500);
            Guichet.comptesCheque.Add(compteCheque5);

            Epargne compteEpargne5 = new Epargne("7890", "E5", 9000);
            Guichet.comptesEpargne.Add(compteEpargne5);
        }

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmation", "Voulez vous quitter votre session?", "Oui", "Non"))
            {
                await Navigation.PushAsync(new LoginPage());
            }
        }

        async private void EtatComptes_Clicked(object sender, EventArgs e)
        {

            stackEtatComptes.IsVisible = true;

            // string message = $"Votre NIP est '{currentClient.getNumeroNIP()}; le compte cheque est {Guichet.comptesCheque[0].NumeroCompte}";
            string message = $"Votre NIP est '{currentClient.getNumeroNIP()}; le compte cheque est {currentCheckingAccount.getNumeroCompte()}";



            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(message, duration, fontSize);

            await toast.Show();

/*            foreach (var x in Guichet.comptesCheque)
            {
                string message = $"Solde du compte chèque '{x.NumeroCompte}': {x.SoldeCompte}$";

                ToastDuration duration = ToastDuration.Short;
                double fontSize = 14;

                var toast = Toast.Make(message, duration, fontSize);

                await toast.Show();
            }*/

           //  Console.WriteLine($"currentClient.getNumeroNIP(): {currentClient.getNumeroNIP()}");

           // Cheque currentCheque = comptesCheque.FirstOrDefault(x => x.NumeroNIP == currentClient.getNumeroNIP());


/*            string message = $"Solde du compte chèque : {currentCheque.SoldeCompte}";

            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(message, duration, fontSize);

            await toast.Show();*/


        }
    }
}
