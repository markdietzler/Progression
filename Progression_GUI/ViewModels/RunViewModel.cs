using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace Progression_GUI.ViewModels
{
    public class RunViewModel : ViewModelBase
    {
        #region variable declarations


        #endregion

        #region boolean declarations
        private bool? _ThreadControl = false;

        public bool? ThreadControl
        {
            get => _ThreadControl;
            set => Set(ref _ThreadControl, value);
        }
        #endregion

        #region visibility settings

        private Visibility _TwoHand;

        public Visibility TwoHand
        {
            get => _TwoHand;
            set => Set(ref _TwoHand, value);
        }

        private Visibility _RingOne;

        public Visibility RingOne
        {
            get => _RingOne;
            set => Set(ref _RingOne, value);
        }

        private Visibility _RingTwo;

        public Visibility RingTwo
        {
            get => _RingTwo;
            set => Set(ref _RingTwo, value);
        }

        private Visibility _MainHand;

        public Visibility MainHand
        {
            get => _MainHand;
            set => Set(ref _MainHand, value);
        }

        private Visibility _OffHand;

        public Visibility OffHand
        {
            get => _OffHand;
            set => Set(ref _OffHand, value);
        }

        private Visibility _Gloves;

        public Visibility Gloves
        {
            get => _Gloves;
            set => Set(ref _Gloves, value);
        }

        #endregion

        public RunViewModel()
        {
            //TODO get 
        }

        private void LogFileWatcher()
        {
            //TODO figure out if file watcher goes here or in the xaml code behind (probably in the code behind)
        }
    }
}
