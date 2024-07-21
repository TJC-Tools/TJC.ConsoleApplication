namespace TJC.ConsoleApplication.Inputs;

public partial class ConsoleInput
{
    public static bool GetYesNo(string message)
    {
        while (true)
        {
            ConsoleOutputHandler.Write($"{message} (Y/N): ");
            var input = ConsoleInputHandler.ReadKey();
            switch (char.ToLower(input))
            {
                case 'y':
                    ConsoleOutputHandler.Empty();
                    return true;
                case 'n':
                    ConsoleOutputHandler.Empty();
                    return false;
                default:
                    InputHelpers.WriteInvalidInput(inputIsReadKey: true);
                    break;
            }
        }
    }
}