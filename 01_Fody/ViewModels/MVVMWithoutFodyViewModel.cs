using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;

namespace _01_Fody.ViewModels
{
    internal class MVVMWithoutFodyViewModel : INotifyPropertyChanged
    {
        public MVVMWithoutFodyViewModel()
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

        public event PropertyChangedEventHandler? PropertyChanged;

        void UpdateUI(string propName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));


        int _prgperc = 0;
        public int ProgressPercent
        {
            get => _prgperc;
            set { _prgperc = value; UpdateUI(nameof(ProgressPercent)); }
        }

    }
}
