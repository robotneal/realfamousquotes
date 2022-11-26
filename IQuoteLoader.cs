namespace Quotes;

public interface IQuoteLoader
{
    string Author { get; }
    string GetQuote();
}

