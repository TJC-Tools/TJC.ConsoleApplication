namespace TJC.ConsoleApplication.Arguments.Options;

/// <summary>
/// Console arguments to be parsed in <seealso cref="ConsoleArgumentsParsing"/> at program startup.
/// </summary>
/// <param name="flagRequired"></param>
/// <param name="flagOptional"></param>
/// <param name="logParsedOptions"></param>
public class ConsoleArguments(
    bool flagRequired = false,
    bool flagOptional = false,
    bool logParsedOptions = false)
    : List<ConsoleArgument>
{
    #region Properties

    /// <summary>
    /// Flag required options in help menu.
    /// </summary>
    public bool FlagRequired { get; set; } = flagRequired;

    /// <summary>
    /// Flag optional options in help menu.
    /// </summary>
    public bool FlagOptional { get; set; } = flagOptional;

    /// <summary>
    /// Write parsed options to the console.
    /// </summary>
    public bool LogParsedOptions { get; set; } = logParsedOptions;

    #endregion

    #region Methods

    #region Add Argument Option

    /// <summary>
    /// Add an argument to the list of known arguments
    /// <para>Each argument can supply their value to a property using an <see cref="Action"/></para>
    /// <para>For strings, simply set the value</para>
    /// <code>v => PropertyName = v</code>
    /// <para>For booleans, check if the string is null; e.g.</para>
    /// <code>v => PropertyName = !string.IsNullOrEmpty(v)</code>
    /// <para>For lists, add it to the list</para>
    /// <code>v => PropertyName.Add(v)</code>
    /// </summary>
    /// <param name="prototype">Name of the Argument</param>
    /// <param name="setOptionValue">Action to supply the value to a property</param>
    /// <param name="description">Description for help menu</param>
    /// <param name="propertyName">Property name for help menu</param>
    /// <returns></returns>
    public ConsoleArguments Add(string prototype,
                                Action<string> setOptionValue,
                                string? description = null,
                                string? propertyName = null) =>
        Add(prototype, setOptionValue, description, propertyName, required: false, exitIfUsed: false);

    /// <summary>
    /// Add an argument to the list of known arguments
    /// <para>Each argument can supply their value to a property using an <see cref="Action"/></para>
    /// <para>For strings, simply set the value</para>
    /// <code>v => PropertyName = v</code>
    /// <para>For booleans, check if the string is null; e.g.</para>
    /// <code>v => PropertyName = !string.IsNullOrEmpty(v)</code>
    /// <para>For lists, add it to the list</para>
    /// <code>v => PropertyName.Add(v)</code>
    /// </summary>
    /// <param name="prototype">Name of the Argument</param>
    /// <param name="setOptionValue">Action to supply the value to a property</param>
    /// <param name="description">Description for help menu</param>
    /// <param name="propertyName">Property name for help menu</param>
    /// <param name="required">Whether the argument is always required</param>
    /// <param name="exitIfUsed">Exit if argument is used</param>
    /// <returns></returns>
    public ConsoleArguments Add(string prototype,
                                Action<string> setOptionValue,
                                string? description,
                                string? propertyName,
                                bool? required,
                                bool exitIfUsed)
    {
        VerifyAdd(prototype, setOptionValue);
        Add(new ConsoleArgument(this, prototype, setOptionValue, required, description, propertyName, exitIfUsed));
        return this;
    }

    /// <summary>
    /// Add an argument to the list of known arguments
    /// <para>Each argument can supply their value to a property using an <see cref="Action"/></para>
    /// <para>For strings, simply set the value</para>
    /// <code>v => PropertyName = v</code>
    /// <para>For booleans, check if the string is null; e.g.</para>
    /// <code>v => PropertyName = !string.IsNullOrEmpty(v)</code>
    /// <para>For lists, add it to the list</para>
    /// <code>v => PropertyName.Add(v)</code>
    /// <para>The Is Required is dynamically determined by a function.</para>
    /// </summary>
    /// <param name="prototype">Name of the Argument</param>
    /// <param name="setOptionValue">Action to supply the value to a property</param>
    /// <param name="description">Description for help menu</param>
    /// <param name="propertyName">Property name for help menu</param>
    /// <param name="getIsRequired">Function to determine if this argument is required is these circumstances</param>
    /// <param name="exitIfUsed">Exit if argument is used</param>
    /// <returns></returns>
    public ConsoleArguments Add(string prototype,
                                Action<string> setOptionValue,
                                string? description,
                                string? propertyName,
                                Func<bool?>? getIsRequired,
                                bool exitIfUsed)
    {
        VerifyAdd(prototype, setOptionValue);
        Add(new ConsoleArgument(this, prototype, setOptionValue, getIsRequired, description, propertyName, exitIfUsed));
        return this;
    }

    /// <summary>
    /// Insert Common Argument
    /// </summary>
    /// <param name="index"></param>
    /// <param name="argument"></param>
    /// <returns></returns>
    public ConsoleArguments Insert(int index, IConsoleArgument argument)
    {
        VerifyAdd(argument.Argument.Prototype, argument.Argument.SetOptionValue);
        Insert(index, argument.Argument);
        SetParents();
        return this;
    }

    /// <summary>
    /// Add Common Argument
    /// </summary>
    /// <param name="argument"></param>
    /// <returns></returns>
    public ConsoleArguments Add(IConsoleArgument argument)
    {
        VerifyAdd(argument.Argument.Prototype, argument.Argument.SetOptionValue);
        Add(argument.Argument);
        SetParents();
        return this;
    }

    private static void VerifyAdd(string prototype, Action<string> setOptionValue)
    {
        ArgumentException.ThrowIfNullOrEmpty(prototype);
        ArgumentNullException.ThrowIfNull(setOptionValue);
    }

    private void SetParents()
    {
        foreach (var argument in this.Where(x => !x.HasParent))
            argument.SetParent(this);
    }

    #endregion

    #endregion
}