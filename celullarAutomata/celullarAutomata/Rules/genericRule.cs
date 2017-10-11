using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celullarAutomata
{
    class genericRule:RuleSet
    {
        private int _a;
        private int _b;
        public genericRule(int[,] field, int maxX, int maxY, int a, int b)
        : base(field, maxX, maxY)
    {
            _a = a;
            _b = b;
        }
        /// <summary>
        /// Converts a number to an array of digits. For example 123 becomes 1,2,3
        /// </summary>
        /// <param name="digits">Number, such as 123</param>
        /// <returns>List of numbers, such as 1,2,3</returns>
        protected List<int> ToDigitArray(int digits)
        {
            List<int> result = new List<int>();
            string digitString = digits.ToString();
            foreach (char digit in digitString)
            {
                result.Add(Convert.ToInt32(digit.ToString()));
            }
            return result;
        }
        protected override int[,] tickAlgorithm()
        {
            int[,] field2 = new int[_maxX, _maxY];
            // A/B
            // The first number(s) is what is required for a cell to continue.
            // The second number(s) is the requirement for birth.
            for (int y = 0; y < _maxY; y++)
            {
                for (int x = 0; x < _maxX; x++)
                {
                    bool processed = false;
                    int neighbors = getNumberOfNeighbors(x, y);
                    List<int> birthDigits = ToDigitArray(_b);
                    foreach (int digit in birthDigits)
                    {
                        if (neighbors == digit)
                        {
                            // cell is born.
                            field2[x, y] = 1;
                            processed = true;
                            break;
                        }
                    }

                    if (processed)
                    {
                        continue;
                    }

                    List<int> liveDigits = ToDigitArray(_a);
                    foreach (int digit in liveDigits)
                    {
                        if (neighbors == digit)
                        {
                            // cell continues.
                            field2[x, y] = _field[x, y];
                            processed = true;
                            break;
                        }
                    }

                    if (processed)
                    {
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
