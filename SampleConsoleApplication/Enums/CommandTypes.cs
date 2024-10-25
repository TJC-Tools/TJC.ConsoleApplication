using System.ComponentModel;

namespace SampleConsoleApplication.Enums
{
    internal enum CommandTypes
    {
        [Description("This is the first command")]
        Command1,
        [Description("This is the second command")]
        Command_2,
        Command3
    }
}