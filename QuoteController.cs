using Microsoft.AspNetCore.Mvc;

namespace Quotes;

[ApiController]
[Route("quotes")]
public class QuoteController : ControllerBase
{
    private readonly QuoteService _quoteService;
    private readonly ImageWriter _imgWriter;
    public QuoteController(
        QuoteService quoteService,
        ImageWriter imageWriter)
    {
        _quoteService = quoteService;
        _imgWriter = imageWriter;
    }

    [HttpGet]
    [Route("{author}")]
    public async Task<IActionResult> Get([FromRoute]Author author)
    {
        if(author.Name == "unknown")
        {
            return NotFound();
        }

        var quote = _quoteService.GetQuote(author);
        var img = await _imgWriter.GenerateImage(author, quote);
        return File(img, "image/png");
    }
}
