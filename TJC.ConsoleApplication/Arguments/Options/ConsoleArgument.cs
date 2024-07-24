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
                          string? propertyName = null)
        : this(parent, prototype, setOptionValue, () => isRequired, description, propertyName)
    {
    }

    public ConsoleArgument(ConsoleArguments? parent,
                           string prototype,
                           Action<string> setOptionValue,
                           Func<bool?>? getIsRequired = null,
                           string? description = null,
                           string? propertyName = null)
    {
        _parent = parent;
        Prototype = prototype;
        SetOptionValue = setOptionValue;
        Description = description;
        PropertyName = propertyName;
        SetOptionValue += SetOptionValueTriggers;
        _getIsRequired = getIsRequired ?? (() => false);
    }

    #endregion

    #region Properties

    public string Prototype { get; }
    public Action<string> SetOptionValue { get; }
    public string? Description { get; }
    public string? PropertyName { get; }
    public bool? IsRequired => _getIsRequired?.Invoke();
    public bool IsUsed { get; private set; }

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