using AlgogeoMetier.model.instruction;
using System.Collections.Generic;

namespace AlgogeoMetier.model.niveaux
{
    public sealed class NiveauLibre2D : NiveauLibre
    {
        public NiveauLibre2D(string nom, List<Instruction> ins) 
            :base(nom, ins)
        {
            Type = TypeNiveau.NIV2D;
        }

    }
}
