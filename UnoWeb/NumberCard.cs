using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnoWeb
{
    public class NumberCard : Card
    {
        public int Value { get; set; }
        public string Color { get; set; }

        public NumberCard(int value, string color)
        {
            this.Value = value;
            this.Color = color;
        }
    }
}
