using System;
using System.Collections.Generic;
using UnoWeb;
using UnoWeb.Models;

public class Game
{
    public int id { get; set; }
    public string GameRoom { get; set; }
    public Queue<Card> DealingDeck { get; set; }
    public Queue<Card> DiscardDeck { get; set; }
    public Queue<Player> Players { get; set; }
    public Player active { get; set; }

    public Game()
	{
	}
}
