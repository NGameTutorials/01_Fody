using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Threading;

namespace _01_Fody.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void AdvancedUpdateUI([CallerMemberName] string propName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

    }

    internal class LearnVM_002 : BaseViewModel
    {
        public LearnVM_002()
        {
            new Thread(HandleProgress).Start();
        }

        void HandleProgress()
        {
            while (true)
            {
                Dispatcher.CurrentDispatcher.Invoke(() =>
                {
                    if (ProgressPercent < 100)
                        ProgressPercent++;
                });
                Thread.Sleep(100);
                if (ProgressPercent == 100) return;
            }
        }

        int _prgperc = 0;
        public int ProgressPercent
        {
            get => _prgperc;
            set
            {
                if (_prgperc == value) return;
                _prgperc = value;
                AdvancedUpdateUI();
            }
        }

    }
}
