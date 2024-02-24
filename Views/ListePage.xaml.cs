using SimulateurATM.Controllers;
using System.Collections.Generic;
using System.ComponentModel;

namespace SimulateurATM.Views
{
    public partial class ListePage : ContentPage
    {
        public List<Compte> Comptes { get; set; }
        public string Titre { get; set; }

        public ListePage()
        {
            InitializeComponent();
        }

        public ListePage(List<Cheque> comptesCheque)
        {
            InitializeComponent();
            Comptes = comptesCheque.ConvertAll(x => (Compte)x);
            Titre = "Liste des comptes cheques";
            BindingContext = this;
        }

        public ListePage(List<Epargne> comptesEpargne)
        {
            InitializeComponent();
            Comptes = comptesEpargne.ConvertAll(x => (Compte)x);
            Titre = "Liste des comptes epargne";
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            listeDesElements.ItemsSource = Comptes;
        }
    }
}
