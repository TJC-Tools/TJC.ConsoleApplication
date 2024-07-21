namespace TJC.ConsoleApplication.Handlers;

internal static class ConsolePromptHandler
{
    internal static void WriteInvalidInput(bool inputIsReadKey = false, string? additionalDetails = null)
    {
        if (inputIsReadKey)
            ConsoleOutputHandler.Empty();
        var message = "Invalid Input.";
        if (!string.IsNullOrEmpty(additionalDetails))
            message += $" ({additionalDetails})";
        ConsoleOutputHandler.WriteLine(message);
    }
}