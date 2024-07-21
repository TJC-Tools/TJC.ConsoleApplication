var yesNo = ConsoleInput.GetYesNo("Do you want to continue?");
Console.WriteLine(yesNo ? "Yes" : "No");

var str = ConsoleInput.GetString("Enter a string");
Console.WriteLine(str);

str = ConsoleInput.GetStringChange("str", str);
Console.WriteLine(str);

var num = ConsoleInput.GetInt("Enter a number");
Console.WriteLine(num);

var num2 = ConsoleInput.GetIntRange("Enter a number", 10, 0);
Console.WriteLine(num2);