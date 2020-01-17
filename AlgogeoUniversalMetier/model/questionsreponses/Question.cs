using System.Collections.Generic;
using System.Text;

namespace AlgogeoMetier.model.questionsreponses
{
    /// <summary>
    /// Classe question qui va servir pour le questionnaire
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Nom de la question
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Liste de réponses attribuée à cette question
        /// </summary>
        public List<Reponse> Reponses { get; set; }

        /// <summary>
        /// La bonne réponse de cette question
        /// </summary>
        public Reponse BonneReponse { get; set; }

        /// <summary>
        /// Constructeur de Question
        /// </summary>
        /// <param name="lib">Nom de la question</param>
        /// <param name="rep">Liste de réponses de la question</param>
        public Question(string lib, List<Reponse> rep)
        {
            Libelle = lib;
            Reponses = rep;
            foreach (var reponse in Reponses)
            {
                if (reponse.IsGoodAnswer)
                {
                    BonneReponse = reponse;
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut de Question
        /// </summary>
        public Question()
        {

        }

        /// <summary>
        /// Permet l'affichage de la classe Question
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var rep in Reponses)
            {
                sb.Append(rep).AppendLine();
            }
            return "Nom = " + Libelle + "\nReponses [\n" + sb + "]\n";
        }
    }
}