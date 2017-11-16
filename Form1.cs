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
      Random rand = new Random();
      System.Drawing.Graphics graphicsObj;

      graphicsObj = this.CreateGraphics();
      Board board = new Board(graphicsObj, 7, 7, grid);
      board.DrawBoard(board);
      board.makeBoardOutline();
      Board bestBoard = null;
      //MessageBox.Show("Before board is manipulated");

      GA alg = new GA(board.checkNumCell(board.grid));
      List<Board> population = new List<Board>();
      List<Board> newPopulation = new List<Board>();
      population = alg.makePopulation(board);

      for (int i = 0; i < 600; i++)
      {
        for (int j = 0; j < 7500; j++)
        {
          if (rand.Next(100) == 1)
          {
            population[j] = alg.mutation(population[j]);
            population[j].fitness = alg.getFitness(population[j]);
            //board.DrawBoard(population[j]);
          }
          population[j].fitness = alg.getFitness(population[j]);
        }
        //for some reason, without including a recalc in the mutation loop,
        //some boards are coming in with much lower fitness than actual, doesn't happen without the 'new' in line 74,
        //but then the whole population slowly becomes the same board... figure it out
        //consider adding horizontal and vertical swap in crossover.


        population = population.OrderBy(b => b.fitness).ToList();
        if(bestBoard == null || bestBoard.fitness > population[0].fitness)    
        {
          bestBoard = new Board(population[0]);
          board.DrawBoard(bestBoard);
          board.makeBoardOutline();
        }
        for (int k = 7499; k > 3750; k--)
        {
          population[k] = new Board(alg.crossOver(population[rand.Next(7500)], population[rand.Next(7500)]));
        }
        /*for (int k = 0; k < 7500; k++)
        {
          newPopulation.Add(alg.crossOver(population[rand.Next(7500) / 2], population[rand.Next(7500) / 2]));
        }
        population = new List<Board>(newPopulation);
        population.Add(new Board(bestBoard));
        newPopulation.Clear();*/
      }
      WoC woc = new WoC();
      board = woc.findCommon(population);
      board.DrawBoard(bestBoard);
      board.makeBoardOutline();
      MessageBox.Show("After manipulation");

    }
  }
}
