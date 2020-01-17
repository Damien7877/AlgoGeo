using AlgogeoMetier.model;
using AlgogeoMvvm;
using AlgogeoPresentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgogeoPresentation.ViewModels
{
    public class FinishGameViewModel : PageViewModel
    {

        private String _title;
        private double _percent;
        private Boolean _isFinished;

        private Niveau _niveau;
        private Facade _facade;

        public String Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(() => Title);
            }
        }

        public double Percent
        {
            get { return _percent; }
            set
            {
                _percent = value;
                OnPropertyChanged(() => Percent);
            }
        }
        public Boolean IsFinished
        {
            get { return _isFinished; }
            set
            {
                _isFinished = value;
                OnPropertyChanged(() => IsFinished);
            }
        }

        public DelegateCommand RestartCommand { get; private set; }
        public DelegateCommand OkCommand { get; private set; }


        public override void InitializeCommands()
        {
            RestartCommand = new DelegateCommand((obj) =>
            {
                GoBack();
            });
            OkCommand = new DelegateCommand((obj) =>
            {
                Navigate(typeof(ListeChapitresView));
            });
        }

        public override void InitializeData()
        {
        }

        public override void InitializeEvents()
        {
        }

        internal void OnNavigateTo(IDictionary<string, object> dictionary)
        {
            _niveau = dictionary["niveau"] as Niveau;
            Title = _niveau.Nom;
            Percent = (double)dictionary["percent"];
            IsFinished = Percent == 1 ;
           
            _facade = dictionary["facade"] as Facade;
            SaveLevel(_niveau);
        }

        private void SaveLevel(Niveau niveau)
        {
            _facade.SaveChapitre();
        }
    }
}
