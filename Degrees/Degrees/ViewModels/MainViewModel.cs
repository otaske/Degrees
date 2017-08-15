namespace Degrees.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using System;
    using System.ComponentModel;

    public class MainViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        string _celsius;
        string _fahrenheit;
        #endregion

        #region Properties
        public string Temperature
        {
            get;
            set;
        }
        public string Celsius
        {
            get
            {
                return _celsius;
            }
            set
            {
                if (value != _celsius)
                {
                    _celsius = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Celsius)));
                }
            }
        }
        public string Fahrenheit
        {
            get
            {
                return _fahrenheit;
            }
            set
            {
                if (value != _fahrenheit)
                {
                    _fahrenheit = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Fahrenheit)));
                }
            }
        }
        #endregion
        #region Constructor
        public MainViewModel()
        {
        }

        #endregion

        #region Commands
        public ICommand ConvertCommand
        {
            get { return new RelayCommand(ConvertCelsius); }
        }
        public ICommand ConvertCommand2
        {
            get { return new RelayCommand(ConvertFahrenheit); }
        }

        async void ConvertCelsius()
        {
            if (string.IsNullOrEmpty(Temperature))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a appropriate temperature..", "Accept");
                return;
            }

            decimal temperature = 0;
            if (!decimal.TryParse(Temperature, out temperature))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a value numeric..", "Accept");
                Temperature = null;
                return;
            }

            var celsius = (temperature-32) / 1.800000M;

            Celsius = string.Format("{0:N2}°", celsius);
        }
        async void ConvertFahrenheit()
        {
            if (string.IsNullOrEmpty(Temperature))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a appropriate temperature..", "Accept");
                return;
            }

            decimal temperature = 0;
            if (!decimal.TryParse(Temperature, out temperature))
            {
                await App.Current.MainPage.DisplayAlert("Error", "You must enter a value numeric..", "Accept");
                Temperature = null;
                return;
            }

            var fahrenheit = ((temperature * 1.800000M) + 32);

            Fahrenheit = string.Format("{0:N2}°", fahrenheit);
        }
        #endregion
    }
}