namespace TJC.ConsoleApplication.Inputs;

public partial class ConsolePrompt
{
    public static T? GetChoiceDone<T>(string message, string defaultOption = "Done", int offset = 0)
       where T : struct, Enum
    {
        var choice = GetChoice<T>(message: message, defaultOption: defaultOption, offset: offset, out var defaultOptionSelected);
        return defaultOptionSelected ? null : choice;
    }

    public static T GetChoice<T>(string message, int offset = 1)
       where T : Enum
    {
        while (true)
        {
            var choice = GetChoice<T>(message: message, defaultOption: null, offset: offset, out _);
            if (choice != null)
                return choice;
        }
    }

    public static T? GetChoice<T>(string message, string? defaultOption, int offset, out bool defaultOptionSelected)
        where T : Enum
    {
        var options = new List<string>();
        if (!string.IsNullOrEmpty(defaultOption))
            options.Add(defaultOption);
        var hasDefaultOption = !string.IsNullOrEmpty(defaultOption);
        foreach (var option in Enum.GetNames(typeof(T)).ToList())
        {
            Enum.TryParse(typeof(T), option, out var result);
            if (result is T item && Enum.IsDefined(typeof(T), item))
                options.Add(item.ToString());
        }

        while (true)
        {
            var index = GetChoiceIndex(message, options, offset: offset) - (hasDefaultOption ? 1 : 0);
            Enum.TryParse(typeof(T), index.ToString(), out var result);
            if (result is T item && Enum.IsDefined(typeof(T), item))
            {
                defaultOptionSelected = false;
                return item;
            }
            if (hasDefaultOption && index == -1)
            {
                defaultOptionSelected = true;
                return default;
            }
            WriteInvalidInput();
        }
    }
}