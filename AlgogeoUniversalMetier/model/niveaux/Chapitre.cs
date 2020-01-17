using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AlgogeoMetier.model
{
    /// <summary>
    /// Classe Chapitre
    /// </summary>
    [DataContract]
    public class Chapitre
    {
        /// <summary>
        /// Nom du chapitre
        /// </summary>
        /// 
        [DataMember]
        public string Nom { get; set; }

        /// <summary>
        /// Niveaux attribués au chapitre
        /// </summary>
        /// 
        [DataMember]
        public List<Niveau> Niveaux { get; set; }

        /// <summary>
        /// Constructeur de la classe Chapitre
        /// </summary>
        /// <param name="nom">Nom du chapitre</param>
        /// <param name="niveaux">Liste de niveaux qui va être attribuée au chapitre</param>
        public Chapitre(string nom, List<Niveau> niveaux)
        {
            Nom = nom;
            Niveaux = niveaux;
        }

        public Chapitre()
        {

        }

        /// <summary>
        /// Permet d'afficher la classe chapitre
        /// </summary>
        /// <returns>La représentation de la classe Chapitre sous chaîne de caractère</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Niveau n in Niveaux)
            {
                sb.Append(n);
            }
            return "Nom = " + Nom + "\nNiveaux [ " + sb + " ]";
        }
    }
}
