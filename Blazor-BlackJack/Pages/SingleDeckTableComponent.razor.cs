using System.Collections.Generic;
using System.Linq;
using BlazorBlackJack.Model;
using Microsoft.AspNetCore.Components;

namespace BlazorBlackJack.Pages
{
    public abstract class SingleDeckTableComponentBase : ComponentBase
    {
        private const int AceHighValue = 11;
        private const int LowAceValue = 1;
        protected const int BlackJack = 21;
        private const int DealerHitLimit = 16;
        private readonly Deck _deck;

        //protected bool IsPlayerStaying;
        protected bool IsHandCompleted
        {
            get
            {
                //Dealer Hole Card Is Showing
                
                return 
                    this.ScoreHand(this.DealerHand) > DealerHitLimit;
            }
        }

        protected bool IsPlayerWinner()
        {
            return

                !this.IsHandBust(this.PlayerHand)
                &&
                (
                    this.IsHandBust(this.DealerHand)
                    &&
                    !this.IsHandBust(this.PlayerHand)
                )
                ||
                (
                    !this.IsHandBust(this.DealerHand)
                    &&
                    this.ScoreHand(this.PlayerHand) > this.ScoreHand(this.DealerHand)
                    &&
                    this.ScoreHand(this.DealerHand) > DealerHitLimit
                );
        }

        protected bool IsPlayerStaying
        {
            get;
            private set;
        }

        protected List<Card> DealerHand
        {
            get;
        }

        protected List<Card> PlayerHand
        {
            get;
        }

        protected SingleDeckTableComponentBase()
        {
            this._deck = Deck.Shuffle(new Deck());
            this.DealerHand = new List<Card>();
            this.PlayerHand = new List<Card>();
            this.DealHand();
        }

        private void DealHand()
        {
            this.ResetTable();
            for (var x = 0; x < 2; x++)
            {
                this.DealCard(this.PlayerHand);
                this.DealCard(this.DealerHand);
            }

        }

        private void ResetTable()
        {
            this.IsPlayerStaying = false;
            this.PlayerHand.Clear();
            this.DealerHand.Clear();
        }

        private void DealCard(ICollection<Card> hand)
        {
            hand.Add(this._deck.First());
            this._deck.Remove(this._deck.First());
        }

        protected void HitPlayerButtonClick()
        {
            this.DealCard(this.PlayerHand);
        }

        protected void StayPlayerButtonClick()
        {
            this.IsPlayerStaying = true;
            this.PlayDealer();
        }

        private void PlayDealer()
        {
            while (this.ScoreHand(this.DealerHand) <= DealerHitLimit)
            {
                this.DealCard(this.DealerHand);
            }
        }

        protected int ScoreHand(List<Card> hand)
        {
            if (!this.IsHandBust(hand))
            {
                return (from Card card in hand
                    select card.Value).Sum(cardValue => cardValue);
            }

            //hand is bust

            //does it contain any Aces
            if (!(from Card card in hand
                where card.Value == AceHighValue
                select card).Any())
            {
                //hand not contains aces return value which will bust on UI
                return (from Card card in hand
                    select card.Value).Sum(cardValue => cardValue);
            }

            //is a bust hand and contains aces so is a soft value return minimum Aces conversion to 1 to not bust
            var nonAceScore =
                (from Card card in hand
                    where card.Value < AceHighValue
                    select card.Value).Sum(cardValue => cardValue);

            var highAces = (from Card card in hand
                where card.Value == AceHighValue
                select card.Value).Sum(cardValue => cardValue);
            var lowAces = 0;
            
            while (nonAceScore + highAces + lowAces > BlackJack && highAces > 0)
            {
                highAces -= AceHighValue;
                lowAces += LowAceValue;
            }

            return nonAceScore + highAces + lowAces;
        }

        protected bool IsHandBust(List<Card> hand)
        {
            return
                (from Card card in hand
                    select card.Value).Sum(cardValue => cardValue) > 21;
        }

        protected void DealNextHandButtonClick()
        {
            this.DealHand();
        }

        protected bool IsPlayerAbleToHit()
        {
            return false;
        }

    }

}