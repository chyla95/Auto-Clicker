using AC.Model.Models.Application;
using AC.Model.Models.Macro;
using PeripheralDeviceEmulator.Keyboard;
using PInvokeWrapper.Window;
using static System.Net.Mime.MediaTypeNames;

namespace AC.Model.Models
{
    public class Main : ModelBase
    {
        private CancellationTokenSource _cts = new();

        public MacroList MacroList { get; }
        public ApplicationList ApplicationList { get; }

        private bool _isPlaying;
        public bool IsPlaying
        {
            get
            {
                return _isPlaying;
            }
            set
            {
                _isPlaying = value;
                OnPropertyChanged();
            }
        }

        public Main()
        {
            MacroList = new();
            ApplicationList = new(new KeyboardEmulator());
        }

        private TimeSpan CalculateRandomDelay(TimeSpan inputDelay)
        {
            TimeSpan randomDelayRange = inputDelay * 0.3;

            Random r = new();
            TimeSpan randomDelay = TimeSpan.FromMilliseconds(r.Next(randomDelayRange.Milliseconds));

            if (r.Next(0, 1) >= 1) return inputDelay + randomDelay;
            else return inputDelay - randomDelay;
        }
        public async Task PlayOnce(CancellationToken cancellationToken)
        {
            IsPlaying = true;
            Macro.Macro? selectedMacro = MacroList.SelectedMacro;
            if (selectedMacro == null) throw new Exception("No macro is selected!");

            IEnumerable<Application.Application> selectedApplications = ApplicationList.Applications.Where(x => x.IsSelected);
            if (!selectedApplications.Any()) throw new Exception("No Apps selected!");

            foreach (Activity action in selectedMacro.Activities)
            {
                foreach (Application.Application application in selectedApplications)
                {
                    if (application.Window == null) continue;
                    application.Window.PostKey(action.KeyCode, action.KeyAction);

                    foreach (var window in application.Window.ChildWindows)
                    {
                        if (window == null) continue;
                        window.PostKey(action.KeyCode, action.KeyAction);
                    }
                }

                TimeSpan delay;
                if (selectedMacro.Behaviour == MacroBehaviour.Natural) delay = CalculateRandomDelay(action.Delay);
                else delay = action.Delay;

                System.Diagnostics.Debug.WriteLine($"{delay.TotalMilliseconds} / {action.Delay.TotalMilliseconds}");
                await Task.Delay(delay, cancellationToken).ContinueWith(t => { });

                // Mess
                if (cancellationToken.IsCancellationRequested)
                {
                    int lastActivityIndex = selectedMacro.Activities.IndexOf(action);
                    IEnumerable<Activity> playedActities = selectedMacro.Activities.ToList().GetRange(0, lastActivityIndex + 1);
                    IEnumerable<Activity> leftActivities = selectedMacro.Activities.ToList().Where(a => !playedActities.Contains(a));

                    foreach (Activity activity in playedActities)
                    {
                        Activity? ac = leftActivities.SingleOrDefault(a => a.Id == activity.Id);
                        if (ac == null) continue;

                        foreach (Application.Application application in selectedApplications)
                        {
                            if (application.Window == null) continue;
                            application.Window.PostKey(ac.KeyCode, ac.KeyAction);

                            foreach (var window in application.Window.ChildWindows)
                            {
                                if (window == null) continue;
                                window.PostKey(ac.KeyCode, ac.KeyAction);
                            }
                        }
                    }
                    break;
                }
            }
            IsPlaying = false;
        }
        public async Task PlayRepeatedly()
        {            
            if (!IsPlaying) _cts = new();

            while (!_cts.Token.IsCancellationRequested)
            {
                await PlayOnce(_cts.Token);
            }
            _cts.Dispose();
        }
        public void StopPlaying()
        {
            _cts.Cancel();
        }
    }
}
