using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuromasu
{
    public class GA
    {
        
        int numCells = 0;
        double mult = 0;
        Random rand = new Random();

        public GA(int num)
        {
            numCells = num;
            mult = numCells * 1.5;
            

        }

        public Board[] makePopulation(Board board)
        {
            
            Board[] population = new Board[7500];
            for (int i = 0; i < 1; i++)
            {
                population[i] = new Board(board);
                
            }
            for (int i = 0; i < 1; i++)
            {
                population[i] = placeBlack(population[i], mult);

            }
            
            for (int n = 0; n < 1; n++)
            {
                for (int i = 0; i < board.getNumRows(); i++)
                {
                    for (int j = 0; j < board.getNumColumns(); j++)
                    {
                        if (population[n].grid[i, j].getGrey(population[n].grid[i, j]) == true)
                        {
                            population[n].grid[i, j].setBlack(population[n].grid[i, j], false);
                            population[n].grid[i, j].setWhite(population[n].grid[i, j], true);
                            population[n].grid[i, j].setGrey(population[n].grid[i, j], false);
                        }
                    }
                }
            }
            
            //population[i] = placeBlack(population[i], mult);
            return population;
        }
       


public Board placeBlack(Board board, double mult)
        {
            int randi;
            int randj;
            double count = Math.Ceiling(mult);
            for (int i = 0; i < 1; i++)
            {
                while (count != 0)
                {
                    randi = rand.Next(board.getNumRows());
                    randj = rand.Next(board.getNumColumns());
                    if (board.grid[randi, randj].isNumberedCell != true)
                    {
                        //board[i].grid[randi, randj].isBlackCell = true;
                        //board[i].grid[randi, randj].isWhiteCell = false;
                        //board[i].grid[randi, randj].isGreyCell = false;
                        board.grid[randi, randj].setBlack(board.grid[randi, randj],true);
                        board.grid[randi, randj].setWhite(board.grid[randi, randj], false);
                        board.grid[randi, randj].setGrey(board.grid[randi, randj], false);

                        //board[i].grid[randi, randj].makeBlack(board[i].grid[randi, randj]);
                        //board.makeBlack(board.grid[randi, randj]);
                        count--;
                    }
                }
                count = Math.Ceiling(mult);
            }
            return board;
        }

        public Board crossOver(Board board1, Board board2)
        {
            Board child = board1;
            int half = (int)child.getNumRows() / 2;
            while (half + 1 < board1.getNumRows())
            {
                for (int i = 0; i < board1.getNumColumns(); i++)
                {
                    child.grid[half, i] = board2.grid[half, i];
                }
                half++;
            }
            return child;
        }

        public Board mutation(Board board)
        {
            for (int j = 0; j < board.getNumColumns(); j++)
            {
                for (int i = 0; i < board.getNumRows(); i++)
                {
                    if (board.grid[i, j].getBlack(board.grid[i, j]) == true)
                    {
                        if (((i + 1) < board.getNumRows()) && (board.grid[i + 1, j].getBlack(board.grid[i+1, j]) == true))
                        {
                            board.grid[i, j].setBlack(board.grid[i, j],false);
                            board.grid[i, j].setWhite(board.grid[i, j], true);
                            board.grid[i, j].setGrey(board.grid[i, j], false);
                            for(int n = i; n < board.getNumRows();n++)
                            for (int k = j + 1; k < board.getNumColumns(); k++)
                            {
                                if ((board.grid[n, k].getWhite(board.grid[n, k]) == true) && 
                                    (board.grid[n, k].getNum(board.grid[n, k]) == false))
                                {
                                        if(k+1 < board.getNumColumns())
                                        { 
                                    if ((board.grid[n, k + 1].getBlack(board.grid[n, k + 1]) == true) || (k+1) > board.getNumColumns())
                                    {
                                        //k = board.getNumColumns() + 1;
                                    }
                                    if ((board.grid[n + 1, k].getBlack(board.grid[n + 1, k]) == true) || (n + 1) > board.getNumRows())
                                    {
                                        //k = board.getNumColumns() + 1;
                                    }
                                    else
                                    {
                                        board.grid[n, k].setBlack(board.grid[n, k], true);
                                        board.grid[n, k].setWhite(board.grid[n, k], false);
                                        board.grid[n, k].setGrey(board.grid[n, k], false);
                                        return board;
                                    }
                                    }
                                }
                            }
                        }
                        if (((j+1) < board.getNumColumns()) && (board.grid[i, j+1].getBlack(board.grid[i, j+1]) == true))
                        {
                            board.grid[i, j].setBlack(board.grid[i, j], false);
                            board.grid[i, j].setWhite(board.grid[i, j], true);
                            board.grid[i, j].setGrey(board.grid[i, j], false);
                            for (int n = i; n < board.getNumRows(); n++)
                                for (int k = j + 1; k < board.getNumColumns(); k++)
                                {
                                    if ((board.grid[n, k].getWhite(board.grid[n, k]) == true) &&
                                        (board.grid[n, k].getNum(board.grid[n, k]) == false))
                                    {
                                        if ((k + 1) > board.getNumColumns())
                                        {
                                            if ((k + 1) > board.getNumColumns() || (board.grid[n, k + 1].getBlack(board.grid[n, k + 1]) == true))
                                            {
                                                //k = board.getNumColumns() + 1;
                                            }
                                            else if ((board.grid[n + 1, k].getBlack(board.grid[n + 1, k]) == true) || (n + 1) > board.getNumRows())
                                            {
                                                //k = board.getNumColumns() + 1;
                                            }
                                            else
                                            {
                                                board.grid[n, k].setBlack(board.grid[n, k], true);
                                                board.grid[n, k].setWhite(board.grid[n, k], false);
                                                board.grid[n, k].setGrey(board.grid[n, k], false);
                                                return board;
                                            }
                                        }
                                    }
                                }
                        }
                    }
                }
            }
            return board;
        }

        public double getFitness(Board board)
        {
            double fitness = 0;
            for (int j = 0; j < board.getNumRows(); j++)
            {
                for (int i = 0; i < board.getNumColumns(); i++)
                {
                    if (board.grid[i, j].isNumberedCell == true)
                    {
                        fitness = checkDown(board, i, j) + checkLeft(board, i, j) + checkRight(board, i, j) + checkUp(board, i, j);
                    }
                }
            }
            return fitness;
        }

        public double checkRight(Board board, int i, int j)
        {
            double count = 0;
            j++;
            while (j < board.getNumColumns())
            {
                if (board.grid[i, j].checkWhite(board.grid[i, j]) == true)
                {
                    count++;
                }
                j++;
            }
            return count;
        }

        public double checkDown(Board board, int i, int j)
        {
            double count = 0;
            i++;
            while (i < board.getNumRows())
            {
                if (board.grid[i, j].checkWhite(board.grid[i, j]) == true)
                {
                    count++;
                }
                i++;
            }
            return count;
        }

        public double checkLeft(Board board, int i, int j)
        {
            double count = 0;
            j--;
            while (j > 0)
            {
                if (board.grid[i, j].checkWhite(board.grid[i, j]) == true)
                {
                    count++;
                }
                j--;
            }
            return count;
        }

        public double checkUp(Board board, int i, int j)
        {
            double count = 0;
            i--;
            while (i > 0)
            {
                if (board.grid[i, j].checkWhite(board.grid[i, j]) == true)
                {
                    count++;
                }
                i--;
            }
            return count;
        }

    }
}
