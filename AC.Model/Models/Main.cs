using AC.Model.Models.Application;
using AC.Model.Models.Macro;
using PeripheralDeviceEmulator.Keyboard;

namespace AC.Model.Models
{
    public class Main : ModelBase
    {
        private CancellationTokenSource? _cts;

        public MacroList MacroList { get; }
        public ApplicationList ApplicationList { get; }
        public bool IsPlaying { get; set; } = false;

        public Main()
        {
            MacroList = new();
            ApplicationList = new(new KeyboardEmulator());
        }

        public async Task PlayOnce()
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
                await Task.Delay(action.Delay);
            }
            IsPlaying = false;
        }
        public async Task PlayRepeatedly()
        {
            _cts = new();
            if (IsPlaying)
            {
                _cts.Cancel();
                return;
            }

            while (!_cts.Token.IsCancellationRequested)
            {
                await PlayOnce();
            }
            _cts.Dispose();
        }
    }
}
