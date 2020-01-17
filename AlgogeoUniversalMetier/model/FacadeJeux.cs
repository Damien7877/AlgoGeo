using AlgogeoMetier.model;
using AlgogeoMetier.model.events;
using AlgogeoMetier.model.instruction;
using AlgogeoMetier.model.manager;
using AlgogeoMetier.model.math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgogeoUniversalMetier
{
    public class FacadeJeux
    {
        public JeuxManager Manager { get; set; }

        private Executeur mExecuteur;

        public FacadeJeux(Niveau niveau)
        {
            Manager = new JeuxManager(niveau);
            mExecuteur = new ExecuteurSimple(Manager.JoueurEnCours, Manager.NiveauEnCours, Manager.FormeEnCours);
            mExecuteur.InstructionExecute += OnInstructionExecuted;
        }

        public event EventHandler<ProgrammeExecuteEventArgs> ProgrammeExecute;
        public event EventHandler<InstructionExecuteEventArgs> InstructionExecute;

        /// <summary>
        /// Execute toutes les instructions
        /// </summary>
        public void ExecuterProgramme()
        {
            //Remet a zero l'état du joueur pour la prochaine execution
            Manager.JoueurEnCours.EtatJoueur = new Etat(new Point2D()) { Crayon = Etat.EtatCrayon.BAISSER };
            mExecuteur.ExecuterProgramme();
            OnProgrammeExecute(Manager.NiveauEnCours.Forme.GetSamePercent(Manager.FormeEnCours));
        }

        /// <summary>
        /// Event quand le programme est fini d'executé
        /// </summary>
        /// <param name="percent">Pourcentage de ressemblance des formes</param>
        public void OnProgrammeExecute(double percent)
        {
            if (ProgrammeExecute != null)
            {
                ProgrammeExecute(this, new ProgrammeExecuteEventArgs(percent));
            }
        }

        /// <summary>
        /// Permet de notifier que l'état a changé
        /// </summary>
        /// <param name="etatFinal">l'état final du jeux</param>
        public void OnInstructionExecute(Etat etatFinal)
        {
            if (InstructionExecute != null)
            {
                InstructionExecute(this, new InstructionExecuteEventArgs(etatFinal));
            }
        }

        /// <summary>
        /// Repercute l'event de l'executeur vers la VM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnInstructionExecuted(object sender, InstructionExecuteEventArgs args)
        {
            OnInstructionExecute(args.EtatFinal);
        }
    }
}
