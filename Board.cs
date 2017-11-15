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
  //Class to handle board creation and manipulation 
  public class Board
  {
    public Cell[,] grid;
    int rows = 0;
    int columns = 0;
    Graphics graphics;
    int width = 50;
    int height = 50;
    public double fitness;

    public Board(Graphics Graphics, int Rows, int Columns, Cell[,] Grid)
    {
      rows = Rows;
      columns = Columns;
      graphics = Graphics;
      grid = Grid;
      this.fitness = getFitness(this);
    }

    //Copying constructor
    public Board(Board b)
    {
      this.rows = b.rows;
      this.columns = b.columns;
      this.width = b.width;
      this.graphics = b.graphics;
      this.fitness = b.fitness;
      this.grid = new Cell[b.rows, b.columns];
      for (int i = 0; i < b.rows; i++)
      {
        for (int j = 0; j < b.columns; j++)
        {
          this.grid[i, j] = new Cell(b.grid[i, j]);
        }
      }
    }

    //Create the board outline for the end to differentiate the cells
    public void makeBoardOutline()
    {
      Rectangle board = new Rectangle(200, 50, width * 10, height * 10);
      //Spans are the sizes of each cell
      int colSpan = board.Width / columns;
      int rowSpan = board.Height / rows;
      graphics.DrawRectangle(Pens.Black, board);

      for (int i = 0; i < columns; i++)
      {
        graphics.DrawLine(Pens.Black, board.X + (i * colSpan), board.Y,
            board.X + (i * colSpan), (board.Height + board.Y));
      }

      for (int i = 0; i < columns; i++)
      {
        graphics.DrawLine(Pens.Black, board.X, board.Y + (i * colSpan),
            board.Width + board.X, board.Y + (i * colSpan));
      }

    }

    //Draws the board, one cell at a time
    public void DrawBoard(Board board)
    {
      Rectangle outline = new Rectangle(200, 50, width * 10, height * 10);
      int colSpan = outline.Width / columns;
      int rowSpan = outline.Height / rows;

      graphics.FillRectangle(Brushes.White, outline);
      graphics.DrawRectangle(Pens.Black, outline);

      for (int j = 0; j < rows; j++)
      {
        for (int i = 0; i < columns; i++)
        {
          board.grid[j, i] = board.grid[j, i].setX(board.grid[j, i], outline.X + colSpan * i);
          board.grid[j, i] = board.grid[j, i].setY(board.grid[j, i], outline.Y + rowSpan * j);
          board.grid[j, i] = board.grid[j, i].setWidth(board.grid[j, i], rowSpan + 4);
          board.grid[j, i] = board.grid[j, i].setHeight(board.grid[j, i], colSpan + 4);

          board.grid[j, i].drawCell(board.grid[j, i], graphics);
        }
      }


    }

    //Scans through a grid and returns the number of numbered cells
    public int checkNumCell(Cell[,] cell)
    {
      int n = 0;
      for (int j = 0; j < rows; j++)
      {
        for (int i = 0; i < columns; i++)
        {
          if (cell[i, j].isNumberedCell == true)
          {
            n++;
          }
        }
      }
      return n;

      //Returns the number of rows and columns
    }
    public int getNumRows()
    {
      return rows;
    }

    public int getNumColumns()
    {
      return columns;
    }

    public void loadData()
    {

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
            fitness = fitness - (double)board.grid[i, j].getNumber(board.grid[i, j]);
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
