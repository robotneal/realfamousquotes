namespace Quotes;

public class BenthamA : IQuoteLoader
{
    public string Author => "jeremybentham";

    public string GetQuote()
    {
        return "Food please";
    }
}

public class BenthamB : IQuoteLoader
{
    public string Author => "jeremybentham";

    public string GetQuote()
    {
        return "Oooowwooooooouuugghh. Want to go outside";
    }
}

public class BenthamC : IQuoteLoader
{
    public string Author => "jeremybentham";

    public string GetQuote()
    {
        return "Give treats. Want treats.";
    }
}

public class BenthamD : IQuoteLoader
{
    public string Author => "jeremybentham";

    public string GetQuote()
    {
        return "Wubble my tummy";
    }
}

public class BenthamE : IQuoteLoader
{
    public string Author => "jeremybentham";

    public string GetQuote()
    {
        return "Stick. Throw stick. I hunt stick.";
    }
}