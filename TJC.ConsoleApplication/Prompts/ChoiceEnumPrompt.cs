namespace TJC.ConsoleApplication.Inputs;

public partial class ConsolePrompt
{
    /// <summary>
    /// Prompts user to select an option from an enum or select done.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="defaultOption"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public static T? GetChoiceDone<T>(string message, string defaultOption = "Done", int offset = 0)
       where T : struct, Enum
    {
        var choice = GetChoice<T>(message: message, defaultOption: defaultOption, offset: offset, out var defaultOptionSelected);
        // If the default option was selected, return null, else return the selected option
        return defaultOptionSelected ? null : choice;
    }

    /// <summary>
    /// Prompts user to select an option from an enum.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public static T GetChoice<T>(string message, int offset = 1)
       where T : Enum
    {
        while (true)
        {
            var choice = GetChoice<T>(message: message, defaultOption: null, offset: offset, out _);
            if (choice != null) // If the response is a valid option, return it
                return choice;
        }
    }

    /// <summary>
    /// Prompts user to select an option from an enum.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="message"></param>
    /// <param name="defaultOption"></param>
    /// <param name="offset"></param>
    /// <param name="defaultOptionSelected"></param>
    /// <returns></returns>
    public static T? GetChoice<T>(string message, string? defaultOption, int offset, out bool defaultOptionSelected)
        where T : Enum
    {
        var options = new List<string>();

        // Add 'default option' to the start of the list of options
        if (!string.IsNullOrEmpty(defaultOption))
            options.Add(defaultOption);
        var hasDefaultOption = !string.IsNullOrEmpty(defaultOption);

        // Add all enum values to the list of options
        foreach (var option in Enum.GetNames(typeof(T)).ToList())
        {
            Enum.TryParse(typeof(T), option, out var result);
            if (result is T item && Enum.IsDefined(typeof(T), item))
                options.Add(item.ToString());
        }

        while (true)
        {
            // Prompt the user to select an option, and get the index of the selected option
            var index = GetChoiceIndex(message, options, offset: offset) - (hasDefaultOption ? 1 : 0);

            // Try to parse the selected index to an enum value
            Enum.TryParse(typeof(T), index.ToString(), out var result);

            if (result is T item && Enum.IsDefined(typeof(T), item))
            {
                // If the response is a valid option, return it
                defaultOptionSelected = false;
                return item;
            }

            if (hasDefaultOption && index == -1)
            {
                // If the response is the default option, return default & indicate that the default option was selected
                defaultOptionSelected = true;
                return default;
            }

            // If the response is invalid, prompt the user to try again
            WriteInvalidInput();
        }
    }
}