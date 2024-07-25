namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended for applications which require labels.
/// </summary>
public class LabelsArgument : IConsoleArgument
{
    private static readonly string _prototype = "labels=";

    public static LabelsArgument Default => new();

    public LabelsArgument(string description = "Labels") =>
        Argument = new ConsoleArgument(null, _prototype, SetLabels, isRequired: false, description);

    public IReadOnlyList<string> Labels { get; private set; } = [];

    public ConsoleArgument Argument { get; }

    private void SetLabels(string input) =>
        Labels = input.Split(',').Select(x => x.Trim()).ToList();

    public bool HasLabel(string label) =>
        Labels.Any(x => x.Equals(label, StringComparison.CurrentCultureIgnoreCase));
}