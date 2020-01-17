using AlgogeoMetier.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgogeoMetier.xml
{
    public abstract class DataLoader
    {
        public abstract List<Chapitre> LoadChapitres();
        public abstract void SaveData();

        public abstract Task<bool> SaveChapitres(List<Chapitre> chap);
    }
}
