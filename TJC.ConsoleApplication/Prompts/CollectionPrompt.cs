using System.Collections.ObjectModel;

namespace TJC.ConsoleApplication.Inputs;

public partial class ConsolePrompt
{
    /// <summary>
    ///Prompt for collection of items of specified type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message">Prompt to start collection input</param>
    /// <param name="func">Used to convert from user input (string) to the desired type</param>
    /// <param name="messageIndividual">Prompt before each item in the collection</param>
    /// <returns></returns>
    public static ICollection<T> GetCollection<T>(
        string message,
        Func<string?, T> func,
        string messageIndividual = ""
    )
    {
        var collection = new Collection<T>();
        ConsoleOutputHandler.WriteLine(
            $"{message} (press enter after each item | press enter on an empty line to complete the list): "
        );
        while (true)
        {
            if (!string.IsNullOrEmpty(messageIndividual))
                ConsoleOutputHandler.Write($"{messageIndividual}: ");
            var input = ConsoleInputHandler.ReadLine();
            if (string.IsNullOrEmpty(input))
                return collection;
            try
            {
                var item = func(input);
                collection.Add(item);
            }
            catch
            {
                WriteInvalidInput();
            }
        }
    }

    /// <summary>
    /// Prompt for collection of strings.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="messageIndividual"></param>
    /// <returns></returns>
    public static ICollection<string> GetCollection(
        string message,
        string messageIndividual = ""
    ) => GetCollection(message, x => $"{x}", messageIndividual);

    /// <summary>
    /// Prompt for collection of integers.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="messageIndividual"></param>
    /// <returns></returns>
    public static ICollection<int> GetCollectionInt(
        string message,
        string messageIndividual = ""
    ) => GetCollection(message, Convert.ToInt32, messageIndividual);

    /// <summary>
    /// Prompt for collection of doubles.
    /// </summary>
    /// <param name="message"></param>
    /// <param name="messageIndividual"></param>
    /// <returns></returns>
    public static ICollection<double> GetCollectionDouble(
        string message,
        string messageIndividual = ""
    ) => GetCollection(message, Convert.ToDouble, messageIndividual);
}
