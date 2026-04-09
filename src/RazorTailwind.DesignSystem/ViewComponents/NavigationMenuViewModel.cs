namespace RazorTailwind.DesignSystem.ViewComponents;

public sealed record NavigationMenuItemViewModel(string Label, string Href, bool IsActive);

public sealed record NavigationMenuViewModel(
    string ProductName,
    IReadOnlyList<NavigationMenuItemViewModel> Items
);
