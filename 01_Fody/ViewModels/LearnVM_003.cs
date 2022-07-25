using PropertyChanged;
using System.Threading;
using System.Windows.Threading;

namespace _01_Fody.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    internal class LearnVM_003
    {
        public LearnVM_003()
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

        public int ProgressPercent { get; set; }
    }
}
