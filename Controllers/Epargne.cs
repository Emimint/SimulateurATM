using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulateurATM.Controllers
{
    public class Epargne : Compte
    {
        private float tauxInteret;

        public Epargne(string numeroNIP, string numeroCompte, float soldeCompte, float tauxInteret)
            : base(numeroNIP, numeroCompte, soldeCompte)
        {
            this.tauxInteret = tauxInteret;
        }

        public void PaiementInterets()
        {
            SoldeCompte += SoldeCompte * tauxInteret;
        }
    }
}
