var options = new List<string> { "Option1", "Option2", "Option3" };
var index = ConsolePrompt.GetChoiceIndex("Choose an option", options);
Console.WriteLine(options[index]);

var choice = ConsolePrompt.GetChoice("Choose an option", options);
Console.WriteLine(choice);

var yesNo = ConsolePrompt.GetYesNo("Do you want to continue?");
Console.WriteLine(yesNo ? "Yes" : "No");

var str = ConsolePrompt.GetString("Enter a string");
Console.WriteLine(str);

str = ConsolePrompt.GetStringChange("str", str);
Console.WriteLine(str);

var num = ConsolePrompt.GetInt("Enter a number");
Console.WriteLine(num);

var num2 = ConsolePrompt.GetIntRange("Enter a number", 10, 0);
Console.WriteLine(num2);

var collection = ConsolePrompt.GetCollection("Enter a collection of strings", "str");
Console.WriteLine(collection);