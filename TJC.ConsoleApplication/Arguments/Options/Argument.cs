namespace TJC.ConsoleApplication.Arguments.Options;

/// <summary>
/// Argument to be used in <seealso cref="IConsoleArguments"/>.
/// </summary>
public class Argument : Option
{
    #region Fields

    private IConsoleArguments? _parent;
    private readonly Func<bool?> _getIsRequired;

    #endregion

    #region Constructors

    /// <summary>
    /// Constructor for an argument.
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="prototype"></param>
    /// <param name="action"></param>
    /// <param name="isRequired"></param>
    /// <param name="description"></param>
    /// <param name="propertyName"></param>
    /// <param name="exitIfUsed"></param>
    public Argument(IConsoleArguments? parent,
                    string prototype,
                    Action<string> action,
                    bool? isRequired = false,
                    string? description = null,
                    string? propertyName = null,
                    bool exitIfUsed = true)
        : this(parent,
              prototype,
              action,
              () => isRequired,
              description,
              propertyName,
              exitIfUsed)
    {
    }

    /// <summary>
    /// Base constructor an argument.
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="prototype"></param>
    /// <param name="action"></param>
    /// <param name="getIsRequired"></param>
    /// <param name="description"></param>
    /// <param name="propertyName"></param>
    /// <param name="exitIfUsed"></param>
    public Argument(IConsoleArguments? parent,
                    string prototype,
                    Action<string> action,
                    Func<bool?>? getIsRequired = null,
                    string? description = null,
                    string? propertyName = null,
                    bool exitIfUsed = true)
        : base(prototype, description)
    {
        _parent = parent;
        Action = action;
        PropertyName = propertyName;
        Action += OnActionTriggered;
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


    internal readonly Action<string> Action;

    internal bool HasParent =>
        _parent != null;

    #endregion

    #region Methods

    internal void SetParent(ConsoleArguments parent)
    {
        if (_parent != null)
            throw new Exception($"{nameof(Argument)}.{nameof(_parent)} can only be set once.");
        _parent = parent;
    }

    #endregion

    #region Events

    private void OnActionTriggered(string value)
    {
        IsUsed = !string.IsNullOrEmpty(value);
        if (_parent?.LogParsedOptions ?? false)
            ConsoleOutputHandler.WriteLine($"{this.GetPrototypeHelpString()}: {value}");
    }

    /// <summary>
    /// Event on parse complete.
    /// </summary>
    /// <param name="c"></param>
    protected override void OnParseComplete(OptionContext c)
    {
    }

    #endregion
}