using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Progression_Library.Data;
using System;
using System.Collections.Generic;

namespace Progression_GUI.ViewModels
{
    public class SubWindowViewModel : ViewModelBase
    {
        #region variables

        private List<Gem>? _GgemList;

        public List<Gem>? GemList
        {
            get => _GgemList;
            set => Set(ref _GgemList, value);
        }

        #endregion

        #region command_methods

        public RelayCommand? Return { get; private set; }
        public RelayCommand? Add { get; private set; }

        #endregion

        public SubWindowViewModel(string initType)
        {
            if (string.IsNullOrEmpty(initType))
            {
                throw new ArgumentException("");
            }
            InitType(initType);
        }

        private void InitGemAdd()
        {

        }

        private void InitType(string type)
        {
            
        }
    }
}
