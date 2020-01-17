using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlgogeoMetier.model.math
{
    public interface IVecteur
    {
        /// <summary>
        /// Calcul la norme d'un vecteur
        /// </summary>
         double Norme { get; }


        bool Equals(IVecteur vect2);
    }
}
