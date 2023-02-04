using System;
using System.Threading.Tasks;
using AC.ViewModel.Utilities.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace AC.View.Utilities.Services
{

    public class DialogService : IDialogService
    {
        public enum DialogType
        {
            Message,
            Warning,
            Error,
            Confirmation
        }

        private readonly XamlRoot _xamlRoot;

        public DialogService(XamlRoot xamlRoot)
        {
            _xamlRoot = xamlRoot;
        }

        private async Task<ContentDialogResult> Show(DialogType dialogType,string message)
        {
            string title = dialogType switch
            {
                DialogType.Message => "Message",
                DialogType.Warning => "Warning",
                DialogType.Error => "Error",
                DialogType.Confirmation => "Confirmation",
                _ => throw new NotImplementedException(),
            };

            ContentDialog dialog = new()
            {
                Title = title,
                Content = message,
                PrimaryButtonText = "Confirm",
                DefaultButton = ContentDialogButton.Primary,

                XamlRoot = _xamlRoot
            };
            if(dialogType == DialogType.Confirmation) dialog.CloseButtonText = "Cancel";

            return await dialog.ShowAsync();
        }

        public async Task ShowMessage(string message)
        {
            _ = await Show(DialogType.Message, message);
        }

        public async Task ShowWarning(string message)
        {
            _ = await Show(DialogType.Warning, message);
        }

        public async Task ShowError(string message)
        {
            _ = await Show(DialogType.Error, message);
        }

        public async Task<bool> GetConfirmation(string message)
        {
            ContentDialogResult dialogResult = await Show(DialogType.Confirmation, message);

            bool gotConfirmation = false;
            if (dialogResult == ContentDialogResult.Primary) gotConfirmation = true;

            return gotConfirmation;
        }
    }
}
