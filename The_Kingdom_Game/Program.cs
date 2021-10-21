using System;

namespace The_Kingdom_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            DeckOfPlayingCard myDeck = new DeckOfPlayingCard();
            Player player1 = new Player();
            PlayingCard card1 = new PlayingCard(1);
            myDeck.NewDeck();
            myDeck.Suffle();
            myDeck.PrintDeck();
            player1.PrintPLayingBoard();
            player1.InsertPlayingCard(card1);
            player1.PrintPLayingBoard();
        }
    }
}
