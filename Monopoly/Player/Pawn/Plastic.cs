using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Pawn
{
    public class Plastic : Material
    {
        private string materialName;
        private int materialStrenght;

        public Plastic()
        {
            this.materialName = "Plastic";
            this.materialStrenght = 6;
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
