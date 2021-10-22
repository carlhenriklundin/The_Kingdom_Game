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

        public (Landscape landscape, int numberOfCrown) rightSide { get;}
        public (Landscape landscape, int numberOfCrown) leftSide { get;}


        public PlayingCard(int cardNumber)
        {
            Random random = new Random();
            this.cardNumber = cardNumber;
            rightSide = ((Landscape)random.Next(0, 5), 0);
            leftSide = ((Landscape)random.Next(0, 5), 0);

            if (cardNumber > 17)
            {
            rightSide = ((Landscape)random.Next(0, 5), random.Next(0, 4));
            leftSide = ((Landscape)random.Next(0, 5), random.Next(0, 4));
            }
        }
        public override string ToString() => $"{rightSide,-20}{leftSide}";
      
    }
}
