using System.Windows;
using AutoEvidence.ViewModels;
using System.Windows.Media;

namespace AutoEvidence.Views
{
    public partial class CarDetailWindow : Window
    {
        public CarDetailWindow()
        {
            InitializeComponent();

            // TEST DATA – aby se ti to zobrazilo
            DataContext = new CarViewModel
            {
                Make = "Škoda",
                Model = "Octavia",
                Year = 2020,
                VIN = "TMBJJ7NE5L0123456",
                LicensePlate = "1AB1234",
                Mileage = 84500,
                FuelType = "Diesel",
                Transmission = "Automat",
                OwnerName = "Jan Novák",
                Status = "Aktivní",
                ColorName = "Červená",
                ColorHex = "#FF0000",
                ColorBrush = Brushes.Red,
                AvailabilityText = "Dostupné"
            };
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
