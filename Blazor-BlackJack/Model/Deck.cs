using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BlazorBlackJack.Model
{
    public class Deck : List<Card>
    {
        public Deck()
        {
            //for(int x = 0; x < 52; x++)
            //{
            //    this.Add(new Card("Assets/Images/Card/AS.png", 11));
            //}
            this.Add(new Card("Assets/Images/Card/AS.png", 11));
            this.Add(new Card("Assets/Images/Card/2S.png", 2));
            this.Add(new Card("Assets/Images/Card/3S.png", 3));
            this.Add(new Card("Assets/Images/Card/4S.png", 4));
            this.Add(new Card("Assets/Images/Card/5S.png", 5));
            this.Add(new Card("Assets/Images/Card/6S.png", 6));
            this.Add(new Card("Assets/Images/Card/7S.png", 7));
            this.Add(new Card("Assets/Images/Card/8S.png", 8));
            this.Add(new Card("Assets/Images/Card/9S.png", 9));
            this.Add(new Card("Assets/Images/Card/10S.png", 10));
            this.Add(new Card("Assets/Images/Card/JS.png", 10));
            this.Add(new Card("Assets/Images/Card/QS.png", 10));
            this.Add(new Card("Assets/Images/Card/KS.png", 10));
            this.Add(new Card("Assets/Images/Card/AD.png", 11));
            this.Add(new Card("Assets/Images/Card/2D.png", 2));
            this.Add(new Card("Assets/Images/Card/3D.png", 3));
            this.Add(new Card("Assets/Images/Card/4D.png", 4));
            this.Add(new Card("Assets/Images/Card/5D.png", 5));
            this.Add(new Card("Assets/Images/Card/6D.png", 6));
            this.Add(new Card("Assets/Images/Card/7D.png", 7));
            this.Add(new Card("Assets/Images/Card/8D.png", 8));
            this.Add(new Card("Assets/Images/Card/9D.png", 9));
            this.Add(new Card("Assets/Images/Card/10D.png", 10));
            this.Add(new Card("Assets/Images/Card/JD.png", 10));
            this.Add(new Card("Assets/Images/Card/QD.png", 10));
            this.Add(new Card("Assets/Images/Card/KD.png", 10));
            this.Add(new Card("Assets/Images/Card/AC.png", 11));
            this.Add(new Card("Assets/Images/Card/2C.png", 2));
            this.Add(new Card("Assets/Images/Card/3C.png", 3));
            this.Add(new Card("Assets/Images/Card/4C.png", 4));
            this.Add(new Card("Assets/Images/Card/5C.png", 5));
            this.Add(new Card("Assets/Images/Card/6C.png", 6));
            this.Add(new Card("Assets/Images/Card/7C.png", 7));
            this.Add(new Card("Assets/Images/Card/8C.png", 8));
            this.Add(new Card("Assets/Images/Card/9C.png", 9));
            this.Add(new Card("Assets/Images/Card/10C.png", 10));
            this.Add(new Card("Assets/Images/Card/JC.png", 10));
            this.Add(new Card("Assets/Images/Card/QC.png", 10));
            this.Add(new Card("Assets/Images/Card/KC.png", 10));
            this.Add(new Card("Assets/Images/Card/AH.png", 11));
            this.Add(new Card("Assets/Images/Card/2H.png", 2));
            this.Add(new Card("Assets/Images/Card/3H.png", 3));
            this.Add(new Card("Assets/Images/Card/4H.png", 4));
            this.Add(new Card("Assets/Images/Card/5H.png", 5));
            this.Add(new Card("Assets/Images/Card/6H.png", 6));
            this.Add(new Card("Assets/Images/Card/7H.png", 7));
            this.Add(new Card("Assets/Images/Card/8H.png", 8));
            this.Add(new Card("Assets/Images/Card/9H.png", 9));
            this.Add(new Card("Assets/Images/Card/10H.png", 10));
            this.Add(new Card("Assets/Images/Card/JH.png", 10));
            this.Add(new Card("Assets/Images/Card/QH.png", 10));
            this.Add(new Card("Assets/Images/Card/KH.png", 10));
        }

        public static Deck Shuffle(Deck deck)
        {
            var returnDeck = new Deck();
            returnDeck.Clear();
            var random = new Random();
            Debug.WriteLine(deck.Count);
            while (deck.Count > 0)
            {

                var shuffleSelect = random.Next() % deck.Count;
                Console.WriteLine("shuffleSelect:" + shuffleSelect);
                Console.WriteLine(deck[shuffleSelect].ImagePath);

                //Console.WriteLine(shuffleSelect);
                //Console.WriteLine(deck[shuffleSelect].ImagePath);
                returnDeck.Add(deck[shuffleSelect]);

                deck.Remove(deck[shuffleSelect]);

                //Console.WriteLine(deck[returnDeck.Count - 1].ImagePath);
            }

            return returnDeck;
        }
    }
}
