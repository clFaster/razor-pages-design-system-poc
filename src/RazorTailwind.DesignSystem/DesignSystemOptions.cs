namespace RazorTailwind.DesignSystem;

public sealed class DesignSystemOptions
{
    public string ProductName { get; set; } = "Razor DS";

    public IReadOnlyList<NavigationItem> NavigationItems { get; set; } =
    [
        new NavigationItem { Label = "Home", Href = "/" },
    ];
}
