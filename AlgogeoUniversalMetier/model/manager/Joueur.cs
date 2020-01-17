using AlgogeoMetier.model.instruction;
using System.Collections.Generic;

namespace AlgogeoMetier.model
{
    /// <summary>
    /// Représentation d'un joueur
    /// </summary>
    public class Joueur
    {
        private List<Instruction> mInstructions;

        public Etat EtatJoueur
        {
            get; set;
        }

        public List<Instruction> Intructions
        {
            get
            {
                return mInstructions;
            }
        }

        public Joueur(List<Instruction> ins,  Etat etat)
        {
            mInstructions = ins;
            EtatJoueur = etat;
            EtatJoueur.Crayon = Etat.EtatCrayon.BAISSER;
        }

    }
}
