using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships.Models
{
    public static class CommonCode
    {
        public static int[,] RandomBoard()
        {
            Random random = new Random();
            int[,] board = new int[7, 7];
            int shipsPositions = 0;

            do
            {
                var x = random.Next(0, 6);
                var y = random.Next(0, 6);

                if (board[x, y] == 0)
                {
                    board[x, y] = 1;
                    shipsPositions++;
                }

            } while (shipsPositions < 20);

            return board;
        }
    }
}
