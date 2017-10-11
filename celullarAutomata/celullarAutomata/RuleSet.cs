using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celullarAutomata
{
    public abstract class RuleSet
    {
        protected int _maxX = 0;
        protected int _maxY = 0;
        protected int[,] _field;

        public RuleSet(int[,] field, int maxX, int maxY)
        {
            this._field = field;
            this._maxX = maxX;
            this._maxY = maxY;
        }

        public int getNumberOfNeighbors(int x, int y)
        {
            int neighbors = 0;
            if (x + 1 < _maxX && _field[x + 1, y] == 1)
            {
                neighbors++;
            }
            if (x - 1 >= 0 && _field[x - 1, y] == 1)
            {
                neighbors++;
            }
            if (y + 1 < _maxY && _field[x, y + 1] == 1)
            {
                neighbors++;
            }
            if (y - 1 >= 0 && _field[x, y - 1] == 1)
            {
                neighbors++;
            }
            // diaganols
            if (x + 1 < _maxX && y + 1 < _maxY && _field[x + 1, y + 1] == 1)
            {
                neighbors++;
            }
            if (x + 1 < _maxX && y - 1 >= 0 && _field[x + 1, y - 1] == 1)
            {
                neighbors++;
            }
            if (x - 1 >= 0 && y + 1 < _maxY && _field[x - 1, y + 1] == 1)
            {
                neighbors++;
            }
            if (x - 1 >= 0 && y - 1 >= 0 && _field[x - 1, y - 1] == 1)
            {
                neighbors++;
            }
            return neighbors;
        }

        public void tick()
        {
            int[,] field2 = tickAlgorithm();
            Array.Copy(field2, _field, field2.Length);
        }

        protected abstract int[,] tickAlgorithm();

    }
    
    
}
