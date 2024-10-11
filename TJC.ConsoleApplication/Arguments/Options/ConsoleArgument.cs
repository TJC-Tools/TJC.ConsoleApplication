namespace TJC.ConsoleApplication.Arguments.Options;

public class ConsoleArgument
{
    #region Fields

    private ConsoleArguments? _parent;
    private readonly Func<bool?> _getIsRequired;

    #endregion

    #region Constructors

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
    public bool? IsRequired => _getIsRequired?.Invoke();

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

    #endregion

    #region Methods

    #region Parent

    public void SetParent(ConsoleArguments parent)
    {
        if (_parent != null)
            throw new Exception($"{nameof(ConsoleArgument)}.{nameof(_parent)} can only be set once");
        _parent = parent;
    }

    #endregion

    #region Format Help String

    private static int? _maxPrototypeWidth;
    private static int? _maxPropertyWidth;

    public string GetHelpString(bool formatted = false)
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

    public string GetPrototypeFormat() =>
        $"--{Prototype.TrimEnd('=').TrimEnd(':')}";

    public string GetPropertyHelp() =>
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