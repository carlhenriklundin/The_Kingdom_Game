using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_Game
{
    public enum Landscape {Water, Fields, Forest, Mine, Sand };
    public class PlayingCard
    {
        public int cardNumber { get;}

        public Landscape? rightSideLandscape { get; } = null;
        public int rightSideNumberOfCrown {get;}

        public Landscape? leftSideLandscape { get; } = null;
        public int leftSideNumberOfCrown {get;}

        public PlayingCard(int cardNumber)
        {
            Random random = new Random();
            this.cardNumber = cardNumber;
            rightSideLandscape = (Landscape)random.Next(0, 5);
            leftSideLandscape = (Landscape)random.Next(0, 5);

            if (cardNumber > 17)
            {
                rightSideNumberOfCrown = random.Next(0, 4);
                leftSideNumberOfCrown = random.Next(0, 4);
            }
        }
        public override string ToString() => $"{rightSideLandscape}({rightSideNumberOfCrown}){leftSideLandscape,20}({leftSideNumberOfCrown})";
       

    }
}
