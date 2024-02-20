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
        public Cheque(string numeroNIP, string numeroCompte, float soldeCompte) : base(numeroNIP, numeroCompte, soldeCompte) { }
    }
}
