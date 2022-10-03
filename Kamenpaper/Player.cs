using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kamenpaper
{
    class Player
    {
        public int money { get; set; }

        public int last { get; set; }

        public Player(int basem)
        {
            money = basem;
        }

        public void Rukec()
        {
            Random r = new Random();
            last = r.Next(0,3);
        }
    }

    public enum thing
    {
        rock,
        paper,
        sizors
    }
}
