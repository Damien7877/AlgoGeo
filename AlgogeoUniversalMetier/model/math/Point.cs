using System;
using System.Runtime.Serialization;

namespace AlgogeoMetier.model.math
{
    /// <summary>
    /// Cette interface permet de marquer les classes Points
    /// </summary>

    public interface Point
    {
        bool Equals(Point other);
        string ToString();

        /// <summary>
        /// Effectue une rotation dans le plan
        /// </summary>
        /// <param name="angle">Angle de la rotation</param>
        /// <returns>Le nouveau point avec la rotation</returns>
        Point Rotate(double angle);

        /// <summary>
        /// Effectue l'addition de deux points
        /// </summary>
        /// <param name="other">L'autre point a additionner</param>
        /// <returns>Le nouveau point avec le résultat</returns>
        Point Add(Point other);
    }

    /// <summary>
    /// Cette structure définie un Point2D 
    /// Un Point2D a des coordonnées cartésiennes (X, Y)
    /// </summary>
    [DataContract]
    public struct Point2D : Point
    {
        [DataMember]
        public double X { get; set; }
        [DataMember]
        public double Y { get; set; }

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }


        public bool Equals(Point other)
        {
            if (other == null)
                return false;
            return ((Point2D)other).X == this.X && ((Point2D)other).Y == this.Y;
        }

        public static Point2D operator -(Point2D p1, Point2D p2)
        {
            Point2D res = new Point2D();
            res.X = p1.X - p2.X;
            res.Y = p1.Y - p2.Y;
            return res;
        }

        public override string ToString()
        {
            return "Point2D : " + X + ", " + Y;
        }

        public Point Rotate(double angle)
        {
            Point2D point = new Point2D();
            double angleInRad = angle * Math.PI / 180.0f;
            point.X = Math.Round(X * Math.Cos(angleInRad) - Y * Math.Sin(angleInRad));
            point.Y = Math.Round(X * Math.Sin(angleInRad) + Y * Math.Cos(angleInRad));

            return point;
        }

        public Point Add(Point other)
        {
            Point2D res = new Point2D();
            Point2D p2 = (Point2D)other;
            res.X = this.X + p2.X;
            res.Y = this.Y + p2.Y;
            return res;
        }
    }

    /// <summary>
    /// Cette structure définie un Point3D 
    /// Un Point2D a des coordonnées cartésiennes (X, Y, Z)
    /// </summary>
    public struct Point3D : Point
    {
        public double X;
        public double Y;
        public double Z;

        public Point3D(double x, double y , double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point Add(Point imageRotation)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Point other)
        {
            throw new NotImplementedException();
        }

        public Point Rotate(double angle)
        {
            throw new NotImplementedException();
        }
    }
}
