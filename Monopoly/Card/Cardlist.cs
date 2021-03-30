using Monopoly.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Card
{
    public class Cardlist
    {
        private Queue<CardObject> cards = new Queue<CardObject>();

        public CardObject DrawCard()
        {
            var card = cards.Dequeue();
            cards.Enqueue(card);
            // Picked card and put it at bottom of list.
            return card;
        }

        public void AddCard(CardObject value)
        {
            cards.Enqueue(value);
        }

        public void RemoveCard(CardObject value)
        {
            cards = (Queue<CardObject>)cards.Where(x => x != value);
        }

        private void shuffle()
        {
            var rng = new Random();
            cards.OrderBy(x => rng.Next());
        }

        public void ExecuteCard(CardObject value, Board board, PlayerObject target)
        {
            value.ExecuteCommand(board, target);
        }
    }
}
