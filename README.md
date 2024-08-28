[![NuGet Version and Downloads count](https://buildstats.info/nuget/TJC.ConsoleApplication)](https://www.nuget.org/packages/TJC.ConsoleApplication)

## Table of Contents
- [Console Setup](#console-setup)
- [Header](#header)
- [Arguments](#arguments)
- [Prompts](#prompts)
- [Exit](#exit)

---

## Console Setup
- Used to setup the console application with exceptions handling, logging, etc.


### [ConsoleSetup.Setup](./TJC.ConsoleApplication/ConsoleSetup.cs)([ConsoleSettings](./TJC.ConsoleApplication/Settings/ConsoleSettings.cs)? consoleSettings = null, [ProcessExitOptions](./TJC.ConsoleApplication/Settings/ProcessExitSettings.cs)? processExitSettings = null)
- Allows setting up the console application with a variety of options.
```c#
ConsoleSetup.Setup();
```

### [ConsoleSetup.SetupSilent](./TJC.ConsoleApplication/ConsoleSetup.cs)()
- Sets up the console application to be silent (no output to console) unless an exception occurs.
```c#
ConsoleSetup.SetupSilent();
```

---

## Header

### [ConsoleHeaderExtensions.WriteConsoleHeader](./TJC.ConsoleApplication/Header/ConsoleHeaderExtensions.cs)();
- Will write a header to the console with the application title, version, copyright, & description.
- Note: This is built into [ConsoleSetup.Setup()](./TJC.ConsoleApplication/ConsoleSetup.cs) by default.

---

## Arguments

### [Arguments](./SampleConsoleApplication/Arguments.cs) Parsing
- Use [ConsoleArguments](./TJC.ConsoleApplication/Arguments/Options/ConsoleArguments.cs) to configure the arguments that the program will accept.
- If any required arguments are missing or invalid, an error & help message will be displayed.
#### Example
In the main program, call the `Arguments.Parse(args);` to parse the arguments.
```c#
internal class Arguments
{
    internal static void Parse(string[] args) =>
        ConsoleArguments.ParseAndValidate(args, Assembly.GetCallingAssembly().GetName().Name);

    internal static DryRunArgument DryRun => DryRunArgument.Default;
    internal static bool Item1 { get; private set; }
    internal static string? Item2 { get; private set; }

    internal static readonly ConsoleArguments ConsoleArguments = new(flagRequired: true, logParsedOptions: true)
    {
        DryRun,
        { "item1", v => Item1 = !string.IsNullOrEmpty(v), "Example Item 1" },
        { "item2", v => Item2 = v, "Example Item 2" }
    };
}
```

---

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

### Choices

#### [int ConsolePrompt.GetChoiceIndex(string message, IEnumerable\<string\> choices, int offset = 1)](./TJC.ConsoleApplication/Prompts/ChoiceIndexPrompt.cs)
- Prompts the user to select an option from a list of choices
- Returns the index of the selected choice
```c#
var options = new List<string> { "Option 1", "Option 2", "Option 3" };
var index = ConsolePrompt.GetChoiceIndex("Choose", options);
// Outputs:
// Choose:
// 1. Option 1
// 2. Option 2
// 3. Option 3
```

#### [string ConsolePrompt.GetChoice(string message, IEnumerable\<string\> choices, int offset = 1)](./TJC.ConsoleApplication/Prompts/ChoiceStringPrompt.cs)
- Prompts the user to select an option from a list of choices
- Returns the string of the selected choice
```c#
var options = new List<string> { "Option 1", "Option 2", "Option 3" };
var choice = ConsolePrompt.GetChoice("Choose", options);
// Outputs:
// Choose:
// 1. Option 1
// 2. Option 2
// 3. Option 3
```

#### [T ConsolePrompt.GetChoice\<T\>(string message) where T: Enum](./TJC.ConsoleApplication/Prompts/ChoiceEnumPrompt.cs)
- Prompts the user to select an option from an enum
```c#
var choice = ConsolePrompt.GetChoice<MyEnum>("Choose");
// Outputs:
// Choose:
// 1. EnumItem1
// 2. EnumItem2
// 3. EnumItem3
```

#### [T? ConsolePrompt.GetChoiceDone\<T\>(string message) where T: Enum](./TJC.ConsoleApplication/Prompts/ChoiceEnumPrompt.cs)
- Prompts the user to select an option from an enum
- If the first option is selected, it returns null
```c#
var choice = ConsolePrompt.GetChoiceDone<MyEnum>("Choose");
// Outputs:
// Choose:
// 0. Done
// 1. EnumItem1
// 2. EnumItem2
// 3. EnumItem3
```

#### [T ConsolePrompt.GetChoiceChange\<T\>(string message, T current, T? defaultChoice) where T: Enum](./TJC.ConsoleApplication/Prompts/ChoiceEnumChangePrompt.cs)
- Prompts the user if they want to change from the currently selected enum
```c#
var choice = MyEnum.EnumItem1
choice = ConsolePrompt.GetChoiceChange<MyEnum>("choice", choice);
// Outputs:
// Change choice from [EnumItem1]? (Y/N): Y
// 1. EnumItem1
// 2. EnumItem2
// 3. EnumItem3
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

#### [ICollection\<T\> ConsolePrompt.GetCollectionEnum\<T\>(string message, string messageIndividual = "")](./TJC.ConsoleApplication/Prompts/CollectionEnumPrompt.cs)
- Prompts the user to enter a collection of enums
```c#
var collection = ConsolePrompt.GetCollectionEnum<MyEnum>("Enter a collection of enums");
```

---

## Exit

### [ProcessExitExtensions.ConfigureProcessExitEvent](./TJC.ConsoleApplication/Exit/ProcessExitExtensions.cs)([ProcessExitSettings](./TJC.ConsoleApplication/Settings/ProcessExitSettings.cs) settings)
- Configures the process to display run time & error messages on exit
