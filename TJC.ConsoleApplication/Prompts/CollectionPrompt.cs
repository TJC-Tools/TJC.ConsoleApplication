using System.Collections.ObjectModel;

namespace TJC.ConsoleApplication.Inputs;

public partial class ConsolePrompt
{
    public static ICollection<T> GetCollection<T>(string message, Func<string?, T> func, string messageIndividual = "")
    {
        var collection = new Collection<T>();
        ConsoleOutputHandler.WriteLine($"{message} (press enter after each item | press enter on an empty line to complete the list): ");
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
                ConsolePromptHandler.WriteInvalidInput();
            }
        }
    }

    public static ICollection<string> GetCollection(string message, string messageIndividual = "") =>
        GetCollection(message, x => $"{x}", messageIndividual);

    public static ICollection<int> GetCollectionInt(string message, string messageIndividual = "") =>
        GetCollection(message, Convert.ToInt32, messageIndividual);

    public static ICollection<double> GetCollectionDouble(string message, string messageIndividual = "") =>
        GetCollection(message, Convert.ToDouble, messageIndividual);
}