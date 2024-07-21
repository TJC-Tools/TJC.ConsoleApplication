[![NuGet Version and Downloads count](https://buildstats.info/nuget/TJC.ConsoleApplication)](https://www.nuget.org/packages/TJC.ConsoleApplication)

## Prompts

### Yes/No

#### [bool ConsolePrompt.GetYesNo(string message)](./TJC.ConsoleApplication/Prompts/YesNoPrompt.cs)
- Prompts the user with the message and waits for a 'Y' or 'N' input (case-insensitive)
- Outputs error message and waits for input again if input is invalid
- Returns true if 'Y' and false if 'N'
```c#
var result = ConsolePrompt.GetYesNo("Do you want to continue?");
// Outputs: Do you want to continue? (Y/N): 
```

### Text

#### [string ConsolePrompt.GetString(string message)](./TJC.ConsoleApplication/Prompts/StringPrompt.cs)
- Prompts the user with the message and waits for a string input
```c#
var result = ConsolePrompt.GetString("Enter your name:");
// Outputs: Enter your name:
```

#### [string ConsolePrompt.GetStringChange(string message, string original)](./TJC.ConsoleApplication/Prompts/StringPrompt.cs)
- Prompts the user to choose whether to change from original value or not
```c#
var original = "John"
var result = ConsolePrompt.GetStringChange("MyName", original);
// Outputs: Do you want to change MyName from [John]? (Y/N):
// Waits for user input of 'Y' or 'N' (case-insensitive)
// Returns the original value if 'N' otherwise prompts for a new value like so:
// Outputs: MyName:
```

#### [ConsolePrompt.GetStringChange(string message, ref string value)](./TJC.ConsoleApplication/Prompts/StringPrompt.cs)
- Prompts the user to choose whether to change from original value or not
```c#
var original = "John"
ConsolePrompt.GetStringChange("MyName", ref original);
// Outputs: Do you want to change MyName from [John]? (Y/N):
// Waits for user input of 'Y' or 'N' (case-insensitive)
// Returns the original value if 'N' otherwise prompts for a new value like so
// Outputs: MyName:
```

### Numbers

#### [int ConsolePrompt.GetInt(string message)](./TJC.ConsoleApplication/Prompts/IntegerPrompt.cs)
- Prompts the user to enter an integer
- Outputs error message and waits for input again if input is invalid
```c#
ConsolePrompt.GetInt("Enter Value");
```

#### [int ConsolePrompt.GetIntRange(string message, int max, int min, bool inclusive)](./TJC.ConsoleApplication/Prompts/IntegerPrompt.cs)
- Prompts the user to enter an integer within a specified range (inclusive or exclusive)
- Outputs error message and waits for input again if input is invalid
```c#
ConsolePrompt.GetInt("Enter Value", 10, 1);
```

### Collections

#### [ICollection\<string\> ConsolePrompt.GetCollection(string message, string messageIndividual = "")](./TJC.ConsoleApplication/Prompts/CollectionPrompt.cs)
- Prompts the user to enter a collection of strings
- If `messageIndividual` is provided, it will be used as the prompt for each item in the collection
- If no value is provided, the collection ends, and the response(s) are returned
```c#
var collection = ConsolePrompt.GetCollection("Enter a collection of strings", "str");
// Outputs: Enter a collection of strings (press enter after each item | press enter on an empty line to complete the list):
// Outputs: str:
```

#### [ICollection\<int\> ConsolePrompt.GetCollectionInt(string message, string messageIndividual = "")](./TJC.ConsoleApplication/Prompts/CollectionPrompt.cs)
- Prompts the user to enter a collection of integers
```c#
var collection = ConsolePrompt.GetCollection("Enter a collection of ints");
```

#### [ICollection\<double\> ConsolePrompt.GetCollectionDouble(string message, string messageIndividual = "")](./TJC.ConsoleApplication/Prompts/CollectionPrompt.cs)
- Prompts the user to enter a collection of doubles
```c#
var collection = ConsolePrompt.GetCollection("Enter a collection of doubles");
```
