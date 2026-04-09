# Razor Pages Tailwind Design System Guide

This guide explains the example in simple steps.

You will learn:

- when to use partials
- when to use view components
- how to reuse layout parts like navbar and container
- how to package the design system as a NuGet package
- how to use it in another Razor Pages project

## 1) Big idea

The solution has two parts:

1. **App project** (`src/RazorDemoProject`) - the demo website.
2. **Razor Class Library** (`src/RazorTailwind.DesignSystem`) - the reusable design system.

The app references the class library.

This is important because the class library can later be packed as NuGet and shared in many apps.

## 2) Why partials and view components together?

Use this simple rule:

- **Partial view** = visual component with little or no logic.
- **View component** = component with logic/data before rendering.

### In this example

- `Button`, `Badge`, and `Card` are **partials**.
- `NavigationMenu` is a **view component** (it reads options, checks active page, then renders).

## 3) Important files

### App project

- `src/RazorDemoProject/Program.cs` registers the design system and navigation items.
- `src/RazorDemoProject/Pages/Shared/_Layout.cshtml` uses shared shell pieces.
- `src/RazorDemoProject/Pages/Shared/LayoutParts/_SiteHeader.cshtml` renders the navbar view component.
- `src/RazorDemoProject/Pages/Shared/LayoutParts/_SiteFooter.cshtml` is a reusable footer partial.
- `src/RazorDemoProject/Pages/Index.cshtml` shows component usage.

### Design system library (RCL)

- `Components/ButtonProps.cs`
- `Components/BadgeProps.cs`
- `Components/CardProps.cs`
- `ViewComponents/NavigationMenuViewComponent.cs`
- `TagHelpers/ContainerTagHelper.cs` (`<ds-container>...</ds-container>`)
- `Views/Shared/DesignSystem/_Button.cshtml`
- `Views/Shared/DesignSystem/_Badge.cshtml`
- `Views/Shared/DesignSystem/_Card.cshtml`
- `Styles/design-system.tailwind.css` (Tailwind source)
- `wwwroot/css/razor-tailwind-design-system.css` (compiled css shipped to consumers)

## 4) Small usage examples

### 4.1 Button partial

```cshtml
@{
    var saveButton = new ButtonProps
    {
        Text = "Save",
        Variant = ButtonVariant.Primary,
        Size = ButtonSize.Medium,
    };
}

<partial name="DesignSystem/_Button" model="saveButton" />
```

### 4.2 Badge partial

```cshtml
<partial name="DesignSystem/_Badge"
         model='new BadgeProps { Text = "Active", Tone = BadgeTone.Success }' />
```

### 4.3 Card partial

```cshtml
<partial name="DesignSystem/_Card"
         model='new CardProps
         {
             Eyebrow = "Component",
             Title = "Card",
             Description = "Reusable card with consistent spacing and typography.",
             Meta = "Tone: Brand",
             Tone = CardTone.Brand,
         }' />
```

### 4.4 Container tag helper

```cshtml
<ds-container>
    <h2>Page Title</h2>
    <p>Content with consistent max width and horizontal padding.</p>
</ds-container>
```

### 4.5 Navbar view component

```cshtml
@await Component.InvokeAsync("NavigationMenu")
```

The menu highlights the active item based on current URL.

## 5) Register and configure the design system

In `src/RazorDemoProject/Program.cs`:

```csharp
using RazorTailwind.DesignSystem;

builder.Services.AddRazorTailwindDesignSystem(options =>
{
    options.ProductName = "Razor DS";
    options.NavigationItems =
    [
        new NavigationItem { Label = "Components", Href = "/" },
        new NavigationItem { Label = "Privacy", Href = "/Privacy" },
    ];
});
```

## 6) Include styles from the package

In layout `<head>`:

```cshtml
<link rel="stylesheet" href="~/_content/RazorTailwind.DesignSystem/css/razor-tailwind-design-system.css" />
```

`_content/{PackageId}/...` is the static web asset path for Razor Class Libraries.

## 7) Build Tailwind CSS for the package

Tailwind source lives in the RCL.

Build once:

```bash
npm run tw:build:package
```

Watch mode:

```bash
npm run tw:watch:package
```

## 7.1) Best development loop

Use two terminals from repository root:

Terminal 1 (CSS watch):

```bash
npm run tw:watch:package
```

Terminal 2 (app with hot reload):

```bash
dotnet watch run --project src/RazorDemoProject/RazorDemoProject.csproj
```

This gives you fast feedback while editing both Razor files and design-system styles.

## 8) Package as NuGet

From repository root:

```bash
dotnet pack src/RazorTailwind.DesignSystem/RazorTailwind.DesignSystem.csproj -c Release
```

The `.nupkg` file will be created in:

`src/RazorTailwind.DesignSystem/bin/Release`

## 9) Use this package in another project

### Step A: install package

```bash
dotnet add package RazorTailwind.DesignSystem
```

### Step B: update `_ViewImports.cshtml`

```cshtml
@using RazorTailwind.DesignSystem.Components
@addTagHelper *, RazorTailwind.DesignSystem
```

### Step C: configure `Program.cs`

```csharp
builder.Services.AddRazorTailwindDesignSystem(options =>
{
    options.ProductName = "My Product";
    options.NavigationItems =
    [
        new NavigationItem { Label = "Home", Href = "/" },
        new NavigationItem { Label = "Settings", Href = "/Settings" },
    ];
});
```

### Step D: include css in layout

```cshtml
<link rel="stylesheet" href="~/_content/RazorTailwind.DesignSystem/css/razor-tailwind-design-system.css" />
```

Now you can use the same partials, view component, and styles across projects.

## 10) Suggested folder pattern for real projects

Inside RCL:

- `Components/` - typed component props and enums
- `Views/Shared/DesignSystem/` - partial views
- `ViewComponents/` - smart components
- `TagHelpers/` - reusable layout helpers
- `Styles/` - Tailwind source
- `wwwroot/css/` - compiled CSS shipped to consumers

Inside app:

- `src/RazorDemoProject/Pages/Shared/_Layout.cshtml` - app shell
- `src/RazorDemoProject/Pages/Shared/LayoutParts/` - header/footer partials
- `src/RazorDemoProject/Pages/*.cshtml` - page content using design system components

## 11) Simple decision checklist

When adding a new UI piece, ask:

1. **Only visual?** Use partial.
2. **Needs logic/data?** Use view component.
3. **Wrap generic layout content?** Use tag helper (like `ds-container`).
4. **Will be reused across apps?** Put it in the RCL and ship in NuGet.

---

If you follow this structure, your Razor Pages design system stays clean, reusable, and easy to scale.
