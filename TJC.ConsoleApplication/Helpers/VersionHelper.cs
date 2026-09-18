using System.Diagnostics;
using System.Reflection;
using TJC.ConsoleApplication.Settings;

namespace TJC.ConsoleApplication.Helpers;

internal static class VersionHelper
{
    internal static string? GetVersion(this Assembly? assembly)
    {
        assembly ??= Assembly.GetEntryAssembly();

        if (assembly is null)
            return null;

        return ConsoleSettings.Instance.VersionType switch
        {
            VersionType.Version => assembly.GetName().Version?.ToString(),
            VersionType.InformationalVersion => assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion,
            VersionType.FileVersion => assembly.GetCustomAttribute<AssemblyFileVersionAttribute>()?
                .Version,
            VersionType.ProductVersion => string.IsNullOrEmpty(assembly.Location)
                ? null
                : FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion,
            _ => assembly.GetName().Version?.ToString(),
        };
    }

    internal static string? FormatVersion(this string? version, int digits)
    {
        if (version is null || !Version.TryParse(version, out var parsedVersion))
            return version;

        return parsedVersion.ToString(digits);
    }
}