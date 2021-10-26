using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_Game
{
    public enum Landscape {Empty, Null, Water, Fields, Forest, Mine, Sand, King };
    public class PlayingCard
    {
        public int cardNumber { get;}
        public (Landscape landscape, int numberOfCrown) rightSideContent { get;}
        public (Landscape landscape, int numberOfCrown) leftSideContent { get;}


        public PlayingCard(int cardNumber)
        {
            Random random = new Random();
            this.cardNumber = cardNumber;
            rightSideContent = ((Landscape)random.Next(2, 8), 0);
            leftSideContent = ((Landscape)random.Next(2, 8), 0);

            if (cardNumber > 17)
            {
            rightSideContent = ((Landscape)random.Next(0, 5), random.Next(0, 4));
            leftSideContent = ((Landscape)random.Next(0, 5), random.Next(0, 4));
            }
        }
        public override string ToString() => $"{rightSideContent,-20}{leftSideContent}";
      
    }
}