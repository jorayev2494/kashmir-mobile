using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Kashmir.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            this.OnPropertyChanged(propertyName: propertyName);
            return true;
        }

        private bool isLoading;

        public bool IsLoading 
        {
            get => this.isLoading;
            set => this.SetProperty(ref this.isLoading, value);
        }

        protected void IsLoadingToggle()
        {
            this.IsLoading = !this.IsLoading;
        }

        protected void IsLoadingRun()
        {
            this.IsLoading = true;
        }

        protected void IsLoadingStop()
        {
            this.IsLoading = false;
        }
    }
}
