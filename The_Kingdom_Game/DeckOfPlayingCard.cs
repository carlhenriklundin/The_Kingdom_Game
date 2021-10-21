using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_Game
{

    class DeckOfPlayingCard
    {
        PlayingCard[] theDeckofPlayingCard = new PlayingCard[28];


        public void NewDeck()
        {
            for (int i = 0; i < theDeckofPlayingCard.Length; i++)
            {
                theDeckofPlayingCard[i] = new PlayingCard(i+1);
            }
        }

        public void PrintDeck()
        {
            foreach (var item in theDeckofPlayingCard)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void Suffle()
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int card1 = random.Next(0, 28);
                int card2 = random.Next(0, 28);
                (theDeckofPlayingCard[card1], theDeckofPlayingCard[card2]) = (theDeckofPlayingCard[card2], theDeckofPlayingCard[card1]); ;
            }
        }        
        


    }
}
