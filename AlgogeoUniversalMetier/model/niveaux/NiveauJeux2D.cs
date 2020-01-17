using AlgogeoMetier.model.instruction;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AlgogeoMetier.model.niveaux
{
    [DataContract]
    public sealed class NiveauJeux2D : NiveauJeux
    {
        /// <summary>
        /// Constructeur de la classe NiveauJeux2D
        /// </summary>
        /// <param name="nom">Nom du niveau</param>
        /// <param name="ins">Instruction du niveau</param>
        /// <param name="nbMin">Nombre minimum d'instructions</param>
        /// <param name="nbMax">Nombre maximum d'instructions</param>
        /// <param name="estTermine">Vra si le niveau est terminé, faux sinon</param>
        /// <param name="forme">Forme du niveau</param>
        public NiveauJeux2D(string nom, List<Instruction> ins, uint nbMin, uint nbMax, bool estTermine, Forme forme)
            :base(nom, ins, nbMin, nbMax, estTermine)
        {
            Forme = forme;
            Type = TypeNiveau.NIV2D;
        }

        /// <summary>
        /// Permet d'afficher un NiveauJeux2D
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Instruction ins in InstructionsDisponibles)
            {
                sb.Append(ins);
            }
            return "\nNom du niveau = " + Nom
                + "\n]\nNombre d'instructions min = " + NombreInstructionMin
                + "\nNombre d'instructions max = " + NombreInstructionMax
                + "\nForme [" + Forme + " ]\n";
        }

        public NiveauJeux2D()
        {

        }
    }
}
