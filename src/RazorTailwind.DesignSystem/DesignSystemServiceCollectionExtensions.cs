using Microsoft.Extensions.DependencyInjection;

namespace RazorTailwind.DesignSystem;

public static class DesignSystemServiceCollectionExtensions
{
    public static IServiceCollection AddRazorTailwindDesignSystem(
        this IServiceCollection services,
        Action<DesignSystemOptions>? configure = null
    )
    {
        if (configure is null)
        {
            services.AddOptions<DesignSystemOptions>();
            return services;
        }

        services.Configure(configure);
        return services;
    }
}
