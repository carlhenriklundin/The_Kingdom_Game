using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Kingdom_Game
{
    class Player
    {
        public (Landscape landscape, int numberOfCrown)[,] Board = new (Landscape, int)[9, 9];
        
        
        public Player()
        {
            Board[4, 4] = (Landscape.Water, 0);
        }

        public void InsertPlayingCard(PlayingCard card)
        {
            GetPosition(card, out (int row, int column) right, out (int row, int column) left);
           
            (Board[right.row, right.column], Board[left.row, left.column]) = (card.rightSide, card.leftSide);
        }

        public void GetPosition(PlayingCard card, out (int, int) rightPosition, out (int, int) leftPosition) 
        {
            bool legal = false;

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

        public bool CheckIfPositionIsLegal((int row, int column) right, (int row, int column) left, Landscape landscape)
        {
            Landscape king = Landscape.King;
            bool isRightPositionEmpty = Board[right.row, right.column].landscape == Landscape.Empty;
            bool isLeftPositionEmpty = Board[left.row, left.column].landscape == Landscape.Empty;
            bool isRightLandscapeConnected = Board[right.row - 1, right.column].landscape == landscape || Board[right.row, right.column + 1].landscape == landscape || Board[right.row + 1, right.column].landscape == landscape || Board[right.row, right.column - 1].landscape == landscape;
            bool isRightCardConnectedWithKing = Board[right.row - 1, right.column].landscape == king || Board[right.row, right.column + 1].landscape == king || Board[right.row + 1, right.column].landscape == king || Board[right.row, right.column - 1].landscape == king;

            if (isRightPositionEmpty && isLeftPositionEmpty && (isRightLandscapeConnected || isRightCardConnectedWithKing)) return true;
            else return false;
        }

        

        public void PrintPLayingBoard()
        {
            for (int rad = 0; rad < Board.GetLength(0); rad++)
            {
                for (int column = 0; column < Board.GetLength(1); column++)
                {
                    Console.Write($"{Board[rad, column],-12}");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            }
        }
    }
}

/*
           if (Board[position.row - 1, position.column] != null || Board[position.row, position.column + 1] != null || Board[position.row + 1, position.column] != null || Board[position.row, position.column - 1] != null)
               {
               int row, int column) position = AskingForPosition(false);

               Board[RightRad, RIghtColumn] = new(playingCard.rightSideLandscape, playingCard.rightSideNumberOfCrown);
               Board[LeftRad, LeftColumn] = new(playingCard.rightSideLandscape, playingCard.leftSideNumberOfCrown);
           }
           else Console.WriteLine("Kortet du lägger måste ha kontakt med ett annat kort!");
           */