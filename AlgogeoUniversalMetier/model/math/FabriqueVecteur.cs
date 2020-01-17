using AlgogeoMetier.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgogeoMetier.model.math
{
    public abstract class FabriqueVecteur
    {
        /// <summary>
        /// Retourne un vecteur suivant le type du niveau
        /// </summary>
        /// <param name="type">Type du niveau</param>
        /// <param name="origine">Origine du vecteur</param>
        /// <param name="image">Image du vecteur</param>
        /// <returns>Le vecteur créer</returns>
        public static IVecteur getVecteur(Niveau.TypeNiveau type, Point origine, Point image)
        {
            switch (type)
            {
                case Niveau.TypeNiveau.NIV2D:
                    return new Vecteur2((Point2D)origine, (Point2D)image);
                default:
                    throw new FabriqueException("Le type de vecteurs donné n'existe pas");
            }
        }
    }
}
