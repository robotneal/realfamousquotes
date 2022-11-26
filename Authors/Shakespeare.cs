namespace Quotes;

public class ShakespeareA : IQuoteLoader
{
    public string Author => "shakespeare";

    public string GetQuote()
    {
        throw new NotImplementedException();
    }
}

public class ShakespeareB : IQuoteLoader
{
    public string Author => "shakespeare";

    public string GetQuote()
    {
        throw new ArgumentOutOfRangeException();
    }
}

public class ShakespeareC : IQuoteLoader
{
    public string Author => "shakespeare";

    public string GetQuote()
    {
        throw new NullReferenceException();
    }
}

public class ShakespeareD : IQuoteLoader
{
    public string Author => "shakespeare";

    public string GetQuote()
    {
        throw new DivideByZeroException();
    }
}

public class ShakespeareE : IQuoteLoader
{
    public string Author => "shakespeare";

    public string GetQuote()
    {
        throw new EndOfStreamException();
    }
}

public class ShakespeareF : IQuoteLoader
{
    public string Author => "shakespeare";

    public string GetQuote()
    {
        throw new OutOfMemoryException();
    }
}

public class ShakespeareG : IQuoteLoader
{
    public string Author => "shakespeare";

    public string GetQuote()
    {
        throw new InvalidOperationException();
    }
}

public class ShakespeareH : IQuoteLoader
{
    public string Author => "shakespeare";

    public string GetQuote()
    {
        throw new TimeoutException();
    }
}
