namespace TJC.ConsoleApplication.Inputs;

public partial class ConsolePrompt
{
    /// <summary>
    /// Prompts the user to select a choice, and returns the index of the selected choice.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="choices"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public static int GetChoiceIndex(string message, IEnumerable<string> choices, int offset = 1) =>
        GetChoiceIndex(message, choices.ToList(), offset);

    /// <summary>
    /// Prompts user to select a choice, and returns the index of the selected choice.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="choices"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public static int GetChoiceIndex(string message, List<string> choices, int offset = 1)
    {
        var numPadding = choices.Count.ToString().Length;
        var optionsWithNumbers = choices.Select(x => $"{(choices.IndexOf(x) + offset).ToString().PadLeft(numPadding)}. {x}");
        ConsoleOutputHandler.WriteLine(message);
        ConsoleOutputHandler.WriteLine($"\t{string.Join($"{Environment.NewLine}\t", optionsWithNumbers)}{Environment.NewLine}");
        while (true)
        {
            ConsoleOutputHandler.Write("Choice: ");
            var input = ConsoleInputHandler.ReadLine();
            if (int.TryParse(input, out var result))
                return result - offset;
            WriteInvalidInput(inputIsReadKey: true);
        }
    }
}