using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;

namespace Progression_GUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region variable declarations
        private string? _GroupName;

        public string? GroupName
        {
            get => _GroupName;
            set => Set(ref _GroupName, value);
        }
        #endregion

        #region command methods
        public RelayCommand? NewHelm { get; private set; }
        public RelayCommand? NewMainHand { get; private set; }

        public RelayCommand? NewOffHand { get; private set; }

        public RelayCommand? NewChest { get; private set; }

        public RelayCommand? NewGloves { get; private set; }
        public RelayCommand? NewBoots { get; private set; }
        #endregion

        public MainViewModel()
        {
            CommandInit();
        }

        private void CommandInit()
        {
            NewHelm = new RelayCommand(OnNewHelm);
        }

        private void OnNewHelm()
        {
            GroupName = "Helm";
        }
    }
}
