using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celullarAutomata
{
    public class ConwaysGameOfLife : RuleSet
    {
        public ConwaysGameOfLife(int[,] field, int maxX, int maxY): base(field, maxX, maxY) { }
        protected override int[,] tickAlgorithm()
        {
            int[,] field2 = new int[_maxX, _maxY];
            for(int y=0; y < _maxY; y++)
            {
                for(int x = 0; x < _maxX; x++)
                {
                    int neighbors = getNumberOfNeighbors(x, y);
                    if(neighbors == 3)
                    {
                        //cell is born 
                        field2[x, y] = 1;
                        continue;
                    }

                    if(neighbors == 2 || neighbors == 3)
                    {
                        //cell continues 
                        field2[x, y] = _field[x, y];
                        continue;
                    }
                    //cell dies
                    field2[x, y] = 0;
                }
            }
            return field2;
        }
    }
}
