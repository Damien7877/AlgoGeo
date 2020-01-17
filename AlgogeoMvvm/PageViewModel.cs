using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace AlgogeoMvvm
{
    /// <summary>
    /// Gère une page avec la navigation et les initialisations
    /// </summary>
    public abstract class PageViewModel : BaseViewModel
    {
        private Frame rootFrame;

        private Type navigatePage;

        /// <summary>
        /// Initialisation des données
        /// </summary>
        public abstract void InitializeData();

        /// <summary>
        /// Initialisation des events
        /// </summary>
        public abstract void InitializeEvents();

        /// <summary>
        /// Initialsation des commandes
        /// </summary>
        public abstract void InitializeCommands();



        public PageViewModel()
        {
            InitializeEvents();
            InitializeCommands();
            InitializeData();
            rootFrame = Window.Current.Content as Frame;
        }

        /// <summary>
        /// Naviguer vers une autre page
        /// </summary>
        /// <param name="obj">Le type de la page vers laquelle on navigue</param>
        /// <param name="parameters">Un dictionnaire d'objets a passer en paramètres</param>
        public void Navigate(Type obj, IDictionary<String, Object> parameters)
        {
            rootFrame.Navigate(obj, parameters);
        }

        /// <summary>
        /// Naviguer vers une page
        /// </summary>
        /// <param name="obj"></param>
        public void Navigate(Type obj)
        {
            Navigate(obj, null);
        }

        /// <summary>
        /// Aller en arrière
        /// </summary>
        public void GoBack()
        {
            rootFrame.GoBack();
        }
    }
}
