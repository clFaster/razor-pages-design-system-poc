namespace RazorTailwind.DesignSystem;

public sealed class NavigationItem
{
    public required string Label { get; init; }

    public required string Href { get; init; }

    public bool MatchPrefix { get; init; }
}
