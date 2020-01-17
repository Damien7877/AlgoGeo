using AlgogeoMetier.model.instruction;
using System.Collections.Generic;
using AlgogeoMetier.model.math;

namespace AlgogeoMetier.model
{
    public class JeuxManager
    {
        public Joueur JoueurEnCours { get; private set; }
        public Niveau NiveauEnCours { get; set; }
        public Forme FormeEnCours { get; private set; }

        public JeuxManager(Niveau niveau)
        {
            NiveauEnCours = niveau;
            FormeEnCours = new Forme(new List<IVecteur>());
            CreerJoueur();
        }

        public void CreerJoueur()
        {
            if (NiveauEnCours.Type == Niveau.TypeNiveau.NIV2D)
                JoueurEnCours = new Joueur(new List<Instruction>(), new Etat(new Point2D()));
        }
    }
}
