namespace SampleConsoleApplication.Commands;

internal static class CommandExtensions
{
    internal static string GetCommandHelp(this CommandTypes commandType)
    {
        return commandType switch
        {
            CommandTypes.Test => "This is the help for Test.",
            CommandTypes.Run => "This is the help for Run.",
            CommandTypes.Validate => "This is the help for Validate.",
            CommandTypes.GenerateValue => "This is the help for Generate Value.",
            CommandTypes.ListItems => "This is the help for List Items.",
            _ => string.Empty
        };
    }
}