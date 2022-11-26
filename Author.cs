using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Reflection;

namespace Quotes;

public record Author(string Name, int YearFrom, int YearTo, string DisplayName);

public class AuthorService
{
    public async Task<Author> GetAuthor(string name)
    {
        return name.ToLower() switch
        {
            "shakespeare" => new("shakespeare", 1580, 1610, "William Shakespeare"),
            "jeremybentham" => new("jeremybentham", 1770, 1842, "Jeremy Bentham"),
            _ => new("unknown", 0, DateTime.Now.Year, "Unknown")
        };
    }
}

public class AuthorModelBinder : IModelBinder
{
    private readonly AuthorService _authorService;
    public AuthorModelBinder(AuthorService authorService)
    {
        _authorService = authorService;
    }

    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).FirstValue;

        var author = await _authorService.GetAuthor(value ?? "");

        bindingContext.Result = ModelBindingResult.Success(author);
    }
}

public class AuthorModelBinderProvider : IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (context.Metadata.ModelType == typeof(Author))
        {
            return new BinderTypeModelBinder(typeof(AuthorModelBinder));
        }

        return null;
    }
}