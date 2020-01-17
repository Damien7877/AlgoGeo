namespace AlgogeoMetier.model.questionsreponses
{
    /// <summary>
    /// Classe réponse qui va servir pour le questionnaire
    /// </summary>
    public class Reponse
    {
        /// <summary>
        /// Nom de la réponse
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Booléen pour savoir si la réponse est bonne ou non
        /// </summary>
        public bool IsGoodAnswer { get; set; }

        /// <summary>
        /// Constructeur de la classe Reponse
        /// </summary>
        /// <param name="lib">Nom de la réponse</param>
        /// <param name="isGoodAnswer">Vrai si la réponse est bonne, faux sinon</param>
        public Reponse(string lib, bool isGoodAnswer)
        {
            Libelle = lib;
            IsGoodAnswer = isGoodAnswer;
        }

        /// <summary>
        /// Constructeur par défaut de la classe Reponse
        /// </summary>
        public Reponse()
        {

        }

        /// <summary>
        /// Permet d'afficher la réponse
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "\tLibellé = " + Libelle + "\n\t\tRep = " + IsGoodAnswer;
        }
    }
}