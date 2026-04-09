namespace RazorTailwind.DesignSystem.Components;

public enum BadgeTone
{
    Neutral,
    Brand,
    Success,
    Warning,
}

public sealed class BadgeProps
{
    public required string Text { get; init; }

    public BadgeTone Tone { get; init; } = BadgeTone.Neutral;

    public string AdditionalClasses { get; init; } = string.Empty;

    public string CssClasses => string.Join(
        " ",
        new[]
        {
            "rtds-badge",
            ToneClasses(),
            AdditionalClasses,
        }.Where(static value => !string.IsNullOrWhiteSpace(value))
    );

    private string ToneClasses() => Tone switch
    {
        BadgeTone.Neutral => "rtds-badge--neutral",
        BadgeTone.Brand => "rtds-badge--brand",
        BadgeTone.Success => "rtds-badge--success",
        BadgeTone.Warning => "rtds-badge--warning",
        _ => "rtds-badge--neutral",
    };
}
