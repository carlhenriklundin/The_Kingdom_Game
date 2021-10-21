using System;

namespace The_Kingdom_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            DeckOfPlayingCard myDeck = new DeckOfPlayingCard();
            myDeck.NewDeck();
            myDeck.Suffle();
            myDeck.PrintDeck();
        }
    }
}
