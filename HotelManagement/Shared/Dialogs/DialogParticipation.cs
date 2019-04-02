using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HotelManagement.Shared.Dialogs
{
    public static class DialogParticipation
    {
        private static readonly IDictionary<object, DependencyObject> ContextRegistrationIndex = new Dictionary<object, DependencyObject>();
        private static TaskCompletionSource<object> tcs1 = new TaskCompletionSource<object>();
        public static readonly DependencyProperty RegisterProperty = DependencyProperty.RegisterAttached(
            "Register",
            typeof(object),
            typeof(DialogParticipation),
            new PropertyMetadata(default(object), RegisterPropertyChangedCallback));
        /*
         *these two fields are to keep track of the Forms Hierarchy so once a main form
         * is closed then that form and its children will be removed
         * from ContextRegistrationIndex to allow GC to collect them
         */
        private static readonly Dictionary<object, List<object>> FormsHierarchy = new Dictionary<object, List<object>>();
        private static object _parent;

        private static void RegisterPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            if (dependencyPropertyChangedEventArgs.OldValue != null)
            {
                var keyToRemove = dependencyPropertyChangedEventArgs.OldValue;

                ContextRegistrationIndex.Remove(keyToRemove);

                if (FormsHierarchy.ContainsKey(keyToRemove))
                {
                    foreach (var type in FormsHierarchy[keyToRemove])
                    {
                        ContextRegistrationIndex.Remove(type);
                    }

                    FormsHierarchy.Remove(keyToRemove);
                }
            }

            if (dependencyPropertyChangedEventArgs.NewValue != null)
            {
                if (dependencyObject is UserControl userControl)
                {
                    //that means it's from main window
                    if (userControl.IsLoaded)
                    {
                        _parent = dependencyPropertyChangedEventArgs.NewValue;
                        FormsHierarchy[_parent] = new List<object>();
                    }
                    else
                    {
                        FormsHierarchy[_parent].Add(dependencyPropertyChangedEventArgs.NewValue);
                    }
                }
                else
                {
                    _parent = dependencyPropertyChangedEventArgs.NewValue;
                    FormsHierarchy[_parent] = new List<object>();
                }

                ContextRegistrationIndex[dependencyPropertyChangedEventArgs.NewValue] = dependencyObject;
                if (!tcs1.TrySetResult(dependencyPropertyChangedEventArgs.NewValue))
                {
                    tcs1 = new TaskCompletionSource<object>();
                    tcs1.TrySetResult(dependencyPropertyChangedEventArgs.NewValue);
                }
            }
        }

        public static void SetRegister(DependencyObject element, object context)
        {
            element.SetValue(RegisterProperty, context);
        }

        public static object GetRegister(DependencyObject element)
        {
            return element.GetValue(RegisterProperty);
        }

        internal static bool IsRegistered(object context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return ContextRegistrationIndex.ContainsKey(context);
        }

        public static async Task<bool> ContextRegisteredAsync()
        {
            tcs1 = new TaskCompletionSource<object>();
            var context = await tcs1.Task;
            tcs1 = new TaskCompletionSource<object>();
            return IsRegistered(context);
        }

        internal static DependencyObject GetAssociation(object context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return ContextRegistrationIndex[context];
        }
    }
}
