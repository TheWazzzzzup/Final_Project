using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Maps
    {
        private string[,] map = new string[50,50];
        
        
        public static void Create(string[,] mapSize)
        {
            for (int i = 0; i < mapSize.Length; i++)
            {
                for (int j = 0; j < mapSize.Length; j++)
                {
                    if (i == 0 || i == 9)
                    {
                        mapSize[i, j] = "-";
                        Console.Write(mapSize[i, j]);
                        continue;
                    }
                    else if (j == 0 || j == 9)
                    {
                        mapSize[i,j] = "|";
                        Console.Write(mapSize[i, j]);
                        continue;
                    }
                    else
                    {
                        mapSize[i,j] = "b";
                        Console.Write(mapSize[i, j]);
                        continue;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

// Contatins Map Logic And Map Generator.
// Should Contain Mine and Chest Data.
// 
