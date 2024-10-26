using TJC.Singleton;

namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is used to show the help menu.
/// </summary>
public class HelpArgument
    : SingletonBase<HelpArgument>,
    ICustomArgument
{
    private const string Prototype = "h|?|help";

    /// <summary>
    /// Singleton Constructor.
    /// </summary>
    private HelpArgument()
    {
    }

    /// <summary>
    /// Default settings for the help argument.
    /// </summary>
    public static HelpArgument Default => new();

    /// <summary>
    /// Argument to be added to the list of <seealso cref="ConsoleArguments"/>.
    /// </summary>
    public Argument Argument { get; } = new(null, Prototype, v => { }, isRequired: false, "Show Help Menu", exitIfUsed: true);

    /// <summary>
    /// If true, write the general help menu.
    /// <para></para>
    /// Otherwise, allow this to be used as a flag to show specific help menu(s).
    /// </summary>
    public bool OptionWriteGeneralHelp { get; set; } = true;

    /// <summary>
    /// Get whether the general help menu should be written.
    /// </summary>
    /// <returns></returns>
    public bool GetWriteGeneralHelp() => OptionWriteGeneralHelp && Argument.IsUsed;
}