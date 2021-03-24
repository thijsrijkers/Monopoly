using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Card
{
    public class Cardlist : ICardCloneable
    {
        private List<CardObject> cards;

        public ICardCloneable Clone()
        {
            //TODO Fix this
            return null;
        }

        public CardObject DrawCard()
        {
            Random rnd = new Random();
            return cards[rnd.Next(0, cards.Count + 1)];
        }

        public void AddCard(CardObject value)
        {
            cards.Add(value);
        }

        public void RemoveCard(CardObject value)
        {
            cards.Remove(value);
        }

        public void ExecuteCard(CardObject value, Board board, PlayerObject target)
        {
            value.ExecuteCommand(board, target);
        }
    }
}
