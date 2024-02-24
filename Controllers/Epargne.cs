using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurATM.Controllers
{
    public class Epargne : Compte
    {
        static float TAUX_INTERETS = 0.0125f;
        public string ImagePath { get; set; }

        public Epargne(string numeroNIP, string numeroCompte, float soldeCompte)
            : base(numeroNIP, numeroCompte, soldeCompte)
        {
            ImagePath = "epargne.png";
        }

        public void PaiementInterets()
        {
            soldeCompte += soldeCompte * TAUX_INTERETS;
        }

        public string DisplayInfo => $"Numero de compte: {getNumeroCompte()}, Solde du compte: {getSoldeCompte()}";
    }
}
