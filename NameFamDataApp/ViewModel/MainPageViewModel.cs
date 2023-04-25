using System.ComponentModel;

namespace NameFamDataApp.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _nameFill;
        private string _famFill;
        private DateTime _dateFill;

        public string NameFill
        {
            get => _nameFill;
            set
            {
                if (_nameFill != value)
                {
                    string output = new string(value.Where(c => !char.IsDigit(c) && !char.IsSymbol(c)).ToArray());
                    _nameFill = output;
                    OnPropertyChanged(nameof(NameFill));
                }
            }
        }

        public string FamFill
        {
            get => _famFill;
            set
            {
                if (_famFill != value)
                {
                    string output = new string(value.Where(c => !char.IsDigit(c) && !char.IsSymbol(c)).ToArray());
                    _famFill = output;
                    OnPropertyChanged(nameof(FamFill));
                }
            }
        }

        public DateTime DateFill
        {
            get => _dateFill;
            set
            {
                if (_dateFill != value)
                {
                    _dateFill = value;
                    OnPropertyChanged(nameof(DateFill));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
