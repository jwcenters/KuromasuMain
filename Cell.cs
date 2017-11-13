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
    public class Cell
    {
        int x;
        int y;
        int width = 0;
        int height = 0;
        string number;
        bool isWhiteCell;
        public bool isNumberedCell;
        bool isBlackCell;
        bool isGreyCell;

        public Cell(int X, int Y, bool isWhite, bool isGrey, bool isBlack, bool isNum, string num)
        {
            x = X;
            y = Y;
            isWhiteCell = isWhite;
            isGreyCell = isGrey;
            isBlackCell = isBlack;
            isNumberedCell = isNum;
            number = num;
            //width = Width;
            //height = Height;
        }
        
    public Cell(Cell c)
    {
      this.x = c.x;
      this.y = c.y;
      this.width = c.width;
      this.height = c.height;
      this.number = c.number;
      this.isWhiteCell = c.isWhiteCell;
      this.isNumberedCell = c.isNumberedCell;
      this.isBlackCell = c.isBlackCell;
      this.isGreyCell = c.isGreyCell;
    }
        

        public Cell makeWhite(Cell cell)
        {
            //Rectangle rect = new Rectangle(cell.x, cell.y, cell.width - 5, cell.height - 5);
            //graphics.FillRectangle(Brushes.White, rect);
            cell.isBlackCell = false;
            cell.isGreyCell = false;
            cell.isWhiteCell = true;
            return cell;
        }

        public Cell makeGrey(Cell cell)
        {
            //Rectangle rect = new Rectangle(cell.x, cell.y, cell.width - 5, cell.height - 5);
            //graphics.FillRectangle(Brushes.LightGray, rect);
            cell.isBlackCell = false;
            cell.isGreyCell = true;
            cell.isWhiteCell = false;
            return cell;
        }
        /*
        public void makeBlack(Cell cell)
        {
            //Rectangle rect = new Rectangle(cell.x, cell.y, cell.width - 3, cell.height - 3);
            //graphics.FillRectangle(Brushes.Black, rect);
            cell.isBlackCell = true;
            cell.isGreyCell = false;
            cell.isWhiteCell = false;
            //return cell;
        }
        */
        public void drawCell(Cell cell, Graphics graphics)
        {

            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
               fontFamily,
               50,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
            System.Drawing.SolidBrush brush;
            brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            Rectangle rect = new Rectangle(cell.x, cell.y, cell.width, cell.height);
            if (cell.isNumberedCell == true)
            {
                graphics.FillRectangle(Brushes.White, rect);
                graphics.DrawString(cell.number, font,brush,(float)cell.x + 10, (float)cell.y + 10);
            }
            if (cell.isWhiteCell == true && cell.isNumberedCell == false)
            {
                graphics.FillRectangle(Brushes.White, rect);
            }
            if (cell.isBlackCell == true)
            {
                graphics.FillRectangle(Brushes.Black, rect);
            }
            if (cell.isGreyCell == true)
            {
                graphics.FillRectangle(Brushes.LightGray, rect);
            }
            
        }

        public bool checkWhite(Cell cell)
        {
            if (cell.isWhiteCell == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkBlack(Cell cell)
        {
            if (cell.isBlackCell == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkNumbered(Cell cell)
        {
            if (cell.isNumberedCell == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getX(Cell cell)
        {
            return cell.x;
        }

        public int getY(Cell cell)
        {
            return cell.y;
        }
        public bool getWhite(Cell cell)
        {
            return cell.isWhiteCell;
        }
        public bool getBlack(Cell cell)
        {
            return cell.isBlackCell;
        }
        public bool getGrey(Cell cell)
        {
            return cell.isGreyCell;
        }

        public bool getNum(Cell cell)
        {
            return cell.isNumberedCell;
        }

        public int getWidth(Cell cell)
        {
            return cell.width;
        }

        public int getHeight(Cell cell)
        {
            return cell.height;
        }

        public Cell setX(Cell cell, int X)
        {
            cell.x = X;
            return cell;
        }

        public Cell setY(Cell cell, int Y)
        {
            cell.y = Y;
            return cell;
        }
        public Cell setWhite(Cell cell, bool White)
        {
            cell.isWhiteCell = White;
            //cell.isBlackCell = false;
            //cell.isGreyCell = false;
            return cell;
        }
        public Cell setBlack(Cell cell, bool Black)
        {
            cell.isBlackCell = Black;
            return cell;
        }
        public Cell setGrey(Cell cell, bool Grey)
        {
            cell.isGreyCell = Grey;
            return cell;
        }

        public Cell setWidth(Cell cell, int Width)
        {
            cell.width = Width;
            return cell;
        }

        public Cell setHeight(Cell cell, int Height)
        {
            cell.height = Height;
            return cell;
        }
    }
}
