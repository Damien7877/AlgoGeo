using AlgogeoMetier.model.instruction;
using System.Collections.Generic;

namespace AlgogeoMetier.model
{
    public abstract class NiveauLibre : Niveau
    {
        public NiveauLibre(string nom, List<Instruction> ins)
            :base(nom, ins)
        {

        }
    }
}
