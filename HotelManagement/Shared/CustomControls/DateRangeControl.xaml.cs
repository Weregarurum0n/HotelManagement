using HotelManagement.Shared.Convert;
using HotelManagement.Shared.Convert.Extensions;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HotelManagement.Shared.CustomControls
{
    /// <summary>
    /// Interaction logic for DateRangeControl.xaml
    /// </summary>
    public partial class DateRangeControl : UserControl
    {
        public DateRangeControl()
        {
            InitializeComponent();
        }

        public string BeginDateWatermark
        {
            get { return (string)GetValue(BeginDateWatermarkProperty); }
            set { SetValue(BeginDateWatermarkProperty, value); }
        }

        public static readonly DependencyProperty BeginDateWatermarkProperty =
            DependencyProperty.Register("BeginDateWatermark", typeof(string), typeof(DateRangeControl), new FrameworkPropertyMetadata("Begin Date"));



        public string EndDateWatermark
        {
            get { return (string)GetValue(EndDateWatermarkProperty); }
            set { SetValue(EndDateWatermarkProperty, value); }
        }

        public static readonly DependencyProperty EndDateWatermarkProperty =
            DependencyProperty.Register("EndDateWatermark", typeof(string), typeof(DateRangeControl), new FrameworkPropertyMetadata("End Date"));


        public DateTime? BeginDate
        {
            get { return (DateTime?)GetValue(BeginDateProperty); }
            set { SetValue(BeginDateProperty, value); }
        }

        public static readonly DependencyProperty BeginDateProperty =
            DependencyProperty.Register("BeginDate", typeof(DateTime?), typeof(DateRangeControl), new FrameworkPropertyMetadata
            {
                BindsTwoWayByDefault = true,
                PropertyChangedCallback = OnBeginDateChanged,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

        private static void OnBeginDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DateRangeControl dateRange)
            {
                if (dateRange.BeginDate != null
                    && dateRange.EndDate != null
                    && dateRange.BeginDate.ToSafeDateTime().Date > dateRange.EndDate.ToSafeDateTime().Date)
                {
                    dateRange.EndDate = dateRange.BeginDate;
                }
            }
        }



        public DateTime? EndDate
        {
            get { return (DateTime?)GetValue(EndDateProperty); }
            set { SetValue(EndDateProperty, IncludeEndOfDayForEndDate ? value.ToSafeDateTime().ChangeTimeToEndOfDay() : value); }
        }

        public static readonly DependencyProperty EndDateProperty =
            DependencyProperty.Register("EndDate", typeof(DateTime?), typeof(DateRangeControl), new FrameworkPropertyMetadata
            {
                BindsTwoWayByDefault = true,
                PropertyChangedCallback = OnEndDateChanged,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            });

        private static void OnEndDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            if (d is DateRangeControl dateRange)
            {
                if (dateRange.BeginDate != null
                    && dateRange.EndDate != null
                    && dateRange.EndDate.ToSafeDateTime().Date < dateRange.BeginDate.ToSafeDateTime().Date)
                {
                    dateRange.BeginDate = dateRange.EndDate.ToSafeDateTime().ChangeTime(12, 0, 0);
                }

                if (dateRange.EndDate != null && dateRange.EndDate.ToSafeDateTime().TimeOfDay.Ticks == 0 && dateRange.IncludeEndOfDayForEndDate)
                {
                    // set to self to change its time to 11:59:59 (End of day) in the SetValue of the property above
                    dateRange.EndDate = dateRange.EndDate;
                }
            }
        }


        /// <summary>
        /// Set to false if you don't want the end date time to be 11:59:59 PM. The Default is true
        ///  </summary>
        public bool IncludeEndOfDayForEndDate
        {
            get { return (bool)GetValue(IncludeEndOfDayForEndDateProperty); }
            set { SetValue(IncludeEndOfDayForEndDateProperty, value); }
        }

        public static readonly DependencyProperty IncludeEndOfDayForEndDateProperty =
            DependencyProperty.Register("IncludeEndOfDayForEndDate", typeof(bool), typeof(DateRangeControl), new PropertyMetadata(true));



        private bool _isEndDateFocused;

        private void LeftButton_OnClick(object sender, RoutedEventArgs e)
        {
            UpdateDate(-1);
        }

        private void RightButton_OnClick(object sender, RoutedEventArgs e)
        {
            UpdateDate(1);
        }


        private void UpdateDate(int value)
        {
            if (_isEndDateFocused)
            {
                EndDatePicker.SelectedDate = EndDatePicker.SelectedDate?.AddDays(value);
            }
            else
            {
                BeginDatePicker.SelectedDate = BeginDatePicker.SelectedDate?.AddDays(value);
            }
        }

        private void EndDatePicker_OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            _isEndDateFocused = true;

        }

        private void BeginDatePicker_OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {

            _isEndDateFocused = false;
        }
    }
}
