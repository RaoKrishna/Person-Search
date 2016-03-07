using System;
using System.Windows.Input;
using PersonSearch.ViewModel;

namespace PersonSearch.Command
{
    /// <summary>
    /// Command for searching the person in the database
    /// </summary>
    internal class SearchCommand : ICommand
    {
        private MainWindowViewModel mainWinVmod;

        /// <summary>
        /// Instantiates the object for interaction with the View Model
        /// </summary>
        /// <param name="mainWinVM"></param>
        public SearchCommand(MainWindowViewModel mainWinVM)
        {
            mainWinVmod = mainWinVM;
        }

        /// <summary>
        /// Implementation of EventHandler of ICommand
        /// </summary>
        public event System.EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Checks if the command can be executed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>Validates the controls and returns accordingly</returns>
        public bool CanExecute(object parameter)
        {
            try
            {
                return mainWinVmod.CanSearch;
            }
            catch (Exception)
            {
                mainWinVmod.ExceptionMessage = "Could not search the person! Please try again!!";
                return false;
            }
        }

        /// <summary>
        /// Executes the action associated with the command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            try
            {
                mainWinVmod.FetchPersonDetails();
            }
            catch (Exception)
            {
                mainWinVmod.ExceptionMessage = "Could not search the person! Please try again!!";
            }
        }
    }
}
