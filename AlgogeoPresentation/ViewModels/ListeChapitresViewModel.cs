using AlgogeoMetier.model;
using AlgogeoMvvm;
using AlgogeoPresentation.Views;
using System.Collections.Generic;

namespace AlgogeoPresentation.ViewModels
{
    public class ListeChapitresViewModel : PageViewModel
    {
        private List<Chapitre> _chapitres;
        Facade facade;


        public List<Chapitre> Chapitres
        {
            get
            {
                return _chapitres;
            }
            set
            {
                _chapitres = value;
                OnPropertyChanged(() => Chapitres);
            }
        }

        

        public DelegateCommand StartNiveauxCommand { get; private set; }

        public ListeChapitresViewModel()
        {

        }

        private void OnStartNiveauxCommand(object obj)
        {
            Navigate(typeof(ListeNiveauxView), new Dictionary<string, object> { { "niveaux", obj }, { "facade", facade } });
        }

        public override void InitializeCommands()
        {
            StartNiveauxCommand = new DelegateCommand(OnStartNiveauxCommand);
        }

        public override void InitializeData()
        {
            facade = new Facade();
            facade.ChapitresCharges += Facade_ChapitresCharges;
            facade.LoadChapitre();
        }

        private void Facade_ChapitresCharges(object sender, AlgogeoMetier.model.events.ChapitresChargesEventArgs e)
        {
            Chapitres = facade.Chapitres;
        }

        public override void InitializeEvents()
        {

        }
    }
}
