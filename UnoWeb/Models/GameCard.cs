﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnoWeb.Models
{
    public class GameCard
    {
        public enum Type { wild, one, two, three, four, five, six, seven, eight, nine, ten, skip, reverse, wildDraw4, draw2 }
        public enum Color { red, blue, green, yellow, }


        public int Id { get; set; }
        public Type CardType { get; set; }
        public Color CardColor { get; set; }
        public int? PlayerId { get; set; } = null;
        public int GameId { get; set; }
        public bool IsPlayed { get; set; } = false;
        public int? SequenceNumber { get; set; }

        public virtual Player Player { get; set; }
        public virtual Game Game { get; set; }

        public GameCard () { }
        public GameCard (Type cardtype, Color cardColor, int gameId)
        {
            this.CardType = cardtype;
            this.CardColor = cardColor;
            this.GameId = gameId;
        }

    }
}
