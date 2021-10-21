using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_Game
{
    class Player
    {
        (Landscape?, int)[,] PlayerBoard = new (Landscape?, int)[9, 9];


        public void InsertPlayingCard(PlayingCard playingCard)
        {
            Console.Write("Vilken rad ska högra spelkortet hamna i?");
            int RightRad = Convert.ToInt32(Console.ReadLine());
            Console.Write("Vilken column ska högra spelkortet hamna i?");
            int RIghtColumn = Convert.ToInt32(Console.ReadLine());
            Console.Write("Vilken rad ska vänstra spelkortet hamna i?");
            int LeftRad = Convert.ToInt32(Console.ReadLine());
            Console.Write("Vilken column ska vänstra spelkortet hamna i?");
            int LeftColumn = Convert.ToInt32(Console.ReadLine());

            PlayerBoard[RightRad, RIghtColumn] = new (playingCard.rightSideLandscape, playingCard.rightSideNumberOfCrown);
            PlayerBoard[LeftRad, LeftColumn] = new (playingCard.rightSideLandscape, playingCard.leftSideNumberOfCrown);
        }

        public void PrintPLayingBoard()
        {
            for (int rad = 0; rad < PlayerBoard.GetLength(0); rad++)
            {
                for (int column = 0; column < PlayerBoard.GetLength(1); column++)
                {
                    if (PlayerBoard[rad, column].Item1 != null) Console.Write($"{PlayerBoard[rad, column],-12}");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            }
        }
    }
}
