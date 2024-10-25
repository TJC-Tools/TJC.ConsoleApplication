namespace TJC.ConsoleApplication.Arguments.Options;

/// <summary>
/// Console arguments to be parsed in <seealso cref="ConsoleArgumentsParsing"/> at program startup.
/// </summary>
public class ConsoleArguments : List<Argument>, IConsoleArguments
{
    #region Fields

    private bool _flagRequired;
    private bool _flagOptional;
    private bool _logParsedOptions;

    #endregion

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
        _flagRequired = flagRequired;
        _flagOptional = flagOptional;
        _logParsedOptions = logParsedOptions;
        Add(HelpArgument.Instance);
    }

    #endregion

    #region Properties

    bool IConsoleArguments.FlagRequired
    {
        get => _flagRequired;
        set => _flagRequired = value;
    }

    bool IConsoleArguments.FlagOptional
    {
        get => _flagOptional;
        set => _flagOptional = value;
    }

    bool IConsoleArguments.LogParsedOptions
    {
        get => _logParsedOptions;
        set => _logParsedOptions = value;
    }

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
        VerifyAdd(argument.Argument);
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
        VerifyAdd(argument.Argument);
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
        VerifyAdd(argument.Argument);
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
        VerifyAdd(argument.Argument);
        Add(argument.Argument);
        SetParents();
        return this;
    }

    private void VerifyAdd(Argument argument)
    {
        ArgumentException.ThrowIfNullOrEmpty(argument.Prototype);
        ArgumentNullException.ThrowIfNull(argument.Action);
    }

    private void SetParents()
    {
        foreach (var argument in this.Where(x => !x.HasParent))
            argument.SetParent(this);
    }

    #endregion

    #region Parse

    /// <inheritdoc/>
    public virtual void ParseAndValidate(string[] args, string? programName = null, bool exitOnFailureToParse = true) =>
        ConsoleArgumentsParsing.ParseAndValidate(this, args, programName, exitOnFailureToParse);

    #endregion

    #endregion
}