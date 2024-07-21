namespace TJC.ConsoleApplication.Inputs;

internal static class InputHelpers
{
    internal static void WriteInvalidInput(bool inputIsReadKey = false, string? additionalDetails = null)
    {
        if (inputIsReadKey)
            ConsoleOutputHandler.Empty();
        var message = "\aInvalid Input.";
        if (!string.IsNullOrEmpty(additionalDetails))
            message += $" ({additionalDetails})";
        ConsoleOutputHandler.WriteLine(message);
    }
}