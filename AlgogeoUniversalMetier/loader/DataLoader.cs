using AlgogeoMetier.model;
using AlgogeoMetier.model.questionsreponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgogeoMetier.xml
{
    public abstract class DataLoader
    {
        public abstract List<Chapitre> loadChapitres();
        public abstract List<Question> loadQuestionnaires();
        public abstract void saveData();

        public abstract Task<bool> SaveChapitres(List<Chapitre> chap);
    }
}
