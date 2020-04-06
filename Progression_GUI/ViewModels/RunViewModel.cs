using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Progression_GUI.ViewModels
{
    public class RunViewModel : ViewModelBase
    {
        #region variable declarations

        private bool? _ThreadControl = false;

        public bool? ThreadControl
        {
            get => _ThreadControl;
            set => Set(ref _ThreadControl, value);
        } 

        #endregion

        public RunViewModel()
        {

        }

        private void LogFileWatcher()
        {

        }
    }
}
