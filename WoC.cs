using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuromasu
{
    public class WoC
    {
        //The WoC finds the three most popular black cells and takes the first board that has all three
        public Board findCommon(List<Board> board)
        {
            //Go through and count the number of cells that is black
            int[,] blackCount = new int[board[0].getNumRows(), board[0].getNumColumns()];
            for (int n = 0; n < board.Count; n++)
            {
                for (int i = 0; i < board[0].getNumRows(); i++)
                {
                    for (int j = 0; j < board[0].getNumColumns(); j++)
                    {
                        if (board[n].grid[i, j].getBlack(board[n].grid[i, j]) == true)
                        {
                            blackCount[i, j]++;
                        }
                    }
                }
            }
            int common1 = 0;
            int common2 = 0;
            int common3 = 0;
            int i1 = 0;
            int j1 = 0;
            int i2 = 0;
            int j2 = 0;
            int i3 = 0;
            int j3 = 0;

            //Go through and store the cell index and make the highest to 0
            for (int i = 0; i < board[0].getNumRows(); i++)
            {
                for (int j = 0; j < board[0].getNumColumns(); j++)
                {
                    if (blackCount[i,j] > common1)
                    {
                        common1 = blackCount[i, j];
                        i1 = i;
                        j1 = j;
                    }
                }
            }
            blackCount[i1, j1] = 0;

            //Do the same as above but with the second highest
            for (int i = 0; i < board[0].getNumRows(); i++)
            {
                for (int j = 0; j < board[0].getNumColumns(); j++)
                {
                    if (blackCount[i, j] > common2)
                    {
                        common2 = blackCount[i, j];
                        i2 = i;
                        j2 = j;
                    }
                }
            }
            blackCount[i2, j2] = 0;

            for (int i = 0; i < board[0].getNumRows(); i++)
            {
                for (int j = 0; j < board[0].getNumColumns(); j++)
                {
                    if (blackCount[i, j] > common3)
                    {
                        common3 = blackCount[i, j];
                        i3 = i;
                        j3 = j;
                    }
                }
            }

            //Go through and chekc for the first cell that satisfies the three black cells that were found
            for (int n = 0; n < board.Count; n++)
            {
                for (int i = 0; i < board[0].getNumRows(); i++)
                {
                    for (int j = 0; j < board[0].getNumColumns(); j++)
                    {
                        if (board[n].grid[i1, j1].getBlack(board[n].grid[i1, j1]) == true)
                        {
                            if (board[n].grid[i2, j2].getBlack(board[n].grid[i2, j2]) == true)
                            {
                                if (board[n].grid[i3, j3].getBlack(board[n].grid[i3, j3]) == true)
                                {
                                    return board[n];
                                }
                            }
                        }
                    }
                }
            }

            return board[0];
        }
    }
}
