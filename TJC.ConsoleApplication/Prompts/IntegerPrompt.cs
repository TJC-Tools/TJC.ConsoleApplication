namespace TJC.ConsoleApplication.Inputs;

public partial class ConsolePrompt
{
    /// <summary>
    /// Prompts user for an integer value within a specified range.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="max"></param>
    /// <param name="min"></param>
    /// <param name="inclusive"></param>
    /// <returns></returns>
    public static int GetIntRange(
        string message,
        int max = int.MaxValue,
        int min = int.MinValue,
        bool inclusive = true
    )
    {
        var type = inclusive ? "inclusive" : "exclusive";
        var range = $"{min} to {max}, {type}";
        while (true)
        {
            try
            {
                var input = GetInt($"{message} ({range})");
                if (inclusive && input <= max && input >= min)
                    return input;
                if (!inclusive && input < max && input > min)
                    return input;
                WriteInvalidInput(additionalDetails: $"Must be an integer value {range}");
            }
            catch
            {
                WriteInvalidInput();
            }
        }
    }

    /// <summary>
    /// Prompts user for an integer value.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static int GetInt(string message) => GetType(message, Convert.ToInt32);
}
