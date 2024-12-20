﻿// Setup Console Settings
ProcessExitSettings.Instance.ExitCountdownSeconds = 0;
ConsoleSetup.Setup();

//ConsoleSetup.Setup(); // ConsoleSetup.SetupSilent(); // For when no output is desired (unless an error occurs)

// Parse Arguments
//Arguments.Parse(args);
Arguments.ParseWithCommand(args);

// ConsoleArgumentsEmpty.Parse(args); // For parsing when no arguments are expected

while (true)
{
    if (ConsolePrompt.GetChoiceDone<DemoItems>("Select Demo") is not { } demo)
        return; // If 'Done' is selected, end the program

    switch (demo)
    {
        case DemoItems.ThrowFault:
            EnvironmentEx.ExitCode(ExitCodes.ProcessFailed, "demo exit");
            break;
        case DemoItems.YesNo:
            var yesNo = ConsolePrompt.GetYesNo("Are you human?");
            Trace.WriteLine(yesNo ? "Yes" : "No");
            break;
        case DemoItems.Numbers:
            var num = ConsolePrompt.GetInt("Enter a number");
            Trace.WriteLine(num);
            var numRange = ConsolePrompt.GetIntRange("Enter a number", 10, 0);
            Trace.WriteLine(numRange);
            break;
        case DemoItems.Strings:
            var str = ConsolePrompt.GetString("Enter a string");
            Trace.WriteLine(str);
            str = ConsolePrompt.GetStringChange("str", str);
            Trace.WriteLine(str);
            break;
        case DemoItems.Collection:
            var collection = ConsolePrompt.GetCollection("Enter a collection of strings", "str");
            Trace.WriteLine(collection);
            break;
        case DemoItems.Choices:
            var options = new List<string> { "Option1", "Option2", "Option3" };
            var index = ConsolePrompt.GetChoiceIndex("Choose an option", options);
            Trace.WriteLine(options[index]);
            var choice = ConsolePrompt.GetChoice("Choose an option", options);
            Console.WriteLine(choice);
            demo = ConsolePrompt.GetChoiceChange<DemoItems>("demo", demo);
            ConsolePrompt.GetChoiceChange("demo", ref demo);
            var enums = ConsolePrompt.GetCollectionEnum<DemoItems>("Select demos", "Demo");
            Trace.WriteLine(enums);
            break;
        default:
            break;
    }
}
