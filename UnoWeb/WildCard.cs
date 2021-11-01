using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnoWeb
{
    public class WildCard : Card
    {
        public string Color { get; set; }

        public WildCard(string color)
        {
            this.Color = color;
        }
    }
}

