namespace TJC.ConsoleApplication.Inputs;

public partial class ConsolePrompt
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
}