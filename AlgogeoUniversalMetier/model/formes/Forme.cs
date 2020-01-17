using AlgogeoMetier.model.math;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace AlgogeoMetier.model
{
    /// <summary>
    /// Une forme est un ensemble de segments (vecteur) d'un type donné
    /// </summary>
    [DataContract]
    public class Forme
    {
        [XmlIgnore]
        public List<IVecteur> segments;

        [DataMember]
        [XmlArrayItem("Vecteur2", typeof(Vecteur2))]
        public object[] XmlSerializeSegments
        {
            get
            {
                return segments.ToArray();
            }
            set
            {
                foreach(object val in value)
                {
                    segments.Add((IVecteur)val);
                }
            }
        }

        public IReadOnlyCollection<IVecteur> Segments
        {
            get { return segments; }
        }
        public Forme(List<IVecteur> segments)
        {
            this.segments = segments;
        }

        /// <summary>
        /// Ajoute un segment a la liste
        /// </summary>
        /// <param name="segment">le segment a ajouter</param>
        public void Add(IVecteur segment)
        {
            segments.Add(segment);
        }

        internal void Clear()
        {
            segments.Clear();
        }

        /// <summary>
        /// Récupère le pourcentage de ressemblance d'une forme avec une autre
        /// </summary>
        /// <param name="forme">la deuxième forme a comparer</param>
        /// <returns>Le pourcentage de ressemblance</returns>
        public double GetSamePercent(Forme forme)
        {
            if (segments.Count == 0)
                return 0;
            int nbSegmentsSame = 0;
            foreach (IVecteur vect in segments)
            {
                if (forme.segments.Contains(vect))
                    nbSegmentsSame++;
            }
            int nbrSegments = Math.Max(segments.Count, forme.segments.Count);
            return (double)nbSegmentsSame / nbrSegments;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var ivecteur in segments)
            {
                sb.Append(ivecteur);
            }
            return "Vecteurs [\n" + sb + "]\n";
        }

        public Forme()
        {
            segments = new List<IVecteur>();
        }
    }
}
