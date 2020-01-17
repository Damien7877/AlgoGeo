using System;
using System.Runtime.Serialization;

namespace AlgogeoMetier.model.math
{
    /// <summary>
    /// Représentation abstraite d'un vecteur
    /// Un vecteur à une origine et une image,
    /// Les classes qui derivent de Vecteur doivent indiquer quel type de point ils utilisent
    /// </summary>
    /// <typeparam name="T">Le type de point qu'utilise le vecteur</typeparam>
    /// 
    [DataContract]
    [KnownType(typeof(Vecteur2))]
    public abstract class Vecteur<T> : IVecteur, IEquatable<Vecteur<T>>
    {
        [DataMember]
        public T Origine { get; set; }
        [DataMember]
        public  T Image { get; set; }

        public abstract double Norme { get; }

        /// <summary>
        /// Calcul l'angle entre les deux vecteurs
        /// </summary>
        /// <param name="vect">Le vecteur avec lequel on calcul l'angle</param>
        /// <returns>l'angle calculé entre les deux vecteurs</returns>
        public abstract double AngleBetweenVectors(Vecteur<T> vect);

        /// <summary>
        /// Test l'égalité entre deux vecteurs
        /// </summary>
        /// <param name="vect2">Le vecteur a comparer</param>
        /// <returns>Vrai s'ils sont égaux, faux sinon</returns>
        public abstract bool Equals(Vecteur<T> vect2);

        public abstract bool Equals(IVecteur vect2);
    }
}
