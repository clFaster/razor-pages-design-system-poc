namespace RazorTailwind.DesignSystem.Components;

public enum ButtonVariant
{
    Primary,
    Secondary,
    Ghost,
    Danger,
}

public enum ButtonSize
{
    Small,
    Medium,
    Large,
}

public sealed class ButtonProps
{
    public required string Text { get; init; }

    public string? Href { get; init; }

    public string Type { get; init; } = "button";

    public ButtonVariant Variant { get; init; } = ButtonVariant.Primary;

    public ButtonSize Size { get; init; } = ButtonSize.Medium;

    public bool Disabled { get; init; }

    public string AdditionalClasses { get; init; } = string.Empty;

    public string CssClasses => string.Join(
        " ",
        new[]
        {
            "rtds-button",
            VariantClasses(),
            SizeClasses(),
            Disabled ? "is-disabled" : string.Empty,
            AdditionalClasses,
        }.Where(static value => !string.IsNullOrWhiteSpace(value))
    );

    private string VariantClasses() => Variant switch
    {
        ButtonVariant.Primary => "rtds-button--primary",
        ButtonVariant.Secondary => "rtds-button--secondary",
        ButtonVariant.Ghost => "rtds-button--ghost",
        ButtonVariant.Danger => "rtds-button--danger",
        _ => "rtds-button--primary",
    };

    private string SizeClasses() => Size switch
    {
        ButtonSize.Small => "rtds-button--small",
        ButtonSize.Medium => "rtds-button--medium",
        ButtonSize.Large => "rtds-button--large",
        _ => "rtds-button--medium",
    };
}
