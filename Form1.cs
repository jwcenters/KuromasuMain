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
        Cell[,] grid = new Cell[7, 7];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            Read read = new Read("..\\..\\7x7.txt");
            grid = read.readFile();
            
            System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();
            Board board = new Board(graphicsObj, 7, 7, grid);
            
            GA alg = new GA(board.checkNumCell(board.grid));
            Board[] population = new Board[7500];
            population = alg.makePopulation(board);
            for (int i = 0; i < 1; i++)
            {

                alg.mutation(population[i]);

            }
            population[0].DrawBoard(population[0]);
            board.makeBoardOutline();
            
        }
    }
}
