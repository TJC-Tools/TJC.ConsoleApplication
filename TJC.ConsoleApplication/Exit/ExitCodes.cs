namespace TJC.ConsoleApplication.Exit;

/// <summary>
/// Exit codes for the application.
/// </summary>
[Flags]
public enum ExitCodes
{
    /// <summary>
    /// Process exited successfully.
    /// </summary>
    Success = 0,

    /// <summary>
    /// Process failed.
    /// </summary>
    ProcessFailed = 0b1,

    /// <summary>
    /// Unknown exception occurred.
    /// </summary>
    UnknownException = 0b10,

    /// <summary>
    /// Missing required arguments.
    /// </summary>
    MissingArguments = 0b100,

    /// <summary>
    /// Provided arguments are invalid.
    /// </summary>
    InvalidArguments = 0b1000,

    /// <summary>
    /// Incompatible arguments provided.
    /// </summary>
    IncompatibleArguments = 0b10000,

    /// <summary>
    /// Invalid configuration.
    /// </summary>
    InvalidConfiguration = 0b100000,

    /// <summary>
    /// Invalid programming.
    /// </summary>
    InvalidProgramming = 0b1000000,

    // Combination Exit Codes

    /// <summary>
    /// Arguments are missing &amp; some provided argument are invalid.
    /// </summary>
    MissingOrInvalidArguments = MissingArguments | InvalidArguments,
}
