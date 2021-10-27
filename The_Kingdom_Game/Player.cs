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
        int score;
        public (Landscape landscape, int numberOfCrown, int fieldIndex)[,] Board = new (Landscape, int, int)[9, 9];
        public (Landscape landscape, int numberOfCrown, int numberOfField)[] FieldIndex = new (Landscape, int, int ) [24]; 

        static int numberOfPlayer;
        public int fieldIndex = 0;


        public Player()
        {
            Board[4, 4] = (Landscape.King, 0, default);
            numberOfPlayer++;
        }

        #region Insert Card in Players Board

        
        public void InsertPlayingCard(PlayingCard card)
        {
            (int row, int column) rightPosition;
            (int row, int column) leftPosition;

            ((rightPosition), (leftPosition)) = GetPosition(card);

            (Board[rightPosition.row, rightPosition.column]) = card.rightSideContent;
            (Board[leftPosition.row, leftPosition.column]) = card.leftSideContent;

            UpdateFieldIndex(card.rightSideContent, rightPosition);
            UpdateFieldIndex(card.leftSideContent, leftPosition);
        }


        public void CreateScoreField(int numberOfCrown, int row, int column)
        {    
            FieldIndex[fieldIndex].numberOfCrown = FieldIndex[Board[row, column].fieldIndex].numberOfCrown + numberOfCrown;
            FieldIndex[fieldIndex].numberOfField = FieldIndex[Board[row, column].fieldIndex].numberOfField + 1;

            FieldIndex[Board[row, column].fieldIndex].numberOfCrown = 0;


            for (int _row = 0; _row < Board.GetLength(0); _row++)
            {
                for (int _column = 0; _column < Board.GetLength(1); _column++)
                {
                    if (Board[_row, _column].fieldIndex == Board[row, column].fieldIndex) Board[_row, _column].fieldIndex = Board[row, column].fieldIndex;
                }
            }
        }


         public void UpdateFieldIndex((Landscape landscape, int numberOfCrown, int fieldIndex) card, (int row, int column) position)
        {
            Board[position.row, position.column].fieldIndex = fieldIndex;


            for (int row = 0; row < Board.GetLength(0); row++)
            {
                for (int column = 0; column < Board.GetLength(1); column++)
                {
                    if ((row, column) == (position.row - 1, position.column)) CreateScoreField(card.numberOfCrown, position.row - 1, position.column);
                    if ((row, column) == (position.row + 1, position.column)) CreateScoreField(card.numberOfCrown, position.row + 1, position.column);
                    if ((row, column) == (position.row, position.column -1)) CreateScoreField(card.numberOfCrown, position.row, position.column -1);
                    if ((row, column) == (position.row, position.column +1)) CreateScoreField(card.numberOfCrown, position.row, position.column + 1);

                }
            }

            fieldIndex++;

          }



        public ((int, int), (int, int)) GetPosition(PlayingCard card) 
        {
            ((int, int), (int, int)) position;
            bool legal = false;
            Console.WriteLine(card.ToString());
            do
            {
              position = AskForPosition();
              legal = CheckIfPositionIsLegal(position, card.rightSideContent.landscape);
            } while (!legal);

            return position;
        }

        public ((int, int), (int, int)) AskForPosition()
        {
            Console.WriteLine("Vart ska spelkortet placeras på spelplanen? (Right row; Right column; Left row; Left column. Ex: 0;1;2;3)");
            string[] sInput = Console.ReadLine().Split(';');

            int rightX = Convert.ToInt32(sInput[0]);
            int rightY = Convert.ToInt32(sInput[1]);
            int leftX = Convert.ToInt32(sInput[2]);
            int leftY = Convert.ToInt32(sInput[3]);

            return ((rightX, rightY), (leftX, leftY));
        }


            public bool CheckIfPositionIsLegal(((int x, int y) right, (int x, int y) left) position, Landscape landscape)
        {       
            bool isRightPositionEmpty = Board[position.right.x, position.right.y].landscape == Landscape.Empty;
            bool isLeftPositionEmpty = Board[position.left.x, position.left.y].landscape == Landscape.Empty;
            bool isRightConnectedWithSameLandscape = Board[position.right.y - 1, position.right.x].landscape == landscape || Board[position.right.y, position.right.x + 1].landscape == landscape || Board[position.right.y + 1, position.right.x].landscape == landscape || Board[position.right.y, position.right.x - 1].landscape == landscape;
            bool isRightConnectedWithKing = Board[position.right.y - 1, position.right.x].landscape == Landscape.King || Board[position.right.y, position.right.x + 1].landscape == Landscape.King || Board[position.right.y + 1, position.right.x].landscape == Landscape.King || Board[position.right.y, position.right.x - 1].landscape == Landscape.King;

            if (isRightPositionEmpty && isLeftPositionEmpty && (isRightConnectedWithSameLandscape || isRightConnectedWithKing)) return true;
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