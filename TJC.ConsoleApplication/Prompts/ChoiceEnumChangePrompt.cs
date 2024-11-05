namespace TJC.ConsoleApplication.Inputs;

public partial class ConsolePrompt
{
    /// <summary>
    /// Prompt user whether they would like to change the current value of the specified enum.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="current"></param>
    /// <param name="defaultChoice"></param>
    /// <param name="offset"></param>
    public static void GetChoiceChange<T>(
        string message,
        ref T current,
        T? defaultChoice = null,
        int offset = 1
    )
        where T : struct, Enum =>
        current = GetChoiceChange(message, current: current, defaultChoice: defaultChoice, offset);

    /// <summary>
    /// Prompt user whether they would like to change the current value of the specified enum.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="current"></param>
    /// <param name="defaultChoice"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public static T GetChoiceChange<T>(
        string message,
        T current,
        T? defaultChoice = null,
        int offset = 1
    )
        where T : struct, Enum
    {
        if (!current.Equals(defaultChoice) && !GetYesNo($"Change {message} from [{current}]?"))
            return current;
        return GetChoice<T>(message, offset: offset);
    }
}
