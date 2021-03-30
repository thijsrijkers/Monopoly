﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monopoly.Command;
using Monopoly.Player;

namespace Monopoly.Card
{
    public class CardObject
    {
        private BaseCommand command;

        public CardObject(BaseCommand command)
        {
            this.command = command;
        }

        public BaseCommand GetCommand()
        {
            return this.command;
        }

        public void SetCommand(BaseCommand value)
        {
            this.command = value;
        }

        public void ExecuteCommand(Board board, PlayerObject target)
        {
            this.command.Execute(board, target);
        }

        public CardObject Clone()
        {
            return new CardObject(this.command);
        }
    }
}
