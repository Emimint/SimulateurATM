using Microsoft.Maui.Controls;
using SimulateurATM.Controllers;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui;
using System.Threading;
using CommunityToolkit.Maui.Core;
using System.ComponentModel;


namespace SimulateurATM.Views
{
    public partial class GuichetPage : ContentPage, INotifyPropertyChanged
    {
        Client currentClient;
        Cheque currentCheckingAccount;
        Epargne currentSavingAccount;

        private string _prenom;
        private float _soldeCheque;
        private float _soldeEpargne;

        public string Prenom
        {
            get => _prenom;
            private set
            {
                if (_prenom != value)
                {
                    _prenom = value;
                    OnPropertyChanged(nameof(Prenom));
                }
            }
        }

        public float SoldeCheque
        {
            get => _soldeCheque;
            private set
            {
                if (_soldeCheque != value)
                {
                    _soldeCheque = value;
                    OnPropertyChanged(nameof(SoldeCheque));
                }
            }
        }

        public float SoldeEpargne
        {
            get => _soldeEpargne;
            private set
            {
                if (_soldeEpargne != value)
                {
                    _soldeEpargne = value;
                    OnPropertyChanged(nameof(SoldeEpargne));
                }
            }
        }

        public ICommand AddCharCommand { get; private set; }

        public ICommand DeleteCharCommand { get; private set; }

        public GuichetPage()
        {
            InitializeComponent();
            Init();
        }

        public GuichetPage(string username, string nip)
        {
            InitializeComponent();

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

            // Creation du compte superviseur :
            Client superviseur = new Client("Admin", "Admin", "Admin", "Nimda");
            Guichet.clients.Add(superviseur);
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
        }

        async private void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            stackEtatComptes.IsVisible = false;

            bool isDepotSelected = DepotRadioButton.IsChecked;
            bool isRetraitSelected = RetraitRadioButton.IsChecked;
            bool isVirementSelected = VirementRadioButton.IsChecked;
            bool isChequeSelected = ChequeRadioButton.IsChecked;
            bool isEpargneSelected = EpargneRadioButton.IsChecked;

            if (isDepotSelected && isChequeSelected)
            {
                if (float.TryParse(textInput.Text, out float amount))
                {
                    try
                    {
                        Guichet.DepotCheque(currentCheckingAccount.getNumeroNIP(), amount);
                        SoldeCheque = currentCheckingAccount.getSoldeCompte();

                        string message = $"Nouveau solde cheque: {SoldeCheque}$";
                        ToastDuration duration = ToastDuration.Short;
                        double fontSize = 14;
                        var toast = Toast.Make(message, duration, fontSize);
                        await toast.Show();
                    }
                    catch (Exception ex)
                    {
                        string errorMessage = ex.Message;
                        ToastDuration duration = ToastDuration.Short;
                        double fontSize = 14;
                        var toast = Toast.Make(errorMessage, duration, fontSize);
                        await toast.Show();
                    }
                }
            }
            else if (isRetraitSelected && isChequeSelected)
            {
                if (float.TryParse(textInput.Text, out float amount))
                {
                    try
                    {
                        Guichet.RetraitCheque(currentCheckingAccount.getNumeroNIP(), amount);
                        SoldeCheque = currentCheckingAccount.getSoldeCompte();

                        string message = $"Nouveau solde cheque: {SoldeCheque}$";
                        ToastDuration duration = ToastDuration.Short;
                        double fontSize = 14;
                        var toast = Toast.Make(message, duration, fontSize);
                        await toast.Show();
                    }
                    catch (Exception ex)
                    {
                        string errorMessage = ex.Message;
                        ToastDuration duration = ToastDuration.Short;
                        double fontSize = 14;
                        var toast = Toast.Make(errorMessage, duration, fontSize);
                        await toast.Show();
                    }
                }
            }
            else if (isDepotSelected && isEpargneSelected)
            {
                if (float.TryParse(textInput.Text, out float amount))
                {
                    try
                    {
                        Guichet.DepotEpargne(currentSavingAccount.getNumeroNIP(), amount);
                        SoldeEpargne = currentSavingAccount.getSoldeCompte();

                        string message = $"Nouveau solde epargne: {SoldeEpargne}$";
                        ToastDuration duration = ToastDuration.Short;
                        double fontSize = 14;
                        var toast = Toast.Make(message, duration, fontSize);
                        await toast.Show();
                    }
                    catch (Exception ex)
                    {
                        string errorMessage = ex.Message;
                        ToastDuration duration = ToastDuration.Short;
                        double fontSize = 14;
                        var toast = Toast.Make(errorMessage, duration, fontSize);
                        await toast.Show();
                    }
                }
            }

            else if (isRetraitSelected && isEpargneSelected)
            {
                if (float.TryParse(textInput.Text, out float amount))
                {
                    try
                    {
                        Guichet.RetraitEpargne(currentSavingAccount.getNumeroNIP(), amount);
                        SoldeEpargne = currentSavingAccount.getSoldeCompte();

                        string message = $"Nouveau solde epargne: {SoldeEpargne}$";
                        ToastDuration duration = ToastDuration.Short;
                        double fontSize = 14;
                        var toast = Toast.Make(message, duration, fontSize);
                        await toast.Show();
                    }
                    catch (Exception ex)
                    {
                        string errorMessage = ex.Message;
                        ToastDuration duration = ToastDuration.Short;
                        double fontSize = 14;
                        var toast = Toast.Make(errorMessage, duration, fontSize);
                        await toast.Show();
                    }
                }
            }
            else if (isVirementSelected && isChequeSelected)
            {
                if (float.TryParse(textInput.Text, out float amount))
                {
                    try
                    {
                        Guichet.VirementCheque(currentClient.getNumeroNIP(), amount);
                        SoldeEpargne = Guichet.getEpargne(currentClient.getNumeroNIP()).getSoldeCompte();
                        SoldeCheque = Guichet.getCheque(currentClient.getNumeroNIP()).getSoldeCompte();

                        string message = $"Virement de {amount}$ de votre compte Cheque vers votre compte Epargne.";
                        ToastDuration duration = ToastDuration.Short;
                        double fontSize = 14;
                        var toast = Toast.Make(message, duration, fontSize);
                        await toast.Show();
                    }
                    catch (Exception ex)
                    {
                        string errorMessage = ex.Message;
                        ToastDuration duration = ToastDuration.Short;
                        double fontSize = 14;
                        var toast = Toast.Make(errorMessage, duration, fontSize);
                        await toast.Show();
                    }
                }
            }
            else if (isVirementSelected && isEpargneSelected)
            {
                if (float.TryParse(textInput.Text, out float amount))
                {
                    try
                    {
                        Guichet.VirementEpargne(currentClient.getNumeroNIP(), amount);
                        SoldeEpargne = Guichet.getEpargne(currentClient.getNumeroNIP()).getSoldeCompte();
                        SoldeCheque = Guichet.getCheque(currentClient.getNumeroNIP()).getSoldeCompte();

                        string message = $"Virement de {amount}$ de votre compte Epargne vers votre compte Cheque.";
                        ToastDuration duration = ToastDuration.Short;
                        double fontSize = 14;
                        var toast = Toast.Make(message, duration, fontSize);
                        await toast.Show();
                    }
                    catch (Exception ex)
                    {
                        string errorMessage = ex.Message;
                        ToastDuration duration = ToastDuration.Short;
                        double fontSize = 14;
                        var toast = Toast.Make(errorMessage, duration, fontSize);
                        await toast.Show();
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
