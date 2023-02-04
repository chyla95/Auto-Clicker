using AC.Model.Models.Application;
using AC.Model.Models.Macro;
using PeripheralDeviceEmulator.Constants;
using PeripheralDeviceEmulator.Keyboard;
using static System.Net.Mime.MediaTypeNames;

namespace AC.Model.Models
{
    public class AutoClicker : ModelBase
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

        public AutoClicker()
        {
            MacroList = new();
            ApplicationList = new(new KeyboardEmulator());
        }

        private static TimeSpan CalculateRandomDelay(TimeSpan inputDelay)
        {
            TimeSpan randomDelayRange = inputDelay * 0.3;

            Random r = new();
            TimeSpan randomDelay = TimeSpan.FromMilliseconds(r.Next(randomDelayRange.Milliseconds));

            if (r.Next(0, 1) >= 1) return inputDelay + randomDelay;
            else return inputDelay - randomDelay;
        }
        private static async Task DelayActivity(TimeSpan timeSpan, MacroBehaviour macroBehaviour, CancellationToken cancellationToken)
        {
            TimeSpan delay;

            if (macroBehaviour == MacroBehaviour.Natural)
            {
                delay = CalculateRandomDelay(timeSpan);
            }
            else
            {
                delay = timeSpan;
            }

            System.Diagnostics.Debug.WriteLine($"   => {delay.TotalMilliseconds} / {timeSpan.TotalMilliseconds}");
            await Task.Delay(delay, cancellationToken).ContinueWith(t => { }, CancellationToken.None);
        }
        private static async Task PlayMacroByApplicationPivot(Macro.Macro macro, IEnumerable<Application.Application> applications, CancellationToken cancellationToken)
        {
            foreach (Application.Application application in applications)
            {
                List<Activity> completedActivities = new();
                foreach (Activity activity in macro.Activities)
                {
                    if (application.Window == null) continue;
                    application.Window.PressKey(activity.KeyCode, activity.KeyAction, macro.KeyPressMethod);

                    await DelayActivity(activity.Delay, macro.Behaviour, cancellationToken);
                    completedActivities.Add(activity);

                    // Handle cancellation
                    if (cancellationToken.IsCancellationRequested)
                    {
                        IEnumerable<Activity> leftActivities = macro.Activities.Where(a => !completedActivities.Contains(a));
                        IEnumerable<Activity> peendingActivities = leftActivities.Where(la => completedActivities.Any(ca => ca.Id == la.Id));

                        foreach (Activity peendingActivity in peendingActivities)
                        {
                            if (application.Window == null) continue;
                            application.Window.PressKey(peendingActivity.KeyCode, peendingActivity.KeyAction, macro.KeyPressMethod);
                            await DelayActivity(TimeSpan.FromMilliseconds(100), macro.Behaviour, CancellationToken.None);
                        }
                        return;
                    }
                }
            }
        }
        private static async Task PlayMacroByActivityPivot(Macro.Macro macro, IEnumerable<Application.Application> applications, CancellationToken cancellationToken)
        {
            List<Activity> completedActivities = new();
            foreach (Activity activity in macro.Activities)
            {
                foreach (Application.Application application in applications)
                {
                    if (application.Window == null) continue;
                    application.Window.PressKey(activity.KeyCode, activity.KeyAction, macro.KeyPressMethod);
                }
                await DelayActivity(activity.Delay, macro.Behaviour, cancellationToken);
                completedActivities.Add(activity);

                // Handle cancellation
                if (cancellationToken.IsCancellationRequested)
                {
                    IEnumerable<Activity> leftActivities = macro.Activities.Where(a => !completedActivities.Contains(a));
                    IEnumerable<Activity> peendingActivities = leftActivities.Where(la => completedActivities.Any(ca => ca.Id == la.Id));

                    foreach (Activity peendingActivity in peendingActivities)
                    {
                        foreach (Application.Application application in applications)
                        {
                            if (application.Window == null) continue;
                            application.Window.PressKey(peendingActivity.KeyCode, peendingActivity.KeyAction, macro.KeyPressMethod);
                            await DelayActivity(TimeSpan.FromMilliseconds(100), macro.Behaviour, CancellationToken.None);
                        }
                    }
                    return;
                }
            }
        }

        public async Task PlayOnce(CancellationToken cancellationToken)
        {
            if (!ApplicationList.Applications.Any(a => a.IsSelected))
                throw new Exception("No applications are selected!");
            if (MacroList.SelectedMacro == null)
                throw new Exception("No macro is selected!");
            if (!MacroList.SelectedMacro.Activities.Any())
                throw new Exception("Action list is empty!");
            if (MacroList.SelectedMacro.Activities.Any(a => a.KeyCode == KeyCode.None))
                throw new Exception($"Action list contains undefined keystrokes! \nNo action should have value of \"None\".");

            IsPlaying = true;

            Macro.Macro? selectedMacro = MacroList.SelectedMacro;
            if (selectedMacro == null) return; // 

            IEnumerable<Application.Application> selectedApplications = ApplicationList.Applications.Where(x => x.IsSelected);
            if (!selectedApplications.Any()) return;

            switch (selectedMacro.Pivot)
            {
                case Pivot.Activity:
                    await PlayMacroByActivityPivot(selectedMacro, selectedApplications, cancellationToken);
                    break;
                case Pivot.Application:
                    await PlayMacroByApplicationPivot(selectedMacro, selectedApplications, cancellationToken);
                    break;
                default:
                    throw new NotImplementedException();
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
