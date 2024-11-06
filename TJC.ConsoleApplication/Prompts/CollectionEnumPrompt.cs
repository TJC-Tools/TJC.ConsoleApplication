namespace TJC.ConsoleApplication.Inputs;

public partial class ConsolePrompt
{
    /// <summary>
    /// Prompts the user to select a list of enum items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="messageIndividual"></param>
    /// <returns></returns>
    public static ICollection<T> GetCollectionEnum<T>(
        string message,
        string? messageIndividual = null
    )
        where T : struct, Enum
    {
        var list = new List<T>();

        // Prompt user to enter items
        ConsoleOutputHandler.WriteLine($"{message}: ");
        while (true)
        {
            // Prompt for each item
            if (!string.IsNullOrEmpty(messageIndividual))
                ConsoleOutputHandler.Write($"{messageIndividual}: ");

            var item = GetChoiceDone<T>(string.Empty);

            // If item is null ('Done' was selected), return list
            if (item is null)
                return list;

            // Otherwise, add item to the list
            if (item is T result)
                list.Add(result);
        }
    }
}
