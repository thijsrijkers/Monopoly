﻿using Monopoly.Player.Pawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player
{
    public class HumanPlayer : PlayerObject
    {
        public HumanPlayer(Tile positionValue, PawnFigure pawnValue, int moneyValue) : base(positionValue, pawnValue, moneyValue)
        {
        }
    }
}