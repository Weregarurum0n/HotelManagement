using System;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace HotelManagement.Shared.Dialogs
{
    public class DialogCoordinator
    {
        public static readonly DialogCoordinator Instance = new DialogCoordinator();

        public Task<string> ShowInputStringAsync(object context, string title, string message, MetroDialogSettings settings = null)
        {
            var metroWindow = GetMetroWindow(context);
            return metroWindow.Invoke(() => metroWindow.ShowInputAsync(title, message, settings));
        }

        public Task<MessageDialogResult> ShowMessageAsync(object context, string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null)
        {
            var metroWindow = GetMetroWindow(context);
            return metroWindow.Invoke(() => metroWindow.ShowMessageAsync(title, message, style, settings));
        }

        public double GetMetroWindowHeight(object context)
        {
            var metroWindow = GetMetroWindow(context);
            return metroWindow == null ? 0 : metroWindow.ActualHeight;
        }

        public Task ShowMetroDialogAsync(object context, BaseMetroDialog dialog, MetroDialogSettings settings = null)
        {
            var metroWindow = GetMetroWindow(context);
            return metroWindow.Invoke(() => metroWindow.ShowMetroDialogAsync(dialog, settings));
        }

        public Task HideMetroDialogAsync(object context, BaseMetroDialog dialog, MetroDialogSettings settings = null)
        {
            var metroWindow = GetMetroWindow(context);
            return metroWindow.Invoke(() => metroWindow.HideMetroDialogAsync(dialog, settings));
        }

        public Task<TDialog> GetCurrentDialogAsync<TDialog>(object context) where TDialog : BaseMetroDialog
        {
            var metroWindow = GetMetroWindow(context);
            return metroWindow.Invoke(() => metroWindow.GetCurrentDialogAsync<TDialog>());
        }

        public void DestroyMetroWindow(object context)
        {
            var metroWindow = GetMetroWindow(context);
            metroWindow.Invoke(() => metroWindow.Close());
        }

        private static MetroWindow GetMetroWindow(object context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (!Shared.Dialogs.DialogParticipation.IsRegistered(context))
            {
                throw new InvalidOperationException("Context is not registered. Consider using DialogParticipation.Register in XAML to bind in the DataContext.");
            }

            var association = Shared.Dialogs.DialogParticipation.GetAssociation(context);
            var metroWindow = association.Invoke(() => Window.GetWindow(association) as MetroWindow);
            if (metroWindow == null)
            {
                throw new InvalidOperationException("Context is not inside a MetroWindow.");
            }
            return metroWindow;
        }
    }
}
