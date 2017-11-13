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
  public partial class Form1 : Form
  {
    Board board;
    public Form1()
    {
      InitializeComponent();
      this.Paint += DrawBoard;
      this.ResizeRedraw = true;

      //create solveable grid to start with, maybe introduce some database of solveable grids later
      Cell[,] start = new Cell[11, 11];
      start[2, 0] = new Cell(9);
      start[8, 0] = new Cell(8);
      start[8, 1] = new Cell(7);
      start[4, 2] = new Cell(12);
      start[10, 2] = new Cell(16);
      start[0, 3] = new Cell(9);
      start[1, 4] = new Cell(10);
      start[2, 5] = new Cell(12);
      start[4, 5] = new Cell(8);
      start[6, 5] = new Cell(11);
      start[8, 5] = new Cell(3);
      start[9, 6] = new Cell(3);
      start[10, 7] = new Cell(3);
      start[0, 8] = new Cell(7);
      start[6, 8] = new Cell(2);
      start[2, 9] = new Cell(7);
      start[2, 10] = new Cell(2);
      start[8, 10] = new Cell(5);
      board = new Board(start,11,11);

    }

    public void DrawBoard(Object sender, PaintEventArgs e)
    {
      Graphics graphics = this.CreateGraphics();
      graphics.Clear(this.BackColor);
      int rows = board.contents.GetUpperBound(0) + 1 - board.contents.GetLowerBound(0);
      int columns = board.contents.GetUpperBound(1) + 1 - board.contents.GetLowerBound(1);
      Rectangle rect = new Rectangle(this.Width / 2 - 20, 20, this.Width / 2 - 20, this.Height - 80);
      int colSpan = rect.Width / columns;
      int rowSpan = rect.Height / rows;

      graphics.FillRectangle(Brushes.White, rect);
      graphics.DrawRectangle(Pens.Black, rect);
      for (int i = 1; i < columns; i++)
      {
        graphics.DrawLine(Pens.Black, rect.X + (i * colSpan), rect.Y, rect.X + (i * colSpan), rect.Bottom);
      }

      for (int i = 1; i < rows; i++)
      {
        graphics.DrawLine(Pens.Black, rect.X, rect.Y + (i * rowSpan), rect.Right, rect.Y + (i * rowSpan));
      }

      string visString;
      for (int i = 0; i < rows; i++)
      {
        for (int j = 0; j < columns; j++)
        {
          if (board.contents[i, j] != null)
          {
            if (board.contents[i, j].isNumberedCell == true)
            {
              visString = board.contents[i, j].WhiteCellsInVision.ToString();
              graphics.DrawString(visString,
                  new Font(new FontFamily("Arial"), Math.Max(Math.Min(rowSpan, colSpan) / 2, 1)),
                  Brushes.Black, rect.X + (i * colSpan),
                  rect.Y + (j * rowSpan));
            }
            else if(board.contents[i,j].isGreyCell == true)
            {
              graphics.FillRectangle(Brushes.LightGray, rect.X + (i * colSpan) + 1,
                  rect.Y + (j * rowSpan) + 1, colSpan - 1,
                  rowSpan - 1);
            }
            else if(board.contents[i,j].isBlackCell == true)
            {
              graphics.FillRectangle(Brushes.Black, rect.X + (i * colSpan) + 1,
                  rect.Y + (j * rowSpan) + 1, colSpan - 1,
                  rowSpan - 1);
            }
          }
        }
      }
    }
  }


  //use cells to keep track on a board?
  public class Cell
  {
    public int x;
    public int y;
    public int WhiteCellsInVision;
    public bool isNumberedCell;
    public bool isBlackCell;
    public bool isGreyCell;
    public Cell(int x, int y, int vis)
    {
      this.x = x;
      this.y = y;
      this.WhiteCellsInVision = vis;
    }

    public Cell(int vis)
    {
      this.WhiteCellsInVision = vis;
      this.isNumberedCell = true;
    }
    public Cell()
    {

    }
  }

  //or we could use a board class to track Cells (just use WhiteCellsInVision from Cell class and not x,y)
  public class Board
  {
    public Cell[,] contents;
    int rows, columns;

    public Board(int x, int y)
    {
      this.contents = new Cell[x, y];
    }

    public Board(Cell[,] cells, int rows, int columns)
    {
      this.rows = rows;
      this.columns = columns;
      this.contents = cells;
      for(int i = 0; i< rows; i++)
      {
        for(int j=0; j< columns; j++)
        {
          if (this.contents[i, j] == null)
          {
            this.contents[i, j] = new Cell()
            {
              isGreyCell = true
            };
          }
        }
      }
    }

    public Board()
    {
      contents = null;
    }
  }

}
