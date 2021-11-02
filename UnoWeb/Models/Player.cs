using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnoWeb.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public virtual IEnumerable<PlayerGame> PlayerGames { get; set; }
        public virtual IEnumerable<GameCard> GameCards { get; set; }

    }
}
