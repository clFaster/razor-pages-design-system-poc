# Razor Pages + Tailwind Design System (RCL + NuGet Ready)

This repository is a working example of a reusable design system for Razor Pages.

It demonstrates a practical architecture:

- **Razor Class Library** for shared components and styles
- **Partials** for visual components
- **View component** for logic-aware navbar
- **Tag helper** for page container layout
- **NuGet packaging** support for sharing across projects

## Projects

- `src/RazorDemoProject` - demo web app
- `src/RazorTailwind.DesignSystem` - reusable design system package

## Quick start

1. Install npm dependencies:

```bash
npm install
```

2. Build package CSS from Tailwind source:

```bash
npm run tw:build:package
```

3. Run the demo app:

```bash
dotnet run --project src/RazorDemoProject/RazorDemoProject.csproj
```

## Useful commands

Run full development workflow (recommended):

Terminal 1:

```bash
npm run tw:watch:package
```

Terminal 2:

```bash
dotnet watch run --project src/RazorDemoProject/RazorDemoProject.csproj
```

Watch CSS while editing design-system styles:

```bash
npm run tw:watch:package
```

Run app without hot reload:

```bash
dotnet run --project src/RazorDemoProject/RazorDemoProject.csproj
```

Create NuGet package:

```bash
dotnet pack src/RazorTailwind.DesignSystem/RazorTailwind.DesignSystem.csproj -c Release
```

## Full documentation

See `docs/design-system-guide.md` for full guidance with simple examples.
