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
    public class Board 
    {
          
        public Cell[,] grid;
        int rows = 0;
        int columns = 0;
        Graphics graphics;
        int width = 50;
        int height = 50;

        public Board(Graphics Graphics, int Rows, int Columns, Cell[,] Grid)
        {
            rows = Rows;
            columns = Columns;
            graphics = Graphics;
            grid = Grid;
        }

        public Board(Board b)
    {
      this.rows = b.rows;
      this.columns = b.columns;
      this.width = b.width;
      this.graphics = b.graphics;
      this.grid = new Cell[b.rows, b.columns];
      for(int i = 0; i < b.rows; i++)
      {
        for (int j = 0; j < b.columns; j++)
        {
          this.grid[i, j] = new Cell(b.grid[i, j]);
        }
      }
    }

        public void makeBoardOutline()
        {
            Rectangle board = new Rectangle(200, 50, width * 10, height * 10);
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


        public void DrawBoard(Board board)
        {
            Rectangle outline = new Rectangle(200,50,width*10, height*10);
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

        public int checkNumCell(Cell[,] cell)
        {
            int n = 0;
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < columns; i++)
                {
                    if (cell[i,j].isNumberedCell == true)
                    {
                        n++;
                    }
                }
            }
            return n;
        }
        public int getNumRows()
        {
            return rows;
        }

        public int getNumColumns()
        {
            return columns;
        }
        /*
        public void makeCellWhite(Cell temp)
        {
            cell.makeWhite(temp);
        }

        public void makeCellGrey(Cell temp)
        {
            cell.makeGrey(temp);
        }

        public void makeCellBlack(Cell temp)
        {
            cell.makeBlack(temp);
        }
        */
        public void loadData()
        {

        }
    }

}
