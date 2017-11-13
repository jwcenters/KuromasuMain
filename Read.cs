using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Kuromasu
{
    public class Read
    {

        string line; //Line is used to temporarily store a line from the tsp file
        string path;
        int n = 0; //Used to keep number of lines that is within the file
        int compare = 0;
        bool isGray;
        Cell[,] grid = new Cell[7, 7];
        int width = 0;
        int height = 0;
        int num = 0;

        public Read(string Path)
        {
            path = Path;
        }
        public Cell[,] readFile()
        {
            //Open and read the file
            var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            var streamReader = new StreamReader(fileStream, Encoding.UTF8);
            int i = 0;
            int j = 0;

            //Find the first city in the file by checking the index number  
            while ((line = streamReader.ReadLine()) != null)
            {
                int k = 0;
                for (int n = 0; n < 7; n++)
                {
                    string num = line.Substring(k,1);
                    compare = Int32.Parse(num);
                    if (compare != 0)
                    {
                        grid[i, n] = new Cell(width, height, true, false, false, true, num);
                    }
                    else
                    {
                        grid[i, n] = new Cell(width, height, false, true, false, false, "0");
                    }
                    k = k+2;
                }
                i++;
            }
            return grid;
        }
    }
        
}


   


