using Microsoft.VisualBasic.FileIO;

namespace Quotes;

public interface IQuoteLoader
{
    string Author { get; }
    string GetQuote();
}

