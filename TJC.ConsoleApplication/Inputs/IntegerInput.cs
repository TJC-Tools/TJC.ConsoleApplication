namespace TJC.ConsoleApplication.Inputs;

public partial class ConsoleInput
{
    /// <summary>
    /// Prompts user for an integer value within a specified range.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="max"></param>
    /// <param name="min"></param>
    /// <returns></returns>
    public static int GetIntRange(string message, int max = int.MaxValue, int min = 0)
    {
        while (true)
        {
            try
            {
                var input = GetInt($"{message} ({min} to {max}, inclusive)");
                if (input <= max & input >= min)
                    return input;
                InputHelpers.WriteInvalidInput(additionalDetails: $"Must be an integer value {min} to {max}, inclusive");
            }
            catch
            {
                InputHelpers.WriteInvalidInput();
            }
        }
    }

    /// <summary>
    /// Prompts user for an integer value.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static int GetInt(string message) =>
        GetType(message, Convert.ToInt32);
}