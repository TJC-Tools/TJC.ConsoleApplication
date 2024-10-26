namespace TJC.ConsoleApplication.Arguments.Options;

/// <summary>
/// Console arguments with a command to be parsed at program startup.
/// <para></para>
/// This requires a command enum to be the first argument.
/// </summary>
public class ConsoleArgumentsWithCommand<TCommandEnum>
    : ConsoleArguments
    where TCommandEnum : struct, Enum
{
    #region Fields

    private readonly Func<TCommandEnum, string>? _getCommandHelp;
    private readonly EnumArgument<TCommandEnum> _commandArgument;

    #endregion

    #region Constructor

    /// <summary>
    /// Create Console Arguments with Command &amp; Optional Settings.
    /// </summary>
    /// <param name="commandRequired"></param>
    /// <param name="getCommandHelp"></param>
    /// <param name="flagRequired"></param>
    /// <param name="flagOptional"></param>
    /// <param name="logParsedOptions"></param>
    public ConsoleArgumentsWithCommand(
        bool commandRequired = true,
        Func<TCommandEnum, string>? getCommandHelp = null,
        bool flagRequired = false,
        bool flagOptional = false,
        bool logParsedOptions = false)
        : base(flagRequired, flagOptional, logParsedOptions)
    {
        _getCommandHelp = getCommandHelp;
        _commandArgument = new EnumArgument<TCommandEnum>(description: string.Empty, isRequired: commandRequired);

        // Disable general help, so that the command specific help can be displayed instead
        HelpArgument.Instance.OptionWriteGeneralHelp = false;
        HelpArgument.Instance.Argument.ExitIfUsed = false;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Selected command from the command line arguments.
    /// </summary>
    public TCommandEnum? Command => _commandArgument.Selection;

    #endregion

    #region Methods

    /// <inheritdoc/>
    public override void ParseAndValidate(string[] args, string? programName = null, bool exitOnFailureToParse = true)
    {
        // Parse the command
        if (ParseCommand(args))
            args = args.Skip(1).ToArray(); // Remove the command from the arguments

        // Parse the remaining arguments
        ConsoleArgumentsParsing.ParseAndValidate(this, args, programName, exitOnFailureToParse);

        // Display the help menu
        if (HelpArgument.Instance.Argument.IsUsed)
            WriteHelp(programName);

        // If the command is required and not parsed, exit with an error
        if (Command == null && (_commandArgument.Argument.IsRequired ?? false))
            EnvironmentEx.ExitCode(ExitCodes.MissingArguments, "Command is required.");
    }

    // Attempt to parse the command from the first argument
    private bool ParseCommand(string[] args)
    {
        if (args.Length == 0 || args[0].StartsWith('-'))
            return false; // First argument is not a command

        // Try to parse the command
        ConsoleArgumentsParsing.ParseArguments([_commandArgument.Argument], [$"--{args[0]}"], out _);
        return Command != null;
    }

    private void WriteHelp(string? programName)
    {
        if (Command != null)
            WriteCommandHelp(Command.Value);
        else
            WriteGeneralHelp(programName);

        EnvironmentEx.ExitCode(ExitCodes.Success);
    }

    private void WriteCommandHelp(TCommandEnum command)
    {
        // Display the title for the command help
        var helpTitle = $"| {command.ToString().SplitCodeCase()} Help |";
        var bar = new string('=', helpTitle.Length);
        ConsoleOutputHandler.WriteLine(bar);
        ConsoleOutputHandler.WriteLine(helpTitle);
        ConsoleOutputHandler.WriteLine(bar);
        ConsoleOutputHandler.Empty();

        // Display the command help details
        var commandHelp = _getCommandHelp?.Invoke(command);
        commandHelp = !string.IsNullOrWhiteSpace(commandHelp) ? commandHelp : "No Help Available.";
        ConsoleOutputHandler.WriteLine(commandHelp);
    }

    /// <inheritdoc/>
    public override void WriteGeneralHelp(string? programName = null)
    {
        ConsoleOutputHandler.Silent = false;
        this.WriteUsage(programName, "[command]");
        ConsoleOutputHandler.Empty();
        _commandArgument.WriteEnums(title: "Available Commands:", argumentPrefix: string.Empty);
        ConsoleOutputHandler.Empty();
        this.WriteFlags();
        if (_getCommandHelp != null)
        {
            ConsoleOutputHandler.Empty();
            ConsoleOutputHandler.WriteLine($"Use \"{programName} [command] {HelpArgument.StandardPrototype}\" for more information about a command.");
        }
    }

    #endregion
}