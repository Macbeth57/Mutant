using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutant
{
    internal class Map
    {
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }
        List<Mutant> MutantsList { get; set; }

        public Map(List<Mutant> initMutantsList)
        {
            MapWidth = 120;
            MapHeight = 30;
            MutantsList = initMutantsList;
        }
        public void DisplayMap()
        {
            for(int y = 0; y < MapHeight; y++)
            {
                for(int x = 0; x < MapWidth; x++)
                {
                    if(y == 0 || y == MapHeight-1 || x == 0 || x == MapWidth-1)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("X");
                    }
                    foreach(Mutant mutant in MutantsList)
                    {
                        DisplayMutant(mutant, x, y);
                    }
                }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine();
            }
        }
        public void DisplayMutant(Mutant mutant, int x, int y)
        {
            if (mutant.XCoordinate == x && mutant.YCoordinate == y)
            {
                for (int mutantCellY = 0; mutantCellY < mutant.MutantCells.GetLength(0); mutantCellY++)
                {
                    for (int mutantCellX = 0; mutantCellX < mutant.MutantCells.GetLength(1); mutantCellX++)
                    {
                        if (mutant.MutantCells[mutantCellY, mutantCellX] == 1)
                        {
                            //Attention inversion X / Y ici 
                            Console.SetCursorPosition(x + mutantCellX, y + mutantCellY);
                            Console.Write("o");
                        }
                    }
                }
            }
        }
    }
}
