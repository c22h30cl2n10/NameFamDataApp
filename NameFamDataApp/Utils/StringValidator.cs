using System.Text.RegularExpressions;

class StringValidator
{
    public static string Validate(string input)
    {
        string error = null;
        if(input == "")
        {
            error = "Поле не должно быть пустым!";
        }
        if(Regex.IsMatch(input, @"[\d\W]"))
        {
            error = "Поле не должно содержать цифр или спецсимволов";
        }
        return error;
    }
}
