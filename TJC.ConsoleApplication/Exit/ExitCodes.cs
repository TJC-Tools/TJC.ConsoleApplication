namespace TJC.ConsoleApplication.Exit;

[Flags]
public enum ExitCodes
{
    Success = 0,
    ProcessFailed = 0b1,
    UnknownException = 0b10,
    MissingArguments = 0b100,
    InvalidArguments = 0b1000,
    IncompatibleArguments = 0b10000,
    InvalidConfiguration = 0b100000,
    InvalidProgramming = 0b1000000,

    MissingOrInvalidArguments = MissingArguments | InvalidArguments
}