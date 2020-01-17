using AlgogeoMetier.model.events;
using AlgogeoMetier.model.instruction;
using System;
using System.Collections.Generic;

namespace AlgogeoMetier.model.manager
{
    public abstract class Executeur
    {
        public event EventHandler<InstructionExecuteEventArgs> InstructionExecute;

        protected Joueur JoueurEnCours { get; set; }
        protected Forme FormeEnCours { get; set; }

        public abstract void ExecuterProgramme();

        /// <summary>
        /// Permet l'execution de toutes les instructions
        /// </summary>
        /// <param name="instruction">Instructions a executer</param>
        protected abstract void ExecuteInstructions(IReadOnlyCollection<Instruction> instruction);

        /// <summary>
        /// Execute une instruction simple
        /// </summary>
        /// <param name="instruction">Instruction a executer</param>
        protected abstract void ExecuteInstructionSimple(InstructionSimple instruction);

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
    }
}
