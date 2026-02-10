using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AutoEvidence.Models;
using AutoEvidence.Services;
using GalaSoft.MvvmLight.Command;

namespace AutoEvidence.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly IStorageService _storage;

        public ObservableCollection<Owner> Owners { get; }

        private Owner? _selectedOwner;
        public Owner? SelectedOwner
        {
            get => _selectedOwner;
            set
            {
                _selectedOwner = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddOwnerCommand { get; }
        public ICommand DeleteOwnerCommand { get; }
        public ICommand SaveCommand { get; }

        public MainViewModel()
        {
            _storage = new JsonStorageService();
            var data = _storage.LoadData();

            Owners = new ObservableCollection<Owner>(data.Owners);

            AddOwnerCommand = new RelayCommand(AddOwner);
            DeleteOwnerCommand = new RelayCommand(DeleteOwner);
            SaveCommand = new RelayCommand(Save);
        }

        private void AddOwner()
        {
            Owners.Add(new Owner());
        }

        private void DeleteOwner()
        {
            if (SelectedOwner != null)
                Owners.Remove(SelectedOwner);
        }

        private void Save()
        {
            _storage.SaveData(new CarEvidenceData
            {
                Owners = new System.Collections.Generic.List<Owner>(Owners)
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
