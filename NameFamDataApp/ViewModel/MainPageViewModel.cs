using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NameFamDataApp.ViewModel;

public partial class MainPageViewModel : ObservableObject 
{
    [ObservableProperty]
    string nameFill;
    [ObservableProperty]
    string famFill;
    [ObservableProperty]
    DateTime dateFill;



    [RelayCommand]
    void OnSaveClick()
    {
        if (StringValidator.Validate(NameFill)
            && StringValidator.Validate(FamFill))
        {
            //Запись данных из полей выбора в переменные для временного хранения
            Model.name = NameFill;
            Model.fam = FamFill;
            Model.date = DateFill;
        }
        else
        {
            Shell.Current.DisplayAlert("Валидация", "Поля 'Имя' и 'Фамилия' " +
                "не должны содержать цифр или спецсимволов", "Хорошо");
        }
    }

    [RelayCommand]
    void OnVosstClick()
    {
        //Меняем текущее значение полей на последние сохраненные данные
        NameFill = Model.name;
        FamFill = Model.fam;
        DateFill = Model.date;
    }
}

