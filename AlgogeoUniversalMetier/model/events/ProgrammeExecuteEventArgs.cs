using System;

namespace AlgogeoMetier.model.events
{
    /// <summary>
    /// Arguement de l'évent programme executé
    /// </summary>
    public class ProgrammeExecuteEventArgs : EventArgs
    {
        public double FormePercentSame { get; set;  }

        public ProgrammeExecuteEventArgs(double percent)
        {
            FormePercentSame = percent;
        }
    }
}