namespace TJC.ConsoleApplication.Inputs;

public partial class ConsolePrompt
{
    /// <summary>
    /// Prompts the user to select a choice from a list of choices, and returns the selected choice as a string.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="choices"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public static string GetChoice(string message, IEnumerable<string> choices, int offset = 1) =>
        choices.ToList()[GetChoiceIndex(message, choices.ToList(), offset)];
}
