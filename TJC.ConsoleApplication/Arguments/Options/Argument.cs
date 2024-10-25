namespace TJC.ConsoleApplication.Arguments.Options;

/// <summary>
/// Argument to be used in <seealso cref="IConsoleArguments"/>.
/// </summary>
public class Argument : Option
{
    #region Fields

    private IConsoleArguments? _parent;
    private readonly Func<bool?> _getIsRequired;
    private readonly Action<string> _setOptionValue;

    #endregion

    #region Constructors

    /// <summary>
    /// Constructor for the console argument.
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="prototype"></param>
    /// <param name="setOptionValue"></param>
    /// <param name="isRequired"></param>
    /// <param name="description"></param>
    /// <param name="propertyName"></param>
    /// <param name="exitIfUsed"></param>
    public Argument(IConsoleArguments? parent,
                    string prototype,
                    Action<string> setOptionValue,
                    bool? isRequired = false,
                    string? description = null,
                    string? propertyName = null,
                    bool exitIfUsed = true)
        : this(parent, prototype, setOptionValue, () => isRequired, description, propertyName, exitIfUsed)
    {
    }

    /// <summary>
    /// Base constructor for the console argument.
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="prototype"></param>
    /// <param name="setOptionValue"></param>
    /// <param name="getIsRequired"></param>
    /// <param name="description"></param>
    /// <param name="propertyName"></param>
    /// <param name="exitIfUsed"></param>
    public Argument(IConsoleArguments? parent,
                    string prototype,
                    Action<string> setOptionValue,
                    Func<bool?>? getIsRequired = null,
                    string? description = null,
                    string? propertyName = null,
                    bool exitIfUsed = true)
        : base(prototype, description)
    {
        _parent = parent;
        _setOptionValue = setOptionValue;
        PropertyName = propertyName;
        _setOptionValue += SetOptionValueTriggers;
        _getIsRequired = getIsRequired ?? (() => false);
        ExitIfUsed = exitIfUsed;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Name of the input property for use in the help menu.
    /// </summary>
    public string? PropertyName { get; }

    /// <summary>
    /// This argument is required.
    /// </summary>
    public bool? IsRequired =>
        _getIsRequired?.Invoke();

    /// <summary>
    /// This argument was selected.
    /// </summary>
    public bool IsUsed { get; private set; }

    /// <summary>
    /// Exit the application (after all arguments were parsed &amp; resolved) if this argument was used.
    /// </summary>
    public bool ExitIfUsed { get; set; }

    internal bool HasParent =>
        _parent != null;

    #endregion

    #region Methods

    #region Parent

    internal void SetParent(ConsoleArguments parent)
    {
        if (_parent != null)
            throw new Exception($"{nameof(Argument)}.{nameof(_parent)} can only be set once");
        _parent = parent;
    }

    #endregion

    #region Format Help String

    internal string GetHelpString(bool formatted = false, int prototypeWidth = 0, int propertyWidth = 0)
    {

        ArgumentNullException.ThrowIfNull(_parent);
        if (!formatted)
            return string.Concat(GetPrototypeFormat(), " ", PropertyName);
        var prototype = GetPrototypeFormat().PadRight(prototypeWidth);
        var property = PropertyName?.PadRight(propertyWidth);
        return string.Concat(prototype, " ", property);
    }

    internal string GetPrototypeFormat(bool formatted = false)
    {
        if (!formatted) // Default format 
            return $"--{Prototype.TrimEnd('=').TrimEnd(':')}";
        var flags = Prototype.TrimEnd('=').TrimEnd(':').Split('|');
        var prototype = string.Empty;
        // Single character flag is at the start with single dash (-) and a comma (,) separator 
        var singleCharFlag = flags.FirstOrDefault(x => x.Length == 1);
        prototype += singleCharFlag == null ? new string(' ', 4) : $"-{singleCharFlag}, ";
        // Other flags are at the end with double dash (--) and a pipe (|) separator 
        var otherFlags = flags.Where(x => x != singleCharFlag).ToList();
        prototype += $"--{string.Join('|', otherFlags)}";
        return prototype;
    }

    internal string GetHelpDescription()
    {
        ArgumentNullException.ThrowIfNull(_parent);
        var flags = IsRequired switch
        {
            null when _parent.FlagRequired || _parent.FlagOptional => "(Sometimes Required) ",
            true when _parent.FlagRequired => "(Required) ",
            false when _parent.FlagOptional => "(Optional) ",
            _ => string.Empty
        };
        return string.Concat(flags, Description);
    }

    /// <summary>
    /// Add a <see cref="Argument"/> to <see cref="OptionSet"/>.
    /// </summary>
    /// <param name="optionSet"></param>
    internal void AddTo(OptionSet optionSet) =>
        optionSet.Add(Prototype, Description, _setOptionValue);

    internal void Verify()
    {
        ArgumentException.ThrowIfNullOrEmpty(Prototype);
        ArgumentNullException.ThrowIfNull(_setOptionValue);
    }

    #endregion

    #endregion

    #region Events

    private void SetOptionValueTriggers(string value)
    {
        ArgumentNullException.ThrowIfNull(_parent);
        IsUsed = !string.IsNullOrEmpty(value);
        if (_parent.LogParsedOptions)
            ConsoleOutputHandler.WriteLine($"{GetPrototypeFormat()}: {value}");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="c"></param>
    protected override void OnParseComplete(OptionContext c)
    {
    }

    #endregion
}