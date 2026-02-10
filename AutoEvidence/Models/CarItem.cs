using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AutoEvidence.Models
{
    [Serializable]
    public class CarItem : INotifyPropertyChanged
    {
        public Guid Id { get; } = Guid.NewGuid();

        private string _spz = string.Empty;
        private string _brand = string.Empty;
        private string _model = string.Empty;
        private int _year;
        private string _color = string.Empty;
        private string _fuel = string.Empty;
        private int _mileage;
        private string _vin = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string SPZ
        {
            get => _spz;
            set => SetProperty(ref _spz, value);
        }

        public string Brand
        {
            get => _brand;
            set => SetProperty(ref _brand, value);
        }

        public string Model
        {
            get => _model;
            set => SetProperty(ref _model, value);
        }

        public int Year
        {
            get => _year;
            set
            {
                if (value < 1886 || value > DateTime.Now.Year + 1)
                    return;

                SetProperty(ref _year, value);
            }
        }

        public string Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }

        public string Fuel
        {
            get => _fuel;
            set => SetProperty(ref _fuel, value);
        }

        public int Mileage
        {
            get => _mileage;
            set
            {
                if (value < 0) return;
                SetProperty(ref _mileage, value);
            }
        }

        public string VIN
        {
            get => _vin;
            set => SetProperty(ref _vin, value);
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string? name = null)
        {
            if (!Equals(field, value))
            {
                field = value!;
                OnPropertyChanged(name);
            }
        }

        public override string ToString()
            => $"{Brand} {Model} ({SPZ})";
    }
}
