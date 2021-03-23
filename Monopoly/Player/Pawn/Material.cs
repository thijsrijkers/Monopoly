using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Pawn
{
    public abstract class Material
    {
        private string materialName;
        private int materialStrenght;

        public abstract string GetMaterialName();

        public abstract int GetMaterialStrenght();
    }
}
