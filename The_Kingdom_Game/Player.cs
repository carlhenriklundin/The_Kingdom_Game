using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_Game
{
    class Player
    {
        string name;
        int point;
        public (Landscape landscape, int numberOfCrown)[,] Board = new (Landscape, int)[9, 9];
        static int numberOfPlayer;
        
        public Player()
        {
            Board[4, 4] = (Landscape.King, 0);
        }

        #region Insert Card in Players Board

        
        public void InsertPlayingCard(PlayingCard card)
        {
            GetPosition(card, out (int row, int column) right, out (int row, int column) left);
           
            (Board[right.row, right.column], Board[left.row, left.column]) = (card.rightSide, card.leftSide);
        }

        public void GetPosition(PlayingCard card, out (int, int) rightPosition, out (int, int) leftPosition) 
        {
            bool legal = false;
            Console.WriteLine(card.ToString());
            do
            {
                rightPosition = AskForPosition();
                leftPosition = AskForPosition();
                legal = CheckIfPositionIsLegal(rightPosition, leftPosition, card.rightSide.landscape);
            } while (!legal);
         
        }
        
        public (int, int) AskForPosition()
        { 
           
            Console.Write($"I vilken rad ska första spelkortet läggas in i?");
            int rad = Convert.ToInt32(Console.ReadLine());
            Console.Write($"I vilken column ska spelkortet läggas in i?");
            int column = Convert.ToInt32(Console.ReadLine());
            return (rad, column);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param right position="right"></param>
        /// <param left position="left"></param>
        /// <param right landscape="landscape"></param>
        /// <returns></returns>
        public bool CheckIfPositionIsLegal((int row, int column) right, (int row, int column) left, Landscape landscape)
        {
            Landscape king = Landscape.King;
            bool isRightPositionEmpty = Board[right.row, right.column].landscape == Landscape.Empty;
            bool isLeftPositionEmpty = Board[left.row, left.column].landscape == Landscape.Empty;
            bool isRightConnectedWithLandscape = Board[right.row - 1, right.column].landscape == landscape || Board[right.row, right.column + 1].landscape == landscape || Board[right.row + 1, right.column].landscape == landscape || Board[right.row, right.column - 1].landscape == landscape;
            bool isRightConnectedWithKing = Board[right.row - 1, right.column].landscape == king || Board[right.row, right.column + 1].landscape == king || Board[right.row + 1, right.column].landscape == king || Board[right.row, right.column - 1].landscape == king;
            // bool isRightConnectedWithLeft

            if (isRightPositionEmpty && isLeftPositionEmpty && (isRightConnectedWithLandscape || isRightConnectedWithKing)) return true;
            else return false;
        }

        #endregion

        public void PrintPLayingBoard()
        {
            for (int rad = 0; rad < Board.GetLength(0); rad++)
            {
                for (int column = 0; column < Board.GetLength(1); column++)
                {
                    Console.Write($"{Board[rad, column].landscape,-12}");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            }
        }
    }
}