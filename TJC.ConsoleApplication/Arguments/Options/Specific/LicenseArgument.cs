using System.Reflection;
using TJC.AssemblyExtensions.Attributes;

namespace TJC.ConsoleApplication.Arguments.Options.Specific;

/// <summary>
/// This argument is intended to print the license of the application.
/// </summary>
/// <param name="description"></param>
/// <param name="exitIfUsed"></param>
/// <param name="includeThirdPartyLicenses"></param>
public class LicenseArgument(
    string description = "Print the license of the application",
    bool exitIfUsed = true,
    bool includeThirdPartyLicenses = true
) : ICustomArgument
{
    private const string Prototype = "license";

    /// <summary>
    /// Default settings for the license argument.
    /// </summary>
    public static LicenseArgument Default => new();

    /// <summary>
    /// Argument to be added to the list of <seealso cref="ConsoleArguments"/>.
    /// </summary>
    public Argument Argument { get; } =
        new Argument(
            null,
            Prototype,
            v => Execute(includeThirdPartyLicenses),
            isRequired: false,
            description: description,
            exitIfUsed: exitIfUsed
        );

    private static void Execute(bool includeThirdPartyLicenses)
    {
        var assembly = Assembly.GetEntryAssembly();
        var licenses = new List<string?> { assembly?.GetLicense() };
        if (includeThirdPartyLicenses)
            licenses.Add(assembly?.GetThirdPartyLicenses());
        licenses = licenses.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        ConsoleOutputHandler.WriteLine(string.Join(Environment.NewLine, licenses));
    }
}
