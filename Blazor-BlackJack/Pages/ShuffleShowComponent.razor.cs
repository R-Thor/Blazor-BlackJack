using BlazorBlackJack.Model;
using Microsoft.AspNetCore.Components;

namespace BlazorBlackJack.Pages
{
    public abstract class ShuffleShowComponentBase : ComponentBase
    {
        protected Deck Deck;
        
        protected ShuffleShowComponentBase()
        {
            this.Deck = Deck.Shuffle(new Deck());
        }

    }
}
