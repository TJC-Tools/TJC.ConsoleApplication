namespace TJC.ConsoleApplication.Inputs;

public partial class ConsolePrompt
{
    /// <summary>
    /// Prompts user for a string value.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static string GetString(string message)
    {
        while (true)
        {
            ConsoleOutputHandler.Write($"{message}: ");
            var input = ConsoleInputHandler.ReadLine();
            if (!string.IsNullOrEmpty(input))
                return input;
            WriteInvalidInput();
        }
    }
}