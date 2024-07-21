namespace TJC.ConsoleApplication.Inputs;

internal static class InputHelpers
{
    internal static void WriteInvalidInput(bool inputIsReadKey = false)
    {
        if (inputIsReadKey)
            ConsoleOutputHandler.Empty();
        ConsoleOutputHandler.Write("\aInvalid Input");
    }
}