[![NuGet Version and Downloads count](https://buildstats.info/nuget/TJC.ConsoleApplication)](https://www.nuget.org/packages/TJC.ConsoleApplication)

## Inputs

### [ConsoleInput.GetYesNo(string)](./TJC.ConsoleApplication/Inputs/BooleanInput.cs)
```c#
var result = ConsoleInput.GetYesNo("Do you want to continue?");
// Outputs: Do you want to continue? (Y/N): 
// Waits for user input of 'Y' or 'N' (case-insensitive)
// Returns true if 'Y' and false if 'N'
// Outputs error message and waits for input again if input is invalid
```
