namespace TJC.ConsoleApplication.Arguments.Options;

/// <summary>
/// Console arguments to be parsed in <seealso cref="ConsoleArgumentsParsing"/> at program startup.
/// </summary>
public class ConsoleArguments : List<Argument>, IConsoleArguments
{
    #region Constructor

    /// <summary>
    /// Create Console Arguments with optional settings.
    /// </summary>
    /// <param name="flagRequired"></param>
    /// <param name="flagOptional"></param>
    /// <param name="logParsedOptions"></param>
    public ConsoleArguments(
        bool flagRequired = false,
        bool flagOptional = false,
        bool logParsedOptions = false)
    {
        FlagRequired = flagRequired;
        FlagOptional = flagOptional;
        LogParsedOptions = logParsedOptions;
        Add(HelpArgument.Instance);
    }

    #endregion

    #region Properties

    /// <summary>
    /// Flag required options in help menu.
    /// </summary>
    public bool FlagRequired { get; set; }

    /// <summary>
    /// Flag optional options in help menu.
    /// </summary>
    public bool FlagOptional { get; set; }

    /// <summary>
    /// Write parsed options to the console.
    /// </summary>
    public bool LogParsedOptions { get; set; }

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
        var argument = new Argument(this, prototype, setOptionValue, required, description, propertyName, exitIfUsed);
        argument.Verify();
        Add(argument);
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
        var argument = new Argument(this, prototype, setOptionValue, getIsRequired, description, propertyName, exitIfUsed);
        argument.Verify();
        Add(argument);
        return this;
    }

    /// <summary>
    /// Insert Common Argument
    /// </summary>
    /// <param name="index"></param>
    /// <param name="argument"></param>
    /// <returns></returns>
    public ConsoleArguments Insert(int index, ICustomArgument argument)
    {
        argument.Argument.Verify();
        Insert(index, argument.Argument);
        SetParents();
        return this;
    }

    /// <summary>
    /// Add Common Argument
    /// </summary>
    /// <param name="argument"></param>
    /// <returns></returns>
    public ConsoleArguments Add(ICustomArgument argument)
    {
        argument.Argument.Verify();
        Add(argument.Argument);
        SetParents();
        return this;
    }

    private void SetParents()
    {
        foreach (var argument in this.Where(x => !x.HasParent))
            argument.SetParent(this);
    }

    #endregion

    #region Parse

    /// <summary>
    /// Parses Options, and Validates that there are no Invalid or Missing Arguments
    /// </summary>
    /// <param name="args">Arguments from console application call</param>
    /// <param name="programName">Name of Program</param>
    /// <param name="exitOnFailureToParse">Exit Program on Failure to Parse</param>
    public virtual void ParseAndValidate(string[] args,
                                        string? programName = null,
                                        bool exitOnFailureToParse = true) =>
        ConsoleArgumentsParsing.DoParseAndValidate(this, args, programName, exitOnFailureToParse);

    IEnumerator<Argument> IEnumerable<Argument>.GetEnumerator()
    {
        foreach (var argument in this)
            yield return argument;
    }

    #endregion

    #endregion
}