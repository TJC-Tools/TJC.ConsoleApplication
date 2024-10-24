namespace TJC.ConsoleApplication.Arguments.Options;

/// <summary>
/// Console argument to be used in the <seealso cref="ConsoleArguments"/>.
/// </summary>
public class ConsoleArgument
{
    #region Fields

    private ConsoleArguments? _parent;
    private readonly Func<bool?> _getIsRequired;

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
    public ConsoleArgument(ConsoleArguments? parent,
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
    public ConsoleArgument(ConsoleArguments? parent,
                           string prototype,
                           Action<string> setOptionValue,
                           Func<bool?>? getIsRequired = null,
                           string? description = null,
                           string? propertyName = null,
                           bool exitIfUsed = true)
    {
        _parent = parent;
        Prototype = prototype;
        SetOptionValue = setOptionValue;
        Description = description;
        PropertyName = propertyName;
        SetOptionValue += SetOptionValueTriggers;
        _getIsRequired = getIsRequired ?? (() => false);
        ExitIfUsed = exitIfUsed;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Text for the argument to trigger this option.
    /// </summary>
    public string Prototype { get; }

    /// <summary>
    /// 
    /// </summary>
    public Action<string> SetOptionValue { get; }

    /// <summary>
    /// Description for use in the help menu.
    /// </summary>
    public string? Description { get; }

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
    /// Exit the application (after all argument were parsed &amp; resolved) if this argument is used.
    /// </summary>
    public bool ExitIfUsed { get; set; }

    /// <summary>
    /// Flags to display in the help menu.
    /// </summary>
    public string Flags
    {
        get
        {
            ArgumentNullException.ThrowIfNull(_parent);
            return IsRequired switch
            {
                null when _parent.FlagRequired || _parent.FlagOptional => "(Sometimes Required) ",
                true when _parent.FlagRequired => "(Required) ",
                false when _parent.FlagOptional => "(Optional) ",
                _ => string.Empty
            };
        }
    }

    internal bool HasParent =>
        _parent != null;

    #endregion

    #region Methods

    #region Parent

    internal void SetParent(ConsoleArguments parent)
    {
        if (_parent != null)
            throw new Exception($"{nameof(ConsoleArgument)}.{nameof(_parent)} can only be set once");
        _parent = parent;
    }

    #endregion

    #region Format Help String

    private static int? _maxPrototypeWidth;
    private static int? _maxPropertyWidth;

    internal string GetHelpString(bool formatted = false)
    {
        ArgumentNullException.ThrowIfNull(_parent);
        if (!formatted)
            return string.Concat(GetPrototypeFormat(), GetPropertyHelp());
        _maxPrototypeWidth ??= _parent.Max(x => x.GetPrototypeFormat().Length);
        _maxPropertyWidth ??= _parent.Max(x => x.GetPropertyHelp().Length);
        var prototype = GetPrototypeFormat().PadRight((int)_maxPrototypeWidth);
        var property = GetPropertyHelp().PadRight((int)_maxPropertyWidth);
        return string.Concat(prototype, property);
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

    internal string GetPropertyHelp() =>
        string.IsNullOrEmpty(PropertyName) ? string.Empty : $" {PropertyName}";

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

    #endregion
}