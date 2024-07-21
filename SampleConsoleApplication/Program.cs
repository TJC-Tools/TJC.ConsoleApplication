using TJC.ConsoleApplication.Inputs;

var yesNo = BooleanInput.GetYesNo("Do you want to continue?");
Console.WriteLine(yesNo ? "Yes" : "No");
