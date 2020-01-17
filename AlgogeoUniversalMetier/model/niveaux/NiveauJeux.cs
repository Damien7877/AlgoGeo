using AlgogeoMetier.model.instruction;
using AlgogeoMetier.model.niveaux;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace AlgogeoMetier.model
{
    /// <summary>
    /// Représente un niveau de jeux
    /// </summary>
    /// 
    [DataContract]
    [KnownType(typeof(NiveauJeux2D))]
    [XmlInclude(typeof(NiveauJeux2D))]
    public abstract class NiveauJeux : Niveau
    {
        /// <summary>
        /// Nombre d'instruction minimum nécessaire pour finir le niveau
        /// </summary>
        /// 
        [DataMember]
        public uint NombreInstructionMin { get; set; }

        /// <summary>
        /// Nombre d'instruction maximum autorisé pour finir le niveau
        /// </summary>
        /// 
        [DataMember]
        public uint NombreInstructionMax { get; set; }

        /// <summary>
        /// Constructeur de la classe NiveauJeux
        /// </summary>
        /// <param name="nom">Nom du niveau</param>
        /// <param name="ins">Instruction du niveau</param>
        /// <param name="nbMin">Nombre d'instructions minimum</param>
        /// <param name="nbMax">Nombre d'instructions maximum</param>
        /// <param name="estTermine">Vrai si le niveau est terminé, faux sinon</param>
        public NiveauJeux(string nom, List<Instruction> ins, uint nbMin, uint nbMax, bool estTermine) :base(nom, ins)
        {
            NombreInstructionMin = nbMin;
            NombreInstructionMax = nbMax;
            EstTermine = estTermine;
        }

        public NiveauJeux()
        {

        }
    }
}