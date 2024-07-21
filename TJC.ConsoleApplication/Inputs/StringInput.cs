namespace TJC.ConsoleApplication.Inputs;

public partial class ConsoleInput
{
    public static void GetStringChange(string message, ref string original) =>
        original = GetStringChange(message, value: original);

    public static string GetStringChange(string message, string value)
    {
        if (string.IsNullOrEmpty(value)
         || GetYesNo($"Do you want to change {message} from [{value}]?"))
            return GetString(message);
        return value;
    }

    public static string GetString(string message)
    {
        while (true)
        {
            ConsoleOutputHandler.Write($"{message}: ");
            var input = ConsoleInputHandler.ReadLine();
            if (!string.IsNullOrEmpty(input))
                return input;
            InputHelpers.WriteInvalidInput();
        }
    }
}