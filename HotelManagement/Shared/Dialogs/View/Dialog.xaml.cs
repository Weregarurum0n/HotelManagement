using HotelManagement.Shared.Dialogs;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelManagement.Shared.Models.Dialogs.View
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : CustomDialog
    {
        #region "Fields"

        private readonly Shared.Dialogs.DialogCoordinator _dialogCoordinator;
        private readonly object _viewModel;

        private bool _closeWindow;

        #endregion

        #region "Properties"
        public List<Button> Buttons { get; set; }

        #endregion

        public Dialog(Shared.Dialogs.DialogCoordinator dialogCoordinator, object viewModel, string title, string message, 
            bool closeWindow, int buttonsCount = 1)
        {
            InitializeComponent();

            _dialogCoordinator = dialogCoordinator;
            _viewModel = viewModel;

            TitleLabel.Text = title;
            TitleLabel.FontWeight = FontWeights.Bold;
            TitleLabel.FontSize = MessageLabel.FontSize * 1.5;

            MessageLabel.Text = message;
            Buttons = new List<Button>();

            _closeWindow = closeWindow;

            InitializeButtons(buttonsCount);
        }

        private void InitializeButtons(int buttonsCount)
        {
            for (var i = 0; i < buttonsCount; i++)
            {
                var btn = new Button
                {
                    Content = "Button " + i,
                    Tag = i - 1

                };

                btn.Click += CloseDialog;
                Buttons.Add(btn);
                BtnStackPanel.Children.Add(btn);
            }

        }

        private async void CloseDialog(object sender, RoutedEventArgs e)
        {
            try
            {
                await _dialogCoordinator.HideMetroDialogAsync(_viewModel, this);
                await _WaitForCloseAsync();

                if (_closeWindow)
                {
                    _dialogCoordinator.DestroyMetroWindow(_viewModel);
                }
            }
            catch
            {
                //Log.Error(exception);
            }

        }

        #region Dialog Events

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Buttons?.Count < 2)
            {
                Buttons?.FirstOrDefault()?.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
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
            {
                DialogSettings.MaximumBodyHeight = Height;
            }

            MinHeight = Height > MaxHeight ? MaxHeight : Height;
            mainStackPanel.Height = Height;
            ScrollBar.Height = Math.Max(MinHeight - TitleLabel.ActualHeight - BtnStackPanel.ActualHeight - 20, 0);

            DialogView.BeginInvoke(() =>
            {
                BtnStackPanel.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            });

        }

        #endregion

    }
}
