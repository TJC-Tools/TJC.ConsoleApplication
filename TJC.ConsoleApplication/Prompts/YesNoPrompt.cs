namespace TJC.ConsoleApplication.Inputs;

public partial class ConsolePrompt
{
    /// <summary>
    /// Prompts user for a yes or no response.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static bool GetYesNo(string message)
    {
        while (true)
        {
            ConsoleOutputHandler.Write($"{message} (Y/N): ");
            var input = ConsoleInputHandler.ReadKey();
            switch (char.ToLower(input))
            {
                case 'y':
                    ConsoleOutputHandler.Empty();
                    return true;
                case 'n':
                    ConsoleOutputHandler.Empty();
                    return false;
                default:
                    WriteInvalidInput(inputIsReadKey: true);
                    break;
            }
        }
    }
}
