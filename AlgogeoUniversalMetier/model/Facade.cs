using AlgogeoMetier.model.events;
using AlgogeoMetier.model.instruction;
using AlgogeoMetier.model.manager;
using AlgogeoMetier.xml;
using System;
using System.Collections.Generic;

namespace AlgogeoMetier.model
{
    /// <summary>
    /// Facade du jeux pour centraliser 
    /// les classes a utiliser vers le VM
    /// </summary>
    public class Facade
    {
        public List<Chapitre> Chapitres { get; set; }

        public event EventHandler<ChapitresChargesEventArgs> ChapitresCharges;

        public Facade()
        {
        }

        public async void LoadChapitre()
        {
            DataLoaderXML loader = new DataLoaderXML();
            Chapitres = await loader.loadChapireFromFile();
            OnChapitreCharges();
        }

        /// <summary>
        /// Event quand les chapitres sont chargé
        /// </summary>
        public void OnChapitreCharges()
        {
            if (ChapitresCharges != null)
            {
                ChapitresCharges(this, new ChapitresChargesEventArgs(Chapitres));
            }
        }

        public async void SaveChapitre()
        {
            await new DataLoaderXML().SaveChapitres(Chapitres);
        }
    }
}
