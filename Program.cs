using Quotes;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new AuthorModelBinderProvider());
});

builder.Services.AddSingleton<Random>();
builder.Services.AddScoped<AuthorService>();
builder.Services.AddScoped<QuoteService>();
builder.Services.RegisterAllTypes<IQuoteLoader>(new[] { typeof(IQuoteLoader).Assembly });
builder.Services.AddScoped<ImageWriter>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


public static class ServiceCollectionExtensions
{
    public static void RegisterAllTypes<T>(this IServiceCollection services, Assembly[] assemblies,
        ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T))));
        foreach (var type in typesFromAssemblies)
            services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
    }
}