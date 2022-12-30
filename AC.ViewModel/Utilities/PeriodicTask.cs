using System.Diagnostics;

namespace AC.ViewModel.Utilities
{
    internal class PeriodicTask : IAsyncDisposable
    {
        private Task? _timerTask;
        private CancellationTokenSource? _cts;
        private readonly PeriodicTimer _timer;
        private readonly Action _task;
        public bool IsRunning { get; set; }

        public PeriodicTask(Action task, TimeSpan interval)
        {
            _task = task;
            _timer = new PeriodicTimer(interval);
        }

        public void Start()
        {
            _cts = new CancellationTokenSource();
            _timerTask = DoWorkAsync();
            IsRunning = true;
        }
        public void Stop()
        {
            if (_cts == null) throw new NullReferenceException(nameof(_cts));
            if (_timerTask == null) return;
            _cts.Cancel();
            IsRunning = false;
        }
        public async ValueTask DisposeAsync()
        {
            Stop();
            _timer.Dispose();
            if (_timerTask != null) await _timerTask;
            GC.SuppressFinalize(this);
        }

        private async Task DoWorkAsync()
        {
            if(_cts == null) throw new NullReferenceException(nameof(_cts));
            CancellationToken ct = _cts.Token;

            try
            {
                while (await _timer.WaitForNextTickAsync(ct))
                {
                    _task();
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }
    }
}
