using Frank.CrossPlatformWindow.Internals;
using Microsoft.Extensions.DependencyInjection;

namespace Frank.CrossPlatformWindow;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFrameRendering(this IServiceCollection services, string title, int width = 800, int height = 600)
    {
        InternalAddFrameRendering(services, title, width, height);
        return services;
    }
    
    public static IServiceCollection AddFrameRendering<T>(this IServiceCollection services, string title, int width = 800, int height = 600) where T : class, IFrameUpdateAction
    {
        InternalAddFrameRendering(services, title, width, height);
        services.AddSingleton<IFrameUpdateAction, T>();
        return services;
    }
    
    public static IServiceCollection AddFrameRendering<T1, T2>(this IServiceCollection services, string title, int width = 800, int height = 600) where T1 : class, IFrameUpdateAction where T2 : class, IFrameUpdateAction
    {
        InternalAddFrameRendering(services, title, width, height);
        services.AddSingleton<IFrameUpdateAction, T1>();
        services.AddSingleton<IFrameUpdateAction, T2>();
        return services;
    }
    
    public static IServiceCollection AddFrameRendering<T1, T2, T3>(this IServiceCollection services, string title, int width = 800, int height = 600) where T1 : class, IFrameUpdateAction where T2 : class, IFrameUpdateAction where T3 : class, IFrameUpdateAction
    {
        InternalAddFrameRendering(services, title, width, height);
        services.AddSingleton<IFrameUpdateAction, T1>();
        services.AddSingleton<IFrameUpdateAction, T2>();
        services.AddSingleton<IFrameUpdateAction, T3>();
        return services;
    }
    
    public static IServiceCollection AddFrameRendering<T1, T2, T3, T4>(this IServiceCollection services, string title, int width = 800, int height = 600) where T1 : class, IFrameUpdateAction where T2 : class, IFrameUpdateAction where T3 : class, IFrameUpdateAction where T4 : class, IFrameUpdateAction
    {
        InternalAddFrameRendering(services, title, width, height);
        services.AddSingleton<IFrameUpdateAction, T1>();
        services.AddSingleton<IFrameUpdateAction, T2>();
        services.AddSingleton<IFrameUpdateAction, T3>();
        services.AddSingleton<IFrameUpdateAction, T4>();
        return services;
    }
    
    public static IServiceCollection AddFrameRendering<T1, T2, T3, T4, T5>(this IServiceCollection services, string title, int width = 800, int height = 600) where T1 : class, IFrameUpdateAction where T2 : class, IFrameUpdateAction where T3 : class, IFrameUpdateAction where T4 : class, IFrameUpdateAction where T5 : class, IFrameUpdateAction
    {
        InternalAddFrameRendering(services, title, width, height);
        services.AddSingleton<IFrameUpdateAction, T1>();
        services.AddSingleton<IFrameUpdateAction, T2>();
        services.AddSingleton<IFrameUpdateAction, T3>();
        services.AddSingleton<IFrameUpdateAction, T4>();
        services.AddSingleton<IFrameUpdateAction, T5>();
        return services;
    }
    
    public static IServiceCollection AddFrameRendering<T1, T2, T3, T4, T5, T6>(this IServiceCollection services, string title, int width = 800, int height = 600) where T1 : class, IFrameUpdateAction where T2 : class, IFrameUpdateAction where T3 : class, IFrameUpdateAction where T4 : class, IFrameUpdateAction where T5 : class, IFrameUpdateAction where T6 : class, IFrameUpdateAction
    {
        InternalAddFrameRendering(services, title, width, height);
        services.AddSingleton<IFrameUpdateAction, T1>();
        services.AddSingleton<IFrameUpdateAction, T2>();
        services.AddSingleton<IFrameUpdateAction, T3>();
        services.AddSingleton<IFrameUpdateAction, T4>();
        services.AddSingleton<IFrameUpdateAction, T5>();
        services.AddSingleton<IFrameUpdateAction, T6>();
        return services;
    }
    
    public static IServiceCollection AddFrameRendering<T1, T2, T3, T4, T5, T6, T7>(this IServiceCollection services, string title, int width = 800, int height = 600) where T1 : class, IFrameUpdateAction where T2 : class, IFrameUpdateAction where T3 : class, IFrameUpdateAction where T4 : class, IFrameUpdateAction where T5 : class, IFrameUpdateAction where T6 : class, IFrameUpdateAction where T7 : class, IFrameUpdateAction
    {
        InternalAddFrameRendering(services, title, width, height);
        services.AddSingleton<IFrameUpdateAction, T1>();
        services.AddSingleton<IFrameUpdateAction, T2>();
        services.AddSingleton<IFrameUpdateAction, T3>();
        services.AddSingleton<IFrameUpdateAction, T4>();
        services.AddSingleton<IFrameUpdateAction, T5>();
        services.AddSingleton<IFrameUpdateAction, T6>();
        services.AddSingleton<IFrameUpdateAction, T7>();
        return services;
    }
    
    public static IServiceCollection AddFrameRendering<T1, T2, T3, T4, T5, T6, T7, T8>(this IServiceCollection services, string title, int width = 800, int height = 600) where T1 : class, IFrameUpdateAction where T2 : class, IFrameUpdateAction where T3 : class, IFrameUpdateAction where T4 : class, IFrameUpdateAction where T5 : class, IFrameUpdateAction where T6 : class, IFrameUpdateAction where T7 : class, IFrameUpdateAction where T8 : class, IFrameUpdateAction
    {
        InternalAddFrameRendering(services, title, width, height);
        services.AddSingleton<IFrameUpdateAction, T1>();
        services.AddSingleton<IFrameUpdateAction, T2>();
        services.AddSingleton<IFrameUpdateAction, T3>();
        services.AddSingleton<IFrameUpdateAction, T4>();
        services.AddSingleton<IFrameUpdateAction, T5>();
        services.AddSingleton<IFrameUpdateAction, T6>();
        services.AddSingleton<IFrameUpdateAction, T7>();
        services.AddSingleton<IFrameUpdateAction, T8>();
        return services;
    }
    
    public static IServiceCollection AddFrameRendering<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IServiceCollection services, string title, int width = 800, int height = 600) where T1 : class, IFrameUpdateAction where T2 : class, IFrameUpdateAction where T3 : class, IFrameUpdateAction where T4 : class, IFrameUpdateAction where T5 : class, IFrameUpdateAction where T6 : class, IFrameUpdateAction where T7 : class, IFrameUpdateAction where T8 : class, IFrameUpdateAction where T9 : class, IFrameUpdateAction
    {
        InternalAddFrameRendering(services, title, width, height);
        services.AddSingleton<IFrameUpdateAction, T1>();
        services.AddSingleton<IFrameUpdateAction, T2>();
        services.AddSingleton<IFrameUpdateAction, T3>();
        services.AddSingleton<IFrameUpdateAction, T4>();
        services.AddSingleton<IFrameUpdateAction, T5>();
        services.AddSingleton<IFrameUpdateAction, T6>();
        services.AddSingleton<IFrameUpdateAction, T7>();
        services.AddSingleton<IFrameUpdateAction, T8>();
        services.AddSingleton<IFrameUpdateAction, T9>();
        return services;
    }
    
    public static IServiceCollection AddFrameRendering<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IServiceCollection services, string title, int width = 800, int height = 600) where T1 : class, IFrameUpdateAction where T2 : class, IFrameUpdateAction where T3 : class, IFrameUpdateAction where T4 : class, IFrameUpdateAction where T5 : class, IFrameUpdateAction where T6 : class, IFrameUpdateAction where T7 : class, IFrameUpdateAction where T8 : class, IFrameUpdateAction where T9 : class, IFrameUpdateAction where T10 : class, IFrameUpdateAction
    {
        InternalAddFrameRendering(services, title, width, height);
        services.AddSingleton<IFrameUpdateAction, T1>();
        services.AddSingleton<IFrameUpdateAction, T2>();
        services.AddSingleton<IFrameUpdateAction, T3>();
        services.AddSingleton<IFrameUpdateAction, T4>();
        services.AddSingleton<IFrameUpdateAction, T5>();
        services.AddSingleton<IFrameUpdateAction, T6>();
        services.AddSingleton<IFrameUpdateAction, T7>();
        services.AddSingleton<IFrameUpdateAction, T8>();
        services.AddSingleton<IFrameUpdateAction, T9>();
        services.AddSingleton<IFrameUpdateAction, T10>();
        return services;
    }
    
    private static void InternalAddFrameRendering(IServiceCollection services, string title, int width, int height)
    {
        services.AddSingleton<Renderer>();
        services.AddSingleton<FrameWriter>();
        services.AddSingleton<IWindow>(sp => sp.GetRequiredService<FrameWriter>());
        services.Configure<WindowOptions>(options =>
        {
            options.Title = title;
            options.Width = width;
            options.Height = height;
        });
        services.AddHostedService<RendererBackgroundService>();
    }
}