using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Mobiele_Applicatie_Interface_Studio.Services;
using Mobiele_Applicatie_Interface_Studio.ViewModels;

namespace Mobiele_Applicatie_Interface_Studio.ViewModels
{
    public class BestellingDetailsViewModel : INotifyPropertyChanged
    {
        private readonly BestellingService _service;
        private Bestelling _bestelling;

        public event PropertyChangedEventHandler PropertyChanged;

        public Bestelling Bestelling
        {
            get => _bestelling;
            set { _bestelling = value; OnPropertyChanged(); }
        }

        public List<string> Statussen { get; } = new() { "Onderweg", "Bezorgd", "Niet Thuis" };

        public BestellingDetailsViewModel(BestellingService service)
        {
            _service = service;
        }

        public async Task LoadBestellingAsync(string bestellingId)
        {
            Bestelling = await _service.GetBestellingAsync(bestellingId);
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
