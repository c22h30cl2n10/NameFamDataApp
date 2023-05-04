using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace NameFamDataApp.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private string _nameFill;
        private string _famFill;
        private DateTime _dateFill = DateTime.Now;
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public string NameFill
        {
            get { return _nameFill; }
            set
            {
                if (StringValidator.Validate(value) != null)
                {
                    AddError(nameof(NameFill), StringValidator.Validate(value));
                }
                else
                {
                    RemoveError(nameof(NameFill));
                    _nameFill = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FamFill
        {
            get { return _famFill; }
            set
            {
                if (StringValidator.Validate(value) != null)
                {
                    AddError(nameof(FamFill), StringValidator.Validate(value));
                }
                else
                {
                    RemoveError(nameof(FamFill));
                    _famFill = value;
                    OnPropertyChanged();
                }
            }
        }

        public DateTime DateFill
        {
            get { return _dateFill; }
            set
            {
                _dateFill = value;
                OnPropertyChanged();
            }
        }


        //Добавляем ошибку в коллекцию и уведомляем об изменении
        private void AddError(string propertyName, string error)
        {
            if (!_errors.ContainsKey(propertyName))
            {
                _errors[propertyName] = new List<string>();
            }
            if (!_errors[propertyName].Contains(error))
            {
                _errors[propertyName].Add(error);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
                Shell.Current.DisplayAlert("Валидация", error, "Хорошо");
            }
        }

        //Очистка ошибок
        private void RemoveError(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                _errors.Remove(propertyName);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        public ICommand SaveCommand => new RelayCommand(SaveClick);
        public ICommand VosstCommand => new RelayCommand(VosstClick);

        //Отправляем данные на временное храние 
        private void SaveClick()
        {
            Model.name = NameFill;
            Model.fam = FamFill;
            Model.date = DateFill;
        }

        //Получаем данные из временного хранилища
        private void VosstClick()
        {
            NameFill = Model.name;
            FamFill = Model.fam;
            DateFill = Model.date;
        }

        public bool HasErrors => _errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }
            else
            {
                return Enumerable.Empty<string>();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        System.Collections.IEnumerable INotifyDataErrorInfo.GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
