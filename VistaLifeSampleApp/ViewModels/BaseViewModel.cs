using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using VistaLifeSampleApp.Models;

namespace VistaLifeSampleApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        private readonly Dictionary<string, object> _propertyBackingDictionary = new Dictionary<string, object>();

        public BaseViewModel()
        {
        }

        public List<User> UsersList
        {
            get => GetPropertyValue<List<User>>();
            set => SetPropertyValue(value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public T GetPropertyValue<T>(T defaultvalue = default(T), [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException(nameof(propertyName));

            if (_propertyBackingDictionary.TryGetValue(propertyName, out object value))
                return (T)value;

            if (EqualityComparer<T>.Default.Equals(defaultvalue, default(T)))
            _propertyBackingDictionary[propertyName] = defaultvalue;
            return defaultvalue;
        }

        public bool SetPropertyValue<T>(T newValue,  [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
                return false;

            if (EqualityComparer<T>.Default.Equals(newValue, GetPropertyValue<T>(default(T), propertyName))) return false;
            _propertyBackingDictionary[propertyName] = newValue;
            OnPropertyChanged(propertyName);
            return true;
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
