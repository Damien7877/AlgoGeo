using AlgogeoMetier.model;
using AlgogeoMetier.model.events;
using AlgogeoMetier.model.instruction;
using AlgogeoMetier.model.math;
using AlgogeoMvvm;
using AlgogeoPresentation.Models;
using AlgogeoPresentation.Views;
using AlgogeoUniversalMetier;
using AlgogeoUniversalMetier.model.math;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AlgogeoPresentation.ViewModels
{
    public class MainWindowViewModel : PageViewModel
    {
        private FacadeJeux _manager;
        public Instruction _selectedInstruction;
        private ObservableCollection<Instruction> _programme = new ObservableCollection<Instruction>();

        private Queue<Etat> _points = new Queue<Etat>();
        private ObservableCollection<Vecteur2> _pointsToDisplay = new ObservableCollection<Vecteur2>();

        private DispatcherTimer _timerDisplay = new DispatcherTimer();

        private Etat _lastState;

        private DisplayModeEnum _displayMode = DisplayModeEnum.MODELE;
        private double _percent;

        private int _currentExecutingProgram;
        private Facade _facade;

        public int CurrentExecutingProgram
        {
            get { return _currentExecutingProgram; }
            set
            { 
                _currentExecutingProgram = value;
                OnPropertyChanged(() => CurrentExecutingProgram);
            }
        }

        public DisplayModeEnum DisplayMode
        {
            get { return _displayMode; }
            set
            {
                _displayMode = value;
                OnPropertyChanged(() => DisplayMode);
            }
        }

        public ObservableCollection<Vecteur2> PointsToDisplay
        {
            get { return _pointsToDisplay; }
            set
            {
                _pointsToDisplay = value;
                OnPropertyChanged(() => PointsToDisplay);
            }
        }

        public FacadeJeux Manager
        {
            get { return _manager; }
            set
            {
                _manager = value;
                OnPropertyChanged(() => Manager);
            }
        }

        public ObservableCollection<Instruction> Programme
        {
            get { return _programme; }
            set
            {
                _programme = value;
                OnPropertyChanged(() => Programme);
            }
        }

        public Instruction SelectedInstruction
        {
            get { return _selectedInstruction; }
            set
            {
                _selectedInstruction = value;
                OnPropertyChanged(() => SelectedInstruction);
            }
        }

        public DelegateCommand PlayCommand { get; private set; }
        public DelegateCommand ClickedIntructionCommand { get; private set; }
        public DelegateCommand DeleteInstructionCommand { get; private set; }

        public MainWindowViewModel()
        {

        }

        public override void InitializeData()
        {

        }

        public override void InitializeEvents()
        {

            _timerDisplay.Interval = TimeSpan.FromMilliseconds(1000);

            _timerDisplay.Tick += _timerDisplay_Tick;
        }

        private void NavigateToFinish()
        {
            DispatcherTimer timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromMilliseconds(2000)
            };
            timer.Tick += (s, ev) =>
            {
                timer.Stop();
                Navigate(typeof(FinishGameView), new Dictionary<string, object>
                    {
                        { "niveau", Manager.Manager.NiveauEnCours },
                        { "percent", _percent },
                        { "facade", _facade }
                    });

            };
            timer.Start();
        }

        private void _timerDisplay_Tick(object sender, object e)
        {
            if (_points.Count() == 0)
            {
                DisplayMode = DisplayModeEnum.MODELE;
                _timerDisplay.Stop();
                NavigateToFinish();
            }
            else
            {
                CurrentExecutingProgram++;
                if (PointsToDisplay.Count() == 0)
                { 
                    _lastState = _points.Peek();
                    PointsToDisplay.Add(FabriqueVecteurWithState.CreateVecteur(_points.Dequeue()));
                }
                else
                {
                    var _nextPoint = _points.Dequeue();
                    if (_lastState.Position != _nextPoint.Position && _lastState.Crayon == Etat.EtatCrayon.BAISSER)
                    {
                        PointsToDisplay.Add(FabriqueVecteurWithState.CreateVecteur(_lastState, _nextPoint));

                    }
                    _lastState = _nextPoint;
                }
                Programme.RemoveAt(0);
            }

        }

        public override void InitializeCommands()
        {
            PlayCommand = new DelegateCommand(OnPlayCommand, (o) => DisplayMode == DisplayModeEnum.MODELE);
            ClickedIntructionCommand = new DelegateCommand(OnClickedIntructionCommand, (o) => DisplayMode == DisplayModeEnum.MODELE);
            DeleteInstructionCommand = new DelegateCommand(OnDeleteInstructionCommand);
        }

        private void OnDeleteInstructionCommand(object obj)
        {
            var instDelete = obj as Instruction;
            Programme.Remove(instDelete);
        }

        private void OnClickedIntructionCommand(object obj)
        {
            if(_selectedInstruction != null)
                Programme.Add(_selectedInstruction.Clone());
        }

        public void OnPlayCommand(object obj)
        {

            _points.Clear();
            Manager.Manager.JoueurEnCours.Intructions.Clear();
            Manager.Manager.JoueurEnCours.Intructions.AddRange(Programme);
            DisplayMode = DisplayModeEnum.EXECUTE;
            CurrentExecutingProgram = 0;
            PlayCommand.RaiseCanExecuteChanged();
            Manager.ExecuterProgramme();



        }

        public void OnNavigateTo(IDictionary<string, object> param)
        {
            _facade = (Facade)param["facade"];
            Manager = new FacadeJeux((Niveau)param["niveau"]);
            Manager.InstructionExecute += OnInstructionExecuted;
            Manager.ProgrammeExecute += OnProgrammeExecuted;
            //Afficher la forme
            foreach (Vecteur2 vect in Manager.Manager.NiveauEnCours.Forme.Segments)
                PointsToDisplay.Add(vect);
        }

        public void OnInstructionExecuted(object sender, InstructionExecuteEventArgs args)
        {
            //mise dans la queue des états pour affichage
            _points.Enqueue(args.EtatFinal);
        }

        public void OnProgrammeExecuted(object sender, ProgrammeExecuteEventArgs args)
        {
            PointsToDisplay.Clear();
            _timerDisplay.Start();
            _percent = args.FormePercentSame;
            if(args.FormePercentSame == 1)
            {
                Manager.Manager.NiveauEnCours.EstTermine = true;
            }
        }
    }
}
