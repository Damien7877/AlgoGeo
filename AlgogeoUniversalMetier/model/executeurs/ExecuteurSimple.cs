using AlgogeoMetier.model.instruction;
using AlgogeoMetier.model.math;
using System.Collections.Generic;

namespace AlgogeoMetier.model.manager
{
    /// <summary>
    /// Permet d'executer des instructions 
    /// </summary>
    public sealed class ExecuteurSimple : Executeur
    {
        private Niveau niveauEnCours;

        public ExecuteurSimple(Joueur joueurEnCours, Niveau niveauEnCours, Forme formeEnCours)
        {
            JoueurEnCours = joueurEnCours;
            this.niveauEnCours = niveauEnCours;
            this.FormeEnCours = formeEnCours;
        }

        /// <summary>
        /// Execute toutes les instructions et à la fin
        /// renvoi un event avec l'état initial du joueur et l'état final
        /// </summary>
        public override void ExecuterProgramme()
        {
            FormeEnCours.Clear();
            ExecuteInstructions(JoueurEnCours.Intructions);
        }

        protected override void ExecuteInstructions(IReadOnlyCollection<Instruction> instruction)
        {
            foreach (Instruction inst in instruction)
            {
                for (int i = 0; i < inst.Repetitions; ++i)
                {
                    if (inst is InstructionSimple)
                    {
                        ExecuteInstructionSimple((InstructionSimple)inst);
                    }
                    else
                    {
                        ExecuteInstructions(((InstructionComposee)inst).Instructions);
                    }
                    OnInstructionExecute(JoueurEnCours.EtatJoueur);
                }
            }
        }

        protected override void ExecuteInstructionSimple(InstructionSimple instruction)
        {
            JoueurEnCours.EtatJoueur.Angle += instruction.EtatFinal.Angle;
            JoueurEnCours.EtatJoueur.Angle = JoueurEnCours.EtatJoueur.Angle % 360.0;
            if (instruction.EtatFinal.Crayon != Etat.EtatCrayon.SAME)
                JoueurEnCours.EtatJoueur.Crayon = instruction.EtatFinal.Crayon;


            if (instruction.EtatFinal.Position != null)
            {
                Point position = instruction.EtatFinal.Position;
                Point imageRotation = position.Rotate(JoueurEnCours.EtatJoueur.Angle);

                Point positionJoueur = JoueurEnCours.EtatJoueur.Position;
                Point image = positionJoueur.Add(imageRotation);

                if (JoueurEnCours.EtatJoueur.Crayon == Etat.EtatCrayon.BAISSER)
                {
                    IVecteur vect = FabriqueVecteur.getVecteur(niveauEnCours.Type, JoueurEnCours.EtatJoueur.Position, image);
                    FormeEnCours.Add(vect);
                }
                JoueurEnCours.EtatJoueur.Position = image;
            }
        }
    }
}