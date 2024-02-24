using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurATM.Controllers
{
    public class Cheque : Compte
    {
        public string ImagePath { get; set; }
        public Cheque(string numeroNIP, string numeroCompte, float soldeCompte) : base(numeroNIP, numeroCompte, soldeCompte) 
        {
            ImagePath = "cheque.jpg";
        }

        public string DisplayInfo => $"Numero de compte: {getNumeroCompte()}, Solde du compte: {getSoldeCompte()}";

    }
}
