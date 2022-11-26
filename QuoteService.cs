namespace Quotes;

public class QuoteService
{
    private readonly IEnumerable<IQuoteLoader> _quoteLoaders;
    private readonly Random _rnd;
    public QuoteService(
        IEnumerable<IQuoteLoader> quoteLoaders,
        Random rnd)
    {
        _quoteLoaders = quoteLoaders;
        _rnd = rnd;
    }

    public string GetQuote(Author author)
    {
        var applicableQuotes = _quoteLoaders.Where(x => x.Author == author.Name).ToList();
        var quoteLoader = applicableQuotes[_rnd.Next(0, applicableQuotes.Count)];

        try
        {
            return quoteLoader.GetQuote();
        }
        catch(Exception ex)
        {
            return ex.Message;
        }
    }
}
