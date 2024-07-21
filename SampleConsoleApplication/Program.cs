while (true)
{
    var demo = ConsolePrompt.GetChoiceDone<DemoItems>("Select Demo");
    if (demo == null)
        return;

    switch (demo)
    {
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
            break;
        default:
            break;
    }
}