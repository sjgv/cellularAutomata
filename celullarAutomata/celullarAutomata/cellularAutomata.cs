using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celullarAutomata
{
    class cellularAutomata
    {
        static char cellIcon;
        private const int maxX = 80;
        private const int maxY = 40;
        private static int[,] field = new int[maxX, maxY];

        static void DrawField()
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            
            for(int y = 0; y < maxY; y++)
            {
                for(int x = 0; x < maxX; x++)
                {
                    Console.Write(field[x, y] == 1 ? cellIcon : ' ');
                }
                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            //initialize
            Console.SetWindowSize(maxX+10, Console.LargestWindowHeight);
            Console.SetWindowPosition(0, 0);

            //initialize random position
            Random r = new Random((int)DateTime.Now.Ticks);
            for(int x = 0; x < maxX; x++)
            {
                for(int y = 0; y < maxY; y++)
                {
                    field[x, y] = r.Next(0, 2);
                }
            }


            //Instantiate the desired concrete RuleSet in the Strategy pattern. 
            //RuleSet ruleSet = new ConwaysGameOfLife(field, maxX, maxY);
            //RuleSet ruleSet = new Rule125d36(field, maxX, maxY);
            Console.WriteLine("------------Welcome to Sal's Cellular Automata generator--------------------------\n[+]Click screen at any time to pause\n[+]Enter space bar to continue\n----------------------------------------------------------------------------------");
            Console.WriteLine("Enter string of neighbors needed to continue living ex. 128 = 1 or 2 or 8: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter string of neighbors needed to be born ex. 36 = 3 or 6: ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter char to display ex. * or 'o': ");
            cellIcon = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter time delay in milliseconds(if wanted): ");
            int delay = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            
            RuleSet ruleSet = new genericRule(field, maxX, maxY, a, b);
            

            for (int i=0; i < 5000; i++)
            {
                DrawField();
                ruleSet.tick();
                System.Threading.Thread.Sleep(delay);
            }
            
        }
    }
}
