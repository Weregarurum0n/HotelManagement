using HotelManagement.Shared.Models.Dialogs.Models;
using HotelManagement.Shared.Models.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManagement.Shared.Dialogs
{
    public interface IDialogObjects
    {
        void SetViewModel(object context);

        void DisplayDialogAsync(Models.Dialogs.View.Dialog dialog);

        void DisplayNoPermissionDialog();
        void DisplayErrorDialog(string title, string message, RoutedEventHandler handler = null);
        void DisplayErrorDialog(ReturnStatus status, string header, RoutedEventHandler handler = null);
        void DisplayErrorDialog(ReturnStatus status, RoutedEventHandler handler = null);

        void DisplayFileExportDialog(string title, string message, string filePath);

        void DisplayMultipleButtonDialog(string title, string message, List<string> buttons, 
            List<RoutedEventHandler> buttonHandlers, bool closeWindow = false);
        void DisplayYesNoDialog(string title, string message, RoutedEventHandler handler);

        Task<string> InputMessageDialog(string title, string message);

        Task<DialogDateRange> DisplayInputDateTimeAsync(string title, string description, DialogDateRangeEnum rangeType,
        string dateFromLabel, string dateToLabel = null, DateTime? defaultDateFrom = null, DateTime? defaultDateTo = null);
    }
}
