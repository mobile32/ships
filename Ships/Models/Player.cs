using System;

namespace Ships.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int [,] Board { get; set; }

        public Player()
        {
            Id = Guid.NewGuid();
            Board = new int[7, 7];
        }
    }
}