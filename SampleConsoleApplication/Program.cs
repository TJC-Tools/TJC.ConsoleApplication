var yesNo = ConsoleInput.GetYesNo("Do you want to continue?");
Console.WriteLine(yesNo ? "Yes" : "No");

var str = ConsoleInput.GetString("Enter a string");
Console.WriteLine(str);

str = ConsoleInput.GetStringChange("str", str);
Console.WriteLine(str);