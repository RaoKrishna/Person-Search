﻿using System;
using System.Windows.Input;
using PersonSearch.ViewModel;

namespace PersonSearch.Command
{
    public class SeedDataCommand : ICommand
    {
        private MainWindowViewModel mainWinVmod;

        /// <summary>
        /// Instantiates the object for interaction with the View Model
        /// </summary>
        /// <param name="mainWinVM"></param>
        public SeedDataCommand(MainWindowViewModel mainWinVM)
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
        /// <returns>true</returns>
        public bool CanExecute(object parameter)
        {
            try
            {
                return true;
            }
            catch (Exception)
            {
                mainWinVmod.ExceptionMessage = "Could not seed the data! Please try again!!";
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
                mainWinVmod.SeedData();
            }
            catch(Exception)
            {
                mainWinVmod.ExceptionMessage = "Could not seed the data! Please try again!!";
            }
        }
    }
}
