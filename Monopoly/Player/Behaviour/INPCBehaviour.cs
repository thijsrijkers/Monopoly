using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Behaviour
{
    public interface INPCBehaviour
    {
        public void PayAmount(NPCPlayer player, PlayerObject other, int amount);

        public void ContemplateJail(NPCPlayer player);

        public void DrawChanceCard(NPCPlayer player);

        public void DrawCommunityChestCard(NPCPlayer player);

        public void PayBank(NPCPlayer player, int amount);

        public void BuyCurrentTile(NPCPlayer player);

        public void ThrowDice(NPCPlayer player, int alreadyThrown);
    }
}
