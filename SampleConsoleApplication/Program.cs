// Setup Console Settings
ConsoleSetup.Setup(); // ConsoleSetup.SetupSilent(); // For when no output is desired (unless an error occurs)

// Parse Arguments
Arguments.Parse(args); // ConsoleArgumentsEmpty.Parse(args); // For parsing when no arguments are expected

while (true)
{
    if (ConsolePrompt.GetChoiceDone<DemoItems>("Select Demo") is not DemoItems demo)
        return; // If 'Done' is selected, end the program

    switch (demo)
    {
        case DemoItems.ThrowFault:
            EnvironmentEx.ExitCode(ExitCodes.ProcessFailed, "demo exit");
            break;
        case DemoItems.YesNo:
            var yesNo = ConsolePrompt.GetYesNo("Are you human?");
            Console.WriteLine(yesNo ? "Yes" : "No");
            break;
        case DemoItems.Numbers:
            var num = ConsolePrompt.GetInt("Enter a number");
            Console.WriteLine(num);
            var numRange = ConsolePrompt.GetIntRange("Enter a number", 10, 0);
            Console.WriteLine(numRange);
            break;
        case DemoItems.Strings:
            var str = ConsolePrompt.GetString("Enter a string");
            Console.WriteLine(str);
            str = ConsolePrompt.GetStringChange("str", str);
            Console.WriteLine(str);
            break;
        case DemoItems.Collection:
            var collection = ConsolePrompt.GetCollection("Enter a collection of strings", "str");
            Console.WriteLine(collection);
            break;
        case DemoItems.Choices:
            var options = new List<string> { "Option1", "Option2", "Option3" };
            var index = ConsolePrompt.GetChoiceIndex("Choose an option", options);
            Console.WriteLine(options[index]);
            var choice = ConsolePrompt.GetChoice("Choose an option", options);
            Console.WriteLine(choice);
            demo = ConsolePrompt.GetChoiceChange<DemoItems>("demo", demo);
            ConsolePrompt.GetChoiceChange("demo", ref demo);
            var enums = ConsolePrompt.GetCollectionEnum<DemoItems>("Select demos", "Demo");
            Console.WriteLine(enums);
            break;
        default:
            break;
    }
}
