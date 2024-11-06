using System.ComponentModel;

namespace SampleConsoleApplication.Enums
{
    internal enum CommandTypes
    {
        [Description("Test something")]
        Test,

        [Description("Run some code")]
        Run,

        [Description("Validate some information")]
        Validate,

        [Description("Generate a value")]
        GenerateValue,

        [Description("List some items")]
        ListItems,
    }
}
