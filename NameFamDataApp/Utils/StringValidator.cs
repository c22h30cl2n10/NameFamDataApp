using System.Text.RegularExpressions;

class StringValidator
{
    public static bool Validate(string input)
    {
        // Поиск цифр и спец символов в строке
        // Пока не пригодилось ^_^
        if(input == null)
        {
            return false;
        }
        Regex regex = new Regex("[0-9!@#$%^&*()_+]");
        return !regex.IsMatch(input);
    }
}
