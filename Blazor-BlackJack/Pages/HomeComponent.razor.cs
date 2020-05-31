using BlazorBlackJack.Model;
using Microsoft.AspNetCore.Components;

namespace BlazorBlackJack.Pages
{
    public abstract class HomeComponentBase : ComponentBase
    {
        protected Deck Deck;
        protected HomeComponentBase()
        {
            this.Deck = new Deck();
        }

    }
}
