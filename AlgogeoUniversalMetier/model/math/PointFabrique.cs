using AlgogeoMetier.exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgogeoMetier.model.math
{
    public abstract class PointFabrique
    {
        
        /// <summary>
        /// Renvoie un point suivant le type du niveau en cours
        /// </summary>
        /// <param name="type">Type du niveau</param>
        /// <returns>Le point</returns>
        public static Point getPoint(Niveau.TypeNiveau type)
        {
            switch(type)
            {
                case Niveau.TypeNiveau.NIV2D:
                    return new Point2D();
                default:
                    throw new FabriqueException("Le type de point donné n'existe pas");
            }
        }
    }
}
