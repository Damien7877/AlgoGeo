using AlgogeoUniversalMetier.model;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System;

namespace AlgogeoMetier.model.instruction
{
    /// <summary>
    /// représente une instruction
    /// C'est un conteneur qui a un libellé et un nombre de répétitions
    /// </summary>
    [DataContract]
    [KnownType(typeof(InstructionComposee))]
    [KnownType(typeof(InstructionSimple))]
    [XmlInclude(typeof(InstructionComposee))]
    [XmlInclude(typeof(InstructionSimple))]
    public abstract class Instruction : ICloneable<Instruction>
    {
        [DataMember]
        public string Libelle { get; set; }

        [DataMember]
        public uint Repetitions { get; set; }

        public Instruction(string libelle, uint repetitions)
        {
            Libelle = libelle;
            Repetitions = repetitions;
        }

        public Instruction()
        {
            Repetitions = 0;
        }

        public override string ToString()
        {
            return "Instruction : " + Libelle;
        }

        public abstract Instruction Clone();
    }
}