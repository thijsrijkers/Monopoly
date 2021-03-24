using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.Player.Pawn
{
    public class PawnFigure
    {
        private PawnShape shape;
        private Material material;

        public PawnFigure(PawnShape shape, Material material)
        {
            this.shape = shape;
            this.material = material;
        }

        public Material GetMaterial()
        {
            return this.material;
        }

        public PawnShape GetShape()
        {
            return this.shape;
        }
    }
}
