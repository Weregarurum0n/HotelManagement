using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using HotelManagement.Shared.Dialogs;
using HotelManagement.Shared.Models.Dialogs.Models;
using MahApps.Metro.Controls;

namespace HotelManagement.Shared.Models.Dialogs.View
{
    /// <summary>
    /// Interaction logic for DateRangeDialog.xaml
    /// </summary>
    public partial class DateRangeDialog
    {
        #region "Fields"

        private readonly DialogCoordinator _dialogCoordinator;
        private readonly object _viewModel;
        private bool _closeWindow;

        #endregion

        #region "Properties"

        public List<Button> Buttons { get; set; }

        #endregion

        #region "Constructor"

        public DateRangeDialog(DialogCoordinator dialogCoordinator, object viewModel, string title, string description,
            DialogDateRangeEnum rangeType, string dateFromLabel, string dateToLabel, DateTime? defaultDateFrom, DateTime? defaultDateTo,
            bool closeWindow, int buttonsCount = 1)
        {
            InitializeComponent();

            _dialogCoordinator = dialogCoordinator;
            _viewModel = viewModel;

            TitleLabel.Text = title;
            TitleLabel.FontWeight = FontWeights.Bold;
            TitleLabel.FontSize = DescriptionLabel.FontSize * 1.5;

            DescriptionLabel.Text = description;

            OneDateDockPanel.Visibility = Visibility.Collapsed;
            DateRangeDockPanel.Visibility = Visibility.Collapsed;
            TwoDateDockPanel.Visibility = Visibility.Collapsed;

            switch (rangeType)
            {
                case DialogDateRangeEnum.OneDate:
                    OneDateDockPanel.Visibility = Visibility.Visible;
                    OneDateStartLabel.Content = dateFromLabel;
                    OneDateFrom.SelectedDate = defaultDateFrom;
                    break;

                case DialogDateRangeEnum.DateRange:
                    DateRangeDockPanel.Visibility = Visibility.Visible;
                    DateRangeStartLabel.Content = dateFromLabel;
                    DateRangeFromTo.BeginDate = defaultDateFrom;
                    DateRangeFromTo.EndDate = defaultDateTo;
                    break;

                case DialogDateRangeEnum.TwoDate:
                    TwoDateDockPanel.Visibility = Visibility.Visible;
                    TwoDateStartLabel.Content = dateFromLabel;
                    TwoDateEndLabel.Content = dateToLabel;
                    TwoDateFrom.SelectedDate = defaultDateFrom;
                    TwoDateTo.SelectedDate = defaultDateTo;
                    break;
            }

            Buttons = new List<Button>();
            InitializeButtons(buttonsCount);

            _closeWindow = closeWindow;
        }

        #endregion

        #region Initialize Buttons

        private void InitializeButtons(int buttonsCount)
        {
            for (var i = 0; i < buttonsCount; i++)
            {
                var btn = new Button { Content = "Button " + i, Tag = i - 1 };

                btn.Click += CloseDialog;
                Buttons.Add(btn);
                BtnStackPanel.Children.Add(btn);
            }

        }

        #endregion

        #region Dialog Events

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Buttons?.Count < 2)
                Buttons?.FirstOrDefault()?.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }

        void DialogueIsLoaded(object a, RoutedEventArgs e)
        {
            Height = mainStackPanel.ActualHeight + BtnStackPanel.ActualHeight;
            var parentHeight = _dialogCoordinator.GetMetroWindowHeight(_viewModel);
            if (parentHeight > 0)
            {
                MaxHeight = Math.Max(parentHeight * .75, 400);
                DialogSettings.MaximumBodyHeight = Math.Max(Height * .75, 400);
            }
            else
                DialogSettings.MaximumBodyHeight = Height;

            MinHeight = Height > MaxHeight ? MaxHeight : Height;
            mainStackPanel.Height = Height;

            DateRangeDialogView.BeginInvoke(() => BtnStackPanel.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next)));
        }

        private async void CloseDialog(object sender, RoutedEventArgs e)
        {
            try
            {
                await _dialogCoordinator.HideMetroDialogAsync(_viewModel, this);
                await _WaitForCloseAsync();

                if (_closeWindow)
                    _dialogCoordinator.DestroyMetroWindow(_viewModel);
            }
            catch { }
        }

        #endregion
    }
}
