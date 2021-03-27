﻿using Monopoly.Player.Pawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Behaviour
{
    public class NPCPlayer : PlayerObject
    {
        private INPCBehaviour behaviour;

        public NPCPlayer(Tile positionValue, PawnFigure pawnValue, int moneyValue) : base(positionValue, pawnValue, moneyValue)
        {
        }

        public void SwitchBehaviour(INPCBehaviour value)
        {
            this.behaviour = value;
        }

        public void ToggleBehaviour()
        {
            
        }

        public override void GiveMoneyTo(Board board, int value, PlayerObject otherPlayer)
        {
            bool result = behaviour.acceptsTransactions(this);

            if (result) {
                base.GiveMoneyTo(board, value, otherPlayer);
            }
        }

    }
}
