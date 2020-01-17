using System;
using System.Collections.Generic;

namespace AlgogeoMetier.model.events
{
    /// <summary>
    /// Arguments de l'event chapitres chargés
    /// </summary>
    public  class ChapitresChargesEventArgs : EventArgs
    {
        public List<Chapitre> Chapitres { get; set; }

        public int Count
        {
            get
            {
                return Chapitres.Count;
            }
        }

        public ChapitresChargesEventArgs(List<Chapitre> chapitres)
        {
            Chapitres = chapitres;
        }
    }
}
