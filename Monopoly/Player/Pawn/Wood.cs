using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Pawn
{
    public class Wood : Material
    {
        private string materialName;
        private int materialStrenght;

        public Wood()
        {
            this.materialName = "Wood";
            this.materialStrenght = 4;
        }


        public override string GetMaterialName()
        {
            return this.materialName;
        }

        public override int GetMaterialStrenght()
        {
            return this.materialStrenght;
        }
    }
}
