using System;
using System.Runtime.Serialization;
using System.Text;

namespace AlgogeoMetier.model.instruction
{
    /// <summary>
    /// Une instruction simple comme : avancer, reculer, ..
    /// Permet de modifier l'état du jeux en cours
    /// </summary>
    /// 
    [DataContract]
    public class InstructionSimple : Instruction
    {
        [DataMember]
        public Etat EtatFinal { get; set; }

        public InstructionSimple(string libelle, Etat etatFinal, uint repetition)
            : base(libelle, repetition)
        {
            EtatFinal = etatFinal;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Intruction : ").Append(Libelle)
                .Append("\n").Append(EtatFinal);
            return sb.ToString();
        }

        public override Instruction Clone()
        {
            return new InstructionSimple()
            {
                EtatFinal = new Etat()
                {
                    Angle = this.EtatFinal.Angle,
                    Crayon = this.EtatFinal.Crayon,
                    Position = this.EtatFinal.Position
                },
                Libelle = this.Libelle,
                Repetitions = this.Repetitions
            };
        }

        public InstructionSimple()
        {

        }
    }
}