using AlgogeoMetier.model.instruction;
using System;

namespace AlgogeoMetier.model.events
{
    /// <summary>
    /// Arguments de l'event Instruction Executé
    /// </summary>
    public class InstructionExecuteEventArgs : EventArgs
    {
        public Etat EtatFinal { get; set; }

        public InstructionExecuteEventArgs(Etat etatFinal)
        {
            EtatFinal = new Etat(etatFinal);
        }
    }
}