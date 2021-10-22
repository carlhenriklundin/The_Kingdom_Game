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
            Console.Write($"Vilken sida av kortet {card.ToString()} vill du börja med att lägga ut (höger eller vänster?");
            string input = Console.ReadLine();
            if (input == "vänster") (card.rightSide, card.leftSide) = (card.leftSide, card.leftSide);

            (int row, int column) firstSide = GetPosition(card.rightSide.landscape);
            (int row, int column) secondSide = GetPosition(card.leftSide.landscape);

            (Board[firstSide.row, firstSide.column], Board[secondSide.row, secondSide.column]) = (card.rightSide, card.leftSide);
        }

        public (int, int) GetPosition(Landscape landscape)
        {
            Console.Write($"I vilken rad ska spelkortet läggas in i?");
            int rad = Convert.ToInt32(Console.ReadLine());
            Console.Write($"I vilken column ska spelkortet läggas in i?");
            int column = Convert.ToInt32(Console.ReadLine());

            CheckIfPositionIsLegal(rad,column, landscape, true);

            return (rad, column);
        }


        public bool CheckIfPositionIsLegal(int row, int column, Landscape landscape, bool firstCard)
        {
            if (firstCard && (Board[row, column].landscape == Landscape.Empty) && (Board[row - 1, column].landscape == landscape || Board[row, column + 1].landscape == landscape || Board[row + 1, column].landscape == landscape || Board[row, column - 1].landscape == landscape))
                
            if (!firstCard && Board[row, column].landscape == Landscape.Empty)





                return true;

                return false;
        }

        

        public void PrintPLayingBoard()
        {
            for (int rad = 0; rad < Board.GetLength(0); rad++)
            {
                for (int column = 0; column < Board.GetLength(1); column++)
                {
                    Console.Write($"{Board[rad, column],-12}");
                    if (Board[rad, column] == null) Console.Write("null");
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