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

        public Epargne(string numeroNIP, string numeroCompte, float soldeCompte)
            : base(numeroNIP, numeroCompte, soldeCompte)
        {}

        public void PaiementInterets()
        {
            SoldeCompte += SoldeCompte * TAUX_INTERETS;
        }
    }
}
