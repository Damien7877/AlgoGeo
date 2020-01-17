using AlgogeoUniversalMetier.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AlgogeoMetier.model.instruction
{
    /// <summary>
    /// Une instruction composée est une liste d'instruction pour faire des boucles 
    /// </summary>
    [DataContract]
    public class InstructionComposee : Instruction
    {
        [DataMember]
        public List<Instruction> mInstructionsFilles;

        public IReadOnlyCollection<Instruction> Instructions
        {
            get
            {
                return mInstructionsFilles;
            }
        }

        public InstructionComposee(string libelle, uint repetition, List<Instruction> instructions)
            : base(libelle, repetition)
        {
            mInstructionsFilles = instructions;
        }

        public InstructionComposee()
        {

        }

        public override Instruction Clone()
        {
            return new InstructionComposee()
            {
                Libelle = this.Libelle,
                Repetitions = this.Repetitions,
                mInstructionsFilles = this.mInstructionsFilles.Select((i) => i.Clone()).ToList()
            };
        }
    }
}
