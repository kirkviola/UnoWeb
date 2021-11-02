using System;
using System.Collections.Generic;
using UnoWeb;
using UnoWeb.Models;

public class Game
{
    public int Id { get; set; }
    public string GameRoom { get; set; }
    public int PlayerCap { get; set; }
    public virtual Player Active { get; set; }

    public virtual IEnumerable<GameCard> GameCards { get; set; }

    public Game()
	{
	}
}
