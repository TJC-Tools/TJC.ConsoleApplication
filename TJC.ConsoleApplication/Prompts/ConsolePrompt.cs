namespace TJC.ConsoleApplication.Inputs;

/// <summary>
/// Allows prompting the user for input of various types.
/// </summary>
public partial class ConsolePrompt
{
    private static void WriteInvalidInput(bool inputIsReadKey = false, string? additionalDetails = null)
    {
        if (inputIsReadKey)
            ConsoleOutputHandler.Empty();
        var message = "Invalid Input.";
        if (!string.IsNullOrEmpty(additionalDetails))
            message += $" ({additionalDetails})";
        ConsoleOutputHandler.WriteLine(message);
    }
}