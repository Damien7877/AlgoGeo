using AlgogeoMetier.model.math;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace AlgogeoMetier.model.instruction
{
    /// <summary>
    /// Cette classe représente un état du joueur
    /// Dans les instructions elle représente un état relatif :
    /// La position finale du joueur sera calculés grâce à la position
    /// Du joueur + la la future position
    /// </summary>
    /// 
    [DataContract]
    public class Etat
    {
        
        public enum EtatCrayon { BAISSER, LEVER, SAME };

        [XmlIgnore]
        public Point Position { get; set; }

        [DataMember]
        [XmlArrayItem("Point2D", typeof(Point2D))]
        [XmlArrayItem("Point3D", typeof(Point3D))]
        public object[] Pos
        {
            get
            {
                return  new object[]{ Position };
            }
            set
            {
                if(value.Length > 0 && value != null)
                    Position = (Point)value[0];
            }
        }

        [DataMember]
        public double Angle { get; set; }
        [DataMember]
        public EtatCrayon Crayon { get; set; } = EtatCrayon.SAME;

        public Etat() { }

        public Etat(EtatCrayon etat)
        {
            Crayon = etat;
        }

        public Etat(Point position)
        {
            Position = position;
        }

        public Etat(double angle)
        {
            Angle = angle;
        }

        public Etat(Etat etatFinal)
        {
            this.Angle = etatFinal.Angle;
            this.Position = etatFinal.Position;
            this.Crayon = etatFinal.Crayon;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Angle : ").Append(Angle).AppendLine();
            sb.Append("Crayon : ").Append(Crayon).AppendLine();
            sb.Append("Position : ").Append(Position).AppendLine();
            return sb.ToString();
        }
    }
}