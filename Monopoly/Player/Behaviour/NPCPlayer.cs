using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Behaviour
{
    public class NPCPlayer : BehaviourType
    {
        private INPCBehaviour behaviour;

        public NPCPlayer(INPCBehaviour behaviour)
        {
            this.behaviour = behaviour;
        }

        public override bool IsHuman()
        {
            return false;
        }

        public void SwitchBehaviour(INPCBehaviour value)
        {
            this.behaviour = value;
        }

        public void ToggleBehaviour()
        {
     
        }
    }
}
