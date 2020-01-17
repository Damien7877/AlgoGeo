using AlgogeoMetier.model;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using AlgogeoMetier.model.questionsreponses;
using System.Linq;
using AlgogeoMetier.model.niveaux;
using AlgogeoMetier.model.instruction;
using AlgogeoMetier.model.math;
using System.Xml.Serialization;
using System.IO;
using Windows.Storage.Streams;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AlgogeoMetier.xml
{
    public class DataLoaderXML : DataLoader
    {

        const string fileName = "Chapitres_1_.xml";

        public async Task<bool> IsFilePresent(string fileName)
        {
            var item = await Windows.Storage.ApplicationData.Current.LocalFolder.TryGetItemAsync(fileName);
            return item != null;
        }

        public async Task<List<Chapitre>> loadChapireFromFile()
        {
            Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile saveFile;

            if (await IsFilePresent(fileName))
            {
                saveFile =
                    await storageFolder.GetFileAsync(fileName);
            }
            else
            {
                await defaultLevels();
                saveFile =
                    await storageFolder.GetFileAsync(fileName);
            }
            string text = await Windows.Storage.FileIO.ReadTextAsync(saveFile);
            StringReader reader = new StringReader(text);
            XmlSerializer ser = new XmlSerializer(typeof(List<Chapitre>));
            List<Chapitre> chapitres = null;
            chapitres = (List<Chapitre>)ser.Deserialize(reader);
            reader.Dispose();

            return chapitres;

        }

        public override List<Chapitre> loadChapitres()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> defaultLevels()
        {
            List<Chapitre> chapitres = new List<Chapitre>();
            Chapitre chap;
            string nom = "Chapitre 1";
            List<Niveau> lesNiveaux = new List<Niveau>();



            lesNiveaux.Add(new NiveauJeux2D(
                "1 - Carré",
                new List<Instruction> {
                   new InstructionSimple("Tourner 90°", new Etat(90), 1),
                   new InstructionSimple("Avancer", new Etat(new Point2D(1.0, 0.0)), 1)
                },
                7,
                12,
                false,
                new Forme(new List<IVecteur>
                {
                    new Vecteur2(new Point2D(0.0, 0.0), new Point2D(1.0, 0.0)),
                    new Vecteur2(new Point2D(1.0, 0.0), new Point2D(1.0, 1.0)),
                    new Vecteur2(new Point2D(1.0, 1.0), new Point2D(0.0, 1.0)),
                    new Vecteur2(new Point2D(0.0, 1.0), new Point2D(0.0, 0.0))
                })
            ));

            lesNiveaux.Add(new NiveauJeux2D(
                    "3 - Triangle",
                    new List<Instruction> {
                   new InstructionSimple("Tourner 90°", new Etat(90), 1),
                   new InstructionSimple("Tourner 45°", new Etat(45), 1),
                   new InstructionSimple("Avancer", new Etat(new Point2D(1.0, 0.0)), 1)
                    },
                    7,
                    12,
                    false,
                    new Forme(new List<IVecteur>
                    {
                    new Vecteur2(new Point2D(0.0, 0.0), new Point2D(1.0, 0.0)),
                    new Vecteur2(new Point2D(1.0, 0.0), new Point2D(1.0, 1.0)),
                    new Vecteur2(new Point2D(1.0, 1.0), new Point2D(0.0, 0.0)),
            })
            ));

            chap = new Chapitre(nom, lesNiveaux);
            chapitres.Add(chap);
            return await SaveChapitres(chapitres);
        }

        public override List<Question> loadQuestionnaires()
        {
            List<Question> listeQuestions = new List<Question>();

            string path = "./../../XML/";
            XDocument fichierQuestionnaire = XDocument.Load(path + "QuestionnaireFake.xml");

            listeQuestions = fichierQuestionnaire.Descendants("question")

                // On créé une nouvelle question
                .Select(question => new Question()
                {
                    Libelle = question.Element("libelle").Value,

                    // On créé la liste de réponse en parcourant les réponses de la question
                    Reponses = question.Descendants("reponse")
                        .Select(reponse => new Reponse()
                        {
                            Libelle = reponse.Element("libelle").Value,
                            IsGoodAnswer = reponse.Element("bonneReponse").Value == "true" ? true : false
                        }).ToList()

                }).ToList();

            return listeQuestions;
        }

        public override async Task<bool> SaveChapitres(List<Chapitre> chap)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Chapitre>));
            Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;

            Windows.Storage.StorageFile sampleFile =
                await storageFolder.CreateFileAsync(fileName,
        Windows.Storage.CreationCollisionOption.ReplaceExisting);

            StringWriter stringWriter = new StringWriter();

            ser.Serialize(stringWriter, chap);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, stringWriter.ToString());
            return true;
        }

        public override void saveData()
        {

        }
    }
}
