using AlgogeoMetier.model.instruction;
using AlgogeoMetier.model.math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgogeoUniversalMetier.model.math
{
    public class FabriqueVecteurWithState
    {
        public static Vecteur2 CreateVecteur(Etat initial)
        {
            if(initial.Position is Point2D)
            {
                if(initial.Position == null)
                    throw new Exception("La position ne doit pas être nulle!");
                Point2D pos = (Point2D)initial.Position;
                return new Vecteur2(new Point2D { X = 0, Y = 0 }, new Point2D { X = pos.X, Y = pos.Y });
            }
            else
            {
                throw new NotImplementedException("Not implemented function for others vectors");
            }
        }

        public static Vecteur2 CreateVecteur(Etat old, Etat newState)
        {
            if (old.Position is Point2D && newState.Position is Point2D)
            {
                if (old.Position == null || newState.Position == null)
                    throw new Exception("La position ne doit pas être nulle!");
                Point2D pos = (Point2D)old.Position;
                Point2D pos2 = (Point2D)newState.Position;
                return new Vecteur2(new Point2D { X = pos.X, Y = pos.Y }, new Point2D { X = pos2.X, Y = pos2.Y });
            }
            else
            {
                throw new NotImplementedException("Not implemented function for others vectors");
            }
        }

    }
}
