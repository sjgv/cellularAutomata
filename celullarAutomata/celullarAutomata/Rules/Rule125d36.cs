using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celullarAutomata
{
    public class Rule125d36 : RuleSet
    {
        public Rule125d36(int[,] field, int maxX, int maxY)
            : base(field, maxX, maxY)
        {
        }
        protected override int[,] tickAlgorithm()
        {
            int[,] field2 = new int[_maxX, _maxY];
            // 125/36
            // The first number(s) is what is required for a cell to continue.
            // The second number(s) is the requirement for birth.
            for (int y = 0; y < _maxY; y++)
            {
                for (int x = 0; x < _maxX; x++)
                {
                    int neighbors = getNumberOfNeighbors(x, y);
                    if (neighbors == 3 || neighbors == 4)
                    {
                        // cell is born.
                        field2[x, y] = 1;
                        continue;
                    }
                    if (neighbors == 3 || neighbors == 4)// || neighbors == 5)
                    {
                        // cell continues.
                        field2[x, y] = _field[x, y];
                        continue;
                    }
                    // cell dies.
                    field2[x, y] = 0;
                }
            }
            return field2;
        }
    }
}
