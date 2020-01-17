using AlgogeoMetier.model;
using AlgogeoMetier.model.niveaux;
using AlgogeoMetier.xml;
using AlgogeoMvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AlgogeoPresentation.ViewModels
{
    class ListeNiveauxViewModel : PageViewModel
    {
        #region --- Properties ---
        private List<Niveau> _niveauxJeux;
        private Facade _facade;

        public List<Niveau> NiveauxJeux
        {
            get
            {
                return _niveauxJeux;
            }
            set
            {
                _niveauxJeux = value;
                OnPropertyChanged(() => NiveauxJeux);
            }
        }

        #endregion

        #region --- Commands ---

        public DelegateCommand StartLevelCommand { get; private set; }

        #endregion

        public ListeNiveauxViewModel()
        {


        }

        #region --- Command method ---
        private void OnStartLevelCommand(object obj)
        {
            this.Navigate(typeof(MainPage), new Dictionary<string, object> { { "niveau", obj }, { "facade", _facade } });
        }

        #endregion

        public override void InitializeData()
        {
        }

        public override void InitializeEvents()
        {

        }

        public override void InitializeCommands()
        {
            StartLevelCommand = new DelegateCommand(OnStartLevelCommand);
        }

        public void OnNavigateTo(IDictionary<string, object> param)
        {
            Chapitre chap = (Chapitre)param["niveaux"];
            _facade = (Facade)param["facade"];
            NiveauxJeux = chap.Niveaux;
        }
    }
}
