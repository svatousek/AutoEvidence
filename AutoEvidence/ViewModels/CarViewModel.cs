using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace AutoEvidence.ViewModels
{
    public class CarViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _make;
        public string Make
        {
            get => _make;
            set
            {
                _make = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string _model;
        public string Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string FullName => $"{Make} {Model}";

        public int Year { get; set; }
        public string VIN { get; set; }
        public string VINShort => string.IsNullOrEmpty(VIN) ? VIN : VIN[^6..];
        public string LicensePlate { get; set; }

        public string ImagePath { get; set; }

        public string ColorName { get; set; }
        public string ColorHex { get; set; }
        public Brush ColorBrush { get; set; }

        public int Mileage { get; set; }
        public string Engine { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string OwnerName { get; set; }
        public string Status { get; set; }

        public DateTime? InsuranceExpiry { get; set; }
        public DateTime? NextServiceDate { get; set; }
        public DateTime? LastService { get; set; }

        public string Notes { get; set; }
        public string AvailabilityText { get; set; }
    }
}
