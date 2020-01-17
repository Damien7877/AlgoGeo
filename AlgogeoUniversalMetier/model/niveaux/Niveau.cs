using AlgogeoMetier.model;
using AlgogeoMetier.model.instruction;
using AlgogeoMetier.model.math;
using AlgogeoMetier.model.niveaux;
using AlgogeoUniversalMetier.model.math;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace AlgogeoMetier.model
{
    /// <summary>
    /// Représente un niveau abstrait
    /// </summary>
    /// 
    [DataContract]
    [KnownType(typeof(NiveauJeux))]
    [KnownType(typeof(NiveauJeux2D))]
    [XmlInclude(typeof(NiveauJeux2D))]
    public abstract class Niveau
    {
        /// <summary>
        /// Enumération pour savoir le type de niveau
        /// </summary>
        /// 

        public enum TypeNiveau { NIV2D, NONE };

        /// <summary>
        /// Nom du niveau
        /// </summary>
        /// 
        [DataMember]
        public string Nom { get; set; }

        /// <summary>
        /// Permet de savoir si le niveau a été terminé
        /// </summary>
        /// 
        [DataMember]
        public bool EstTermine { get; set; }

        /// <summary>
        /// Liste des instructions du niveau
        /// </summary>
        /// 
        [DataMember]
        public List<Instruction> InstructionsDisponibles { get; set; }

        /// <summary>
        /// Type du niveau
        /// </summary>
        /// 
        [DataMember]
        public TypeNiveau Type { get; set; }

        public IReadOnlyCollection<Instruction> Instructions
        {
            get
            {
                return InstructionsDisponibles;
            }
        }

        /// <summary>
        /// Forme du niveau
        /// </summary>
        /// 
        [DataMember]
        public Forme Forme { get; set; }

        /// <summary>
        /// Constructeur de la classe Niveau
        /// </summary>
        /// <param name="nom">Nom du niveau</param>
        /// <param name="ins">Instructions du niveau</param>
        public Niveau(string nom, List<Instruction> ins)
        {
            Nom = nom;
            InstructionsDisponibles = ins;
        }

        public Niveau()
        {

        }

        /// <summary>
        /// Permet d'afficher la classe Niveau
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Nom = " + Nom + " | Instructions = " + InstructionsDisponibles;
        }

        public List<Vecteur2> DessineFormeVecteur2()
        {
            List<Vecteur2> dessin = new List<Vecteur2>();
            foreach(IVecteur vect in Forme.Segments) {
                dessin.Add(FabriqueVecteurDessinForme.CreateVecteur(vect));
            }
            return dessin;
        }
    }
}