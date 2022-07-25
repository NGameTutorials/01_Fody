using PropertyChanged;
using System.Threading;
using System.Windows.Threading;

namespace _01_Fody.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    internal class LearnVM_002
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

        [AlsoNotifyFor(nameof(Message2))]
        public int ProgressPercent { get; set; }

        [DependsOn(nameof(ProgressPercent))]
        public string Message1 { get => $"Message1: Task completed {ProgressPercent}%"; }

        public string Message2 { get => $"Message2: Task completed {ProgressPercent}%"; }
    }
}
