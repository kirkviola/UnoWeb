using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnoWeb.Models
{
    public class Player
    {
        int Id { get; set; }
        public string Name { get; set; }
        public List<Card> Hand { get; set; }
        public bool Win { get; set; }
    }
}
