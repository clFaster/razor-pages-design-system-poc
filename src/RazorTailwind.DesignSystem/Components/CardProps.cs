namespace RazorTailwind.DesignSystem.Components;

public enum CardTone
{
    Neutral,
    Brand,
}

public sealed class CardProps
{
    public required string Title { get; init; }

    public string? Eyebrow { get; init; }

    public string? Description { get; init; }

    public string? Meta { get; init; }

    public CardTone Tone { get; init; } = CardTone.Neutral;

    public string AdditionalClasses { get; init; } = string.Empty;

    public string CssClasses => string.Join(
        " ",
        new[]
        {
            "rtds-card",
            ToneClasses(),
            AdditionalClasses,
        }.Where(static value => !string.IsNullOrWhiteSpace(value))
    );

    private string ToneClasses() => Tone switch
    {
        CardTone.Neutral => "rtds-card--neutral",
        CardTone.Brand => "rtds-card--brand",
        _ => "rtds-card--neutral",
    };
}
