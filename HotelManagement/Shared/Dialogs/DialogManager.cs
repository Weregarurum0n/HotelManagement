using HotelManagement.Shared.Models.Dialogs.Models;
using HotelManagement.Shared.Models.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using HotelManagement.Shared.Convert.Extensions;

namespace HotelManagement.Shared.Dialogs
{
    public class DialogObjects : IDialogObjects
    {
        private readonly DialogCoordinator _coordinator;
        private object _viewModel;

        public DialogObjects()
        {
            _coordinator = Shared.Dialogs.DialogCoordinator.Instance;
        }

        public void SetViewModel(object context)
        {
            _viewModel = context;
        }

        public async void DisplayDialogAsync(Models.Dialogs.View.Dialog dialog)
        {
            try
            {
                var cd = await _coordinator.GetCurrentDialogAsync<Models.Dialogs.View.Dialog>(_viewModel);
                if (cd != null)
                {
                    await _coordinator.HideMetroDialogAsync(_viewModel, cd);
                    await _coordinator.ShowMetroDialogAsync(_viewModel, dialog);
                }
                else
                {
                    await _coordinator.ShowMetroDialogAsync(_viewModel, dialog);
                }
            }
            catch
            {
                //Log.Error(e);
            }

        }

        public void DisplayMessageDialog(string title, string message)
        {
            _coordinator.ShowMessageAsync(_viewModel, title, message);

            return;
        }

        public void DisplayNoPermissionDialog()
        {
            DisplayMessageDialog("No Permission", "Unable to perform the desired action due a missing permission.");
        }
        public void DisplayErrorDialog(string title, string message, RoutedEventHandler handler = null)
        {
            DisplayMessageDialog(title, message);
        }
        public void DisplayErrorDialog(ReturnStatus status, string header, RoutedEventHandler handler = null)
        {
            DisplayMessageDialog(header + status.ReturnId, status.ReturnMessage);
        }
        public void DisplayErrorDialog(ReturnStatus status, RoutedEventHandler handler = null)
        {
            DisplayMessageDialog(status.ReturnId == (int)HttpStatusCode.BadRequest || status.ReturnId == (int)HttpStatusCode.NotAcceptable
                ? "Request Validation" : "Error " + status.ReturnId, status.ReturnMessage);
        }

        public void DisplayFileExportDialog(string title, string message, string filePath)
        {
            try
            {
                var buttons = new List<string> { "Yes", "No" };
                var buttonHandlers = new List<RoutedEventHandler> { (sender, args) => Process.Start(filePath), null };
                DisplayMultipleButtonDialog(title, message, buttons, buttonHandlers);
            }
            catch
            {
                DisplayErrorDialog("File Open Error", "Failed to open file.");
            }
        }

        public void DisplayMultipleButtonDialog(string title, string message, List<string> buttons, 
            List<RoutedEventHandler> buttonHandlers, bool closeWindow = false)
        {
            if (buttons == null || buttons.Count <= 0)
            {
                buttons = new List<string> { "Ok" };
            }

            var dialog = new Models.Dialogs.View.Dialog(_coordinator, _viewModel, title, message, closeWindow, buttons.Count);
            for (int i = 0; i < buttons.Count; i++)
            {
                dialog.Buttons[i].Content = buttons[i];
                if (buttonHandlers.ElementAtOrDefault(i) != null)
                {
                    dialog.Buttons[i].Click += buttonHandlers.ElementAtOrDefault(i);
                }
            }
            DisplayDialogAsync(dialog);

        }
        public void DisplayYesNoDialog(string title, string message, RoutedEventHandler handler)
        {
            var dialog = new Models.Dialogs.View.Dialog(_coordinator, _viewModel, title, message, false, 2);
            dialog.Buttons[0].Content = "_Yes";
            if (handler != null) dialog.Buttons[0].Click += handler;
            dialog.Buttons[1].Content = "_No";


            DisplayDialogAsync(dialog);
        }

        public Task<string> InputMessageDialog(string title, string message)
        {
            return _coordinator.ShowInputStringAsync(_viewModel, title, message);
        }

        public async Task<DialogDateRange> DisplayInputDateTimeAsync(string title, string description, DialogDateRangeEnum rangeType,
            string dateFromLabel, string dateToLabel = null, DateTime? defaultDateFrom = null, DateTime? defaultDateTo = null)
        {
            var ret = null as DialogDateRange;
            var dialog = new Models.Dialogs.View.DateRangeDialog(_coordinator, _viewModel, title, description, rangeType, dateFromLabel, dateToLabel, defaultDateFrom, defaultDateTo, false, 2);

            dialog.Buttons[0].Content = "Cancel";
            dialog.Buttons[0].Click += (sender, args) => ret = new DialogDateRange { DateFrom = null, DateTo = null };
            dialog.Buttons[1].Content = "OK";
            dialog.Buttons[1].Click += (sender, args) =>

            ret = new DialogDateRange
            {
                DateFrom = rangeType == DialogDateRangeEnum.OneDate ? dialog.OneDateFrom.ToSafeDateTime() :
                            (rangeType == DialogDateRangeEnum.DateRange ? dialog.DateRangeFromTo.BeginDate.ToSafeDateTime() :
                                dialog.TwoDateFrom.ToSafeDateTime()),
                DateTo = rangeType == DialogDateRangeEnum.OneDate ? new DateTime() :
                            (rangeType == DialogDateRangeEnum.DateRange ? dialog.DateRangeFromTo.EndDate.ToSafeDateTime() :
                                dialog.TwoDateTo.ToSafeDateTime()),
            };

            var cd = await _coordinator.GetCurrentDialogAsync<Models.Dialogs.View.DateRangeDialog>(_viewModel);
            if (cd != null)
            {
                await _coordinator.HideMetroDialogAsync(_viewModel, cd);
                await _coordinator.ShowMetroDialogAsync(_viewModel, dialog);
            }
            else
                await _coordinator.ShowMetroDialogAsync(_viewModel, dialog);

            await dialog.WaitUntilUnloadedAsync();

            return ret;
        }
    }
}
