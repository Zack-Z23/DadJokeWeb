using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

public class IndexModel : PageModel
{
    private readonly DadJokeService _jokeService;

    public string Joke { get; private set; }

    public IndexModel(DadJokeService jokeService)
    {
        _jokeService = jokeService;
    }

    public async Task OnGetAsync()
    {
        Joke = await _jokeService.GetRandomJokeAsync();
    }
}
