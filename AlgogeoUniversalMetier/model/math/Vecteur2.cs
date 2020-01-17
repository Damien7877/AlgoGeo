using System;
using System.Runtime.Serialization;

namespace AlgogeoMetier.model.math
{
    /// <summary>
    /// Un vecteur2 est un vecteur avec une origine et une image en Points 2D
    /// </summary>
    /// 
    [DataContract]
    public class Vecteur2 : Vecteur<Point2D>
    {
        public Vecteur2(Point2D origine, Point2D image)
        {
            Origine = origine;
            Image = image;
        }

        public Vecteur2()
        {

        }

        public override double Norme
        {
            get
            {
                double res;
                res = Math.Pow(Image.X - Origine.X, 2);
                res += Math.Pow(Image.Y - Origine.Y, 2);
                return Math.Sqrt(res);
            }
        }

        public override double AngleBetweenVectors(Vecteur<Point2D> vect)
        {
            return Math.Acos(dot(vect));
        }

        public double dot(Vecteur<Point2D> vect)
        {
            Point2D vectCoordA = Image - Origine;
            Point2D vectCoordB = vect.Image - vect.Origine;

            return vectCoordA.X * vectCoordA.Y + vectCoordB.X * vectCoordB.Y;
        }

        public override bool Equals(IVecteur vect2)
        {
            return Equals((Vecteur2)vect2);
        }

        public override bool Equals(Vecteur<Point2D> vect2)
        {
            if (vect2 == null)
                return false;
            return vect2.Image.Equals(Image) && vect2.Origine.Equals(Origine) ||
                  vect2.Image.Equals(Origine) && vect2.Origine.Equals(Image);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Vecteur2);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "\tVecteur : " + Origine + " -> " + Image + "\n";
        }
    }
}
