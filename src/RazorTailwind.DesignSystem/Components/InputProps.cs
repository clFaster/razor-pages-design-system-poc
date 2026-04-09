namespace RazorTailwind.DesignSystem.Components;

public sealed class InputProps
{
    public required string Id { get; init; }

    public required string Label { get; init; }

    public string? Name { get; init; }

    public string Type { get; init; } = "text";

    public string Placeholder { get; init; } = string.Empty;

    public string? Value { get; init; }

    public bool Required { get; init; }

    public bool Disabled { get; init; }

    public bool FullWidth { get; init; }

    public string AdditionalWrapperClasses { get; init; } = string.Empty;

    public string AdditionalInputClasses { get; init; } = string.Empty;

    public string WrapperClasses => string.Join(
        " ",
        new[]
        {
            "rtds-form-field",
            FullWidth ? "rtds-form-field--full" : string.Empty,
            AdditionalWrapperClasses,
        }.Where(static value => !string.IsNullOrWhiteSpace(value))
    );

    public string InputClasses => string.Join(
        " ",
        new[]
        {
            "rtds-input",
            Disabled ? "is-disabled" : string.Empty,
            AdditionalInputClasses,
        }.Where(static value => !string.IsNullOrWhiteSpace(value))
    );
}
