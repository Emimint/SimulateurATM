using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace SimulateurATM.Controllers
{
    public abstract class Compte
    {
        private string numeroNIP;
        private string numeroCompte;
        private float soldeCompte;

        public Compte(string numeroNIP, string numeroCompte, float soldeCompte)
        {
            this.numeroNIP= numeroNIP;
            this.numeroCompte = numeroCompte;
            this.soldeCompte = soldeCompte;
        }
        public string NumeroNIP { get; set; }
        public string NumeroCompte { get; set; }
        public float SoldeCompte { get; set; }

        public void Retrait(float montant)
        {
            if(montant % 10 != 0)
            {
                throw new Exception("Montant invalide.");
            }

            if (SoldeCompte < montant)
            {
                throw new Exception("Solde insuffisant."); 
            }

            SoldeCompte -= montant;
        }

        public void Depot(float montant)
        {
            SoldeCompte += montant;
        }
    }
}

