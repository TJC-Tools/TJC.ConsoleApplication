[![NuGet Version and Downloads count](https://buildstats.info/nuget/TJC.ConsoleApplication)](https://www.nuget.org/packages/TJC.ConsoleApplication)

## Inputs

### Boolean

#### [bool ConsoleInput.GetYesNo(string message)](./TJC.ConsoleApplication/Inputs/BooleanInput.cs)
- Prompts the user with the message and waits for a 'Y' or 'N' input (case-insensitive)
- Outputs error message and waits for input again if input is invalid
- Returns true if 'Y' and false if 'N'
```c#
var result = ConsoleInput.GetYesNo("Do you want to continue?");
// Outputs: Do you want to continue? (Y/N): 
```

### Text

#### [string ConsoleInput.GetString(string message)](./TJC.ConsoleApplication/Inputs/StringInput.cs)
- Prompts the user with the message and waits for a string input
```c#
var result = ConsoleInput.GetString("Enter your name:");
// Outputs: Enter your name:
```

#### [string ConsoleInput.GetStringChange(string message, string original)](./TJC.ConsoleApplication/Inputs/StringInput.cs)
- Prompts the user to choose whether to change from original value or not
```c#
var original = "John"
var result = ConsoleInput.GetStringChange("MyName", original);
// Outputs: Do you want to change MyName from [John]? (Y/N):
// Waits for user input of 'Y' or 'N' (case-insensitive)
// Returns the original value if 'N' otherwise prompts for a new value like so:
// Outputs: MyName:
```

#### [ConsoleInput.GetStringChange(string message, ref string value)](./TJC.ConsoleApplication/Inputs/StringInput.cs)
- Prompts the user to choose whether to change from original value or not
```c#
var original = "John"
ConsoleInput.GetStringChange("MyName", ref original);
// Outputs: Do you want to change MyName from [John]? (Y/N):
// Waits for user input of 'Y' or 'N' (case-insensitive)
// Returns the original value if 'N' otherwise prompts for a new value like so
// Outputs: MyName:
```

### Numbers

#### [ConsoleInput.GetInt(string message)](./TJC.ConsoleApplication/Inputs/IntegerInput.cs)
- Prompts the user to enter an integer
- Outputs error message and waits for input again if input is invalid
```c#
ConsoleInput.GetInt("Enter Value");
```

#### [ConsoleInput.GetIntRange(string message, int max, int min)](./TJC.ConsoleApplication/Inputs/IntegerInput.cs)
- Prompts the user to enter an integer within a specified range
- Outputs error message and waits for input again if input is invalid
```c#
ConsoleInput.GetInt("Enter Value", 10, 1);
```
