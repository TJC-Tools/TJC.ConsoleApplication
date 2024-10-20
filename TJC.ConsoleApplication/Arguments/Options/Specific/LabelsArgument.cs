namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended for applications which require labels.
/// </summary>
public class LabelsArgument : IConsoleArgument
{
    private static readonly string _prototype = "labels=";

    /// <summary>
    /// Default settings for the labels argument.
    /// </summary>
    public static LabelsArgument Default => new();

    /// <summary>
    /// Constructor for the labels argument.
    /// </summary>
    /// <param name="description"></param>
    public LabelsArgument(string description = "Labels") =>
        Argument = new ConsoleArgument(null, _prototype, SetLabels, isRequired: false, description);

    /// <summary>
    /// List of labels set by the argument.
    /// </summary>
    public IReadOnlyList<string> Labels { get; private set; } = [];

    /// <summary>
    /// Argument to be added to the list of <seealso cref="ConsoleArguments"/>.
    /// </summary>
    public ConsoleArgument Argument { get; }

    private void SetLabels(string input) =>
        Labels = input.Split(',').Select(x => x.Trim()).ToList();

    /// <summary>
    /// Check if a specific label was set by the argument.
    /// </summary>
    /// <param name="label"></param>
    /// <returns></returns>
    public bool HasLabel(string label) =>
        Labels.Any(x => x.Equals(label, StringComparison.CurrentCultureIgnoreCase));
}