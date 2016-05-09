using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ships.Models
{
    public class Session
    {
        public Guid Id { get; set; }
        public Player PlayerA { get; set; }
        public Player PlayerB { get; set; }

        public Session()
        {
            Id = Guid.NewGuid();

            PlayerA = new Player();
            PlayerB = new Player();
        }
    }
}
