using AlgogeoMetier.model.math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgogeoUniversalMetier.model.math
{
    public class FabriqueVecteurDessinForme
    {
        public static Vecteur2 CreateVecteur(IVecteur vect)
        {
            if (vect is Vecteur2)
            {
                return vect as Vecteur2;
            }
            else
            {
                throw new NotImplementedException("Not implemented function for others vectors");
            }
        }
    }
}
