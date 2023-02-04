namespace AC.ViewModel.Utilities.Services
{
    public interface IDialogService
    {
        public Task ShowMessage(string message);
        public Task ShowWarning(string message);
        public Task ShowError(string message);
        public Task<bool> GetConfirmation(string message);
    }
}
