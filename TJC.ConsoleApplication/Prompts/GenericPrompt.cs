namespace TJC.ConsoleApplication.Inputs;

public partial class ConsolePrompt
{
    /// <summary>
    /// Prompts user for a value, and attempts to convert it to a specified type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="func"></param>
    /// <returns></returns>
    public static T GetType<T>(string message, Func<string?, T> func)
    {
        while (true)
        {
            ConsoleOutputHandler.Write($"{message}: ");
            var input = ConsoleInputHandler.ReadLine();
            try
            {
                return func(input);
            }
            catch
            {
                WriteInvalidInput();
            }
        }
    }
}