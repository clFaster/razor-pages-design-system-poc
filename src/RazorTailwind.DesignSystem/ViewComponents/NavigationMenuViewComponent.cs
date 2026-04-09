using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace RazorTailwind.DesignSystem.ViewComponents;

public sealed class NavigationMenuViewComponent : ViewComponent
{
    private readonly DesignSystemOptions _options;

    public NavigationMenuViewComponent(IOptions<DesignSystemOptions> options)
    {
        _options = options.Value;
    }

    public IViewComponentResult Invoke()
    {
        var currentPath = HttpContext.Request.Path.Value ?? "/";

        var items = _options.NavigationItems
            .Select(item => new NavigationMenuItemViewModel(item.Label, item.Href, IsActive(item, currentPath)))
            .ToArray();

        var model = new NavigationMenuViewModel(_options.ProductName, items);

        return View(model);
    }

    private static bool IsActive(NavigationItem item, string currentPath)
    {
        if (item.Href.StartsWith("http", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        if (string.Equals(item.Href, "/", StringComparison.OrdinalIgnoreCase))
        {
            return string.Equals(currentPath, "/", StringComparison.OrdinalIgnoreCase);
        }

        return item.MatchPrefix
            ? currentPath.StartsWith(item.Href, StringComparison.OrdinalIgnoreCase)
            : string.Equals(item.Href, currentPath, StringComparison.OrdinalIgnoreCase);
    }
}
