namespace TJC.ConsoleApplication.Inputs;

public partial class ConsoleInput
{
    /// <summary>
    /// Prompts user whether to change a string value.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="original"></param>
    public static void GetStringChange(string message, ref string original) =>
        original = GetStringChange(message, value: original);

    /// <summary>
    /// Prompts user whether to change a string value.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string GetStringChange(string message, string value)
    {
        if (string.IsNullOrEmpty(value)
         || GetYesNo($"Do you want to change {message} from [{value}]?"))
            return GetString(message);
        return value;
    }

    /// <summary>
    /// Prompts user for a string value.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
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