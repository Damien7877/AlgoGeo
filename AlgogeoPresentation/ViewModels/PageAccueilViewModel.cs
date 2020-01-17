using AlgogeoMvvm;
using AlgogeoPresentation.Views;

namespace AlgogeoPresentation.ViewModels
{
    public class PageAccueilViewModel : PageViewModel
    {

        public PageAccueilViewModel()
        {

        }

        public DelegateCommand StartJeuCommand { get; private set; }

        public override void InitializeCommands()
        {
            StartJeuCommand = new DelegateCommand(OnStartJeuCommand);
        }

        public override void InitializeData()
        {

        }

        public override void InitializeEvents()
        {

        }

        private void OnStartJeuCommand(object obj)
        {
            Navigate(typeof(ListeChapitresView));
        }

    }
}
